namespace Matterspace.Model.Enums
{
    public enum ThreadStatus
    {
        // Idea - Issue
        Pending = 0, // +Question
        InReview = 1,
        Planned = 2, // +Release - Backlog
        NotPlanned = 3,
        // Release - Backlog
        Released = 5,
        Cancelled = 6,
        // Question
        Answered = 8
    }
}
