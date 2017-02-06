namespace Matterspace.Model.Entities
{
    public class ThreadRelease
    {
        public int Id { get; set; }

        public int ThreadId { get; set; }

        public Thread Thread { get; set; }

        public int ReleaseId { get; set; }

        public Release Release { get; set; }
    }
}
