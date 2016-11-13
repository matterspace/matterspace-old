﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matterspace.Model.Enums
{
    public enum IssueStatus
    {
        Pending = 0,
        InReview = 1,
        Planned = 2, //Should this be called WillFix?
        NotPlanned = 3 // Should this be called WontFix?
    }
}