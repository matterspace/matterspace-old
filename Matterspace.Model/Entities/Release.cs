using System;
using System.Collections.Generic;
using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class Release
    {
        public Release()
        {
            this.ThreadReleases = new List<ThreadRelease>();
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? EstimatedReleaseDate { get; set; }

        public DateTime? ReleasedAt { get; set; }

        public string Name;

        public string NotesMarkdown { get; set; }

        public ReleaseStatus Status;

        public ICollection<ThreadRelease> ThreadReleases { get; set; }
    }
}
