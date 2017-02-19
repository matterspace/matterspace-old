using Matterspace.Model;
using Matterspace.Model.Enums;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Matterspace.Lib.Services.Thread
{
    public class ThreadService
    {
        public ThreadService(MatterspaceDbContext db)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));
            this.Db = db;
        }

        public MatterspaceDbContext Db { get; }

        public async Task<ThreadViewModel> GetThread(int threadId)
        {
            var thread = await this.Db.Threads
                .Include(x => x.Product)
                .Include(x => x.Category)
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == threadId);

#warning Change this throw to result model when available
            if (thread == null) throw new Exception("Could not find the thread");

            var category = await this.Db.ThreadCategories
                .FirstOrDefaultAsync(x => x.ProductId == thread.ProductId && x.Id == thread.CategoryId);

            var viewModel = this.GetThreadViewModel(thread, category);

            return viewModel;
        }

        public async Task SaveThread(ThreadViewModel threadViewModel)
        {
            var thread = new Model.Entities.Thread()
            {
                TextMarkdown = threadViewModel.Content,
                Title = threadViewModel.Title,
                Type = threadViewModel.Type,
                CreatedAt = DateTime.UtcNow,
                ProductId = threadViewModel.Product.Id.Value,
                AuthorId = threadViewModel.AuthorId,
                Status = ThreadStatus.Pending, // Every thread starts pending
                CategoryId = threadViewModel.CategoryId
            };

            this.Db.Threads.Add(thread);
            await this.Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ThreadViewModel>> GetThreads(int productId, ThreadType type)
        {
            var threads = await this.Db.Threads
                .Include(x => x.Category)
                .Include(x => x.Author)
                .Where(x => x.ProductId == productId && x.Type == type)
                .ToListAsync();

            var categoriesIds = threads.Select(x => x.CategoryId);

            var categories = await this.Db.ThreadCategories
                .Where(x => x.ProductId == productId && categoriesIds.Contains(x.Id))
                .ToListAsync();

            return threads.Select(x => this.GetThreadViewModel(x, categories.FirstOrDefault(c => c.Id == x.CategoryId)));
        }

        public async Task<IEnumerable<ThreadCountViewModel>> GetThreadsCount(int productId)
        {
            var threads = await this.Db.Threads
                .Where(x => x.ProductId == productId) // Only threads by product id
                .GroupBy(x => x.Type) // Group by their type
                .Select(x => 
                new
                {
                    Type = x.FirstOrDefault().Type, // Only the type
                    Count = x.Count() // And the count by type
                })
                .ToListAsync();

            return threads
                .Select(x => new ThreadCountViewModel()
                {
                    Type = x.Type,
                    Count = x.Count
                });
        }

        private ThreadViewModel GetThreadViewModel(Model.Entities.Thread thread, Model.Entities.ThreadCategory category)
        {
            return new ThreadViewModel()
            {
                Id = thread.Id.ToString(),
                Title = thread.Title,
                Content = thread.TextMarkdown,
                Type = thread.Type,
                Status = thread.Status,
                CreatedAt = thread.CreatedAt,
                RelativeDate = this.GetRelativeDate(thread.CreatedAt),
                CategoryId = thread.CategoryId,
                Category = category == null
                ? null
                : new ThreadCategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    ProductId = category.ProductId
                },
                Product = new ProductViewModel
                {
                    Id = thread.Product.Id,
                    Name = thread.Product.Name,
                    DisplayName = thread.Product.DisplayName,
                    ShortDescription = thread.Product.ShortDescription,
                    WebsiteUrl = thread.Product.WebsiteUrl,
                    FacebookUrl = thread.Product.FacebookUrl,
                    TwitterUrl = thread.Product.TwitterUrl
                },
                Author = new ApplicationUserViewModel
                {
                    Id = thread.Author.Id,
                    UserName = thread.Author.UserName
                }
            };
        }

        private string GetRelativeDate(DateTime createdAt)
        {
            var timeSpanAgo = DateTime.UtcNow - createdAt;

            if (timeSpanAgo.Days > 0)
                return timeSpanAgo.Days == 1 ? $"{timeSpanAgo.Days} day ago" : $"{timeSpanAgo.Days} days ago";
            else if (timeSpanAgo.Hours > 0)
                return timeSpanAgo.Hours == 1 ? $"{timeSpanAgo.Hours} hour ago" : $"{timeSpanAgo.Hours} hours ago";
            else if (timeSpanAgo.Minutes > 0)
                return timeSpanAgo.Minutes == 1 ? $"{timeSpanAgo.Minutes} minute ago" : $"{timeSpanAgo.Minutes} minutes ago";
            else
                return "seconds ago";
        }
    }
}