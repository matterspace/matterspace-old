using Matterspace.Model;
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

        public async Task<ThreadViewModel> GetThreadViewModel(int threadId)
        {
            var thread = await this.Db.Threads.FindAsync(threadId);
            if(thread == null) throw new Exception("Could not find the thread");

            var viewModel = new ThreadViewModel()
            {
                Id = thread.Id.ToString(),
                ThreadType = (ThreadType)((int)thread.ThreadType)
            };

            return viewModel;
        }

        public async Task SaveThread(ThreadViewModel threadViewModel)
        {
            var thread = new Model.Entities.Thread()
            {

                TextMarkdown = threadViewModel.Content,
                Title = threadViewModel.Title,
                ThreadType = (Model.Enums.ThreadType)((int)threadViewModel.ThreadType),
                CreatedAt = DateTime.Now
            };

            this.Db.Threads.Add(thread);
            await this.Db.SaveChangesAsync();
        }
    }
}