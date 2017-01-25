using Matterspace.Lib.Services.Product;
using Matterspace.Model;
using Matterspace.Model.Enums;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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
                ThreadType = threadViewModel.ThreadType,
                CreatedAt = DateTime.Now,
                ProductId = threadViewModel.Product.Id.Value
            };

            this.Db.Threads.Add(thread);
            await this.Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ThreadViewModel>> GetThreads(int productId, ThreadType type)
        {
            var threads = await this.Db.Threads.Where(x => x.ProductId == productId && x.ThreadType == type).ToListAsync();
            return threads.Select(x => this.GetThreadViewModel(x));
        }

        private ThreadViewModel GetThreadViewModel(Model.Entities.Thread thread)
        {
            return new ThreadViewModel()
            {
                Id = thread.Id.ToString(),
                Title = thread.Title,
                Content = thread.TextMarkdown,
                ThreadType = thread.ThreadType
            };
        }
    }
}