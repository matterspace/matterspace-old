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
            var thread = await this.Db.Threads.FindAsync(threadId);
#warning Change this throw to result model when available
            if (thread == null) throw new Exception("Could not find the thread");

            var viewModel = this.GetThreadViewModel(thread);

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
                .Where(x => x.ProductId == productId && x.Type == type).ToListAsync();

            return threads.Select(this.GetThreadViewModel);
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

        private ThreadViewModel GetThreadViewModel(Model.Entities.Thread thread)
        {
            return new ThreadViewModel()
            {
                Id = thread.Id.ToString(),
                Title = thread.Title,
                Content = thread.TextMarkdown,
                Type = thread.Type,
                Status = thread.Status,
                CategoryId = thread.CategoryId,
                Category = new ThreadCategoryViewModel
                {
                    Id = thread.Category.Id,
                    Name = thread.Category.Name,
                    ProductId = thread.ProductId
                }
            };
        }
    }
}