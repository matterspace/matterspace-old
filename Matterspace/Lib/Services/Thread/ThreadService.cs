﻿using Matterspace.Model;
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
                Type = thread.ThreadType
            };

            return viewModel;
        }
    }
}