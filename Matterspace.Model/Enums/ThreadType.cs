﻿using Matterspace.Model.Attributes;

namespace Matterspace.Model.Enums
{
    public enum ThreadType
    {
        [ThreadPage("Ideas")]
        Idea = 1,
        [ThreadPage("Issues")]
        Issue = 2,
        [ThreadPage("Backlog")]
        BacklogItem = 3,
        [ThreadPage("QA")]
        QA = 4,
        [ThreadPage("Docs")]
        Doc = 5,
        [ThreadPage("Releases")]
        Release = 6
    }
}
