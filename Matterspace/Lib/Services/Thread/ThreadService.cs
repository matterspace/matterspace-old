using Matterspace.Model;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Matterspace.Lib.Services.Thread
{
    public class ThreadService
    {
        public ThreadService(MatterspaceDbContext db)
        {
            this.Db = new MatterspaceDbContext();
        }

        public MatterspaceDbContext Db { get; }

        public async Task<ThreadViewModel> GetThreadViewModel(int threadId)
        {
            var thread = await Task.Run(() => this.GetThread(threadId));

            var viewModel = new ThreadViewModel()
            {
                Id = thread.Id.ToString(),
                Type = thread.ThreadType
            };

            return viewModel;
        }

        private Model.Entities.Thread GetThread(int threadId)
        {
            return this.Db.Threads.FirstOrDefault(x => x.Id == threadId);
        }
    }
}