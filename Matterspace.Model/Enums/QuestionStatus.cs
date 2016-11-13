using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matterspace.Model.Enums
{
    public enum QuestionStatus
    {
        Pending = 0,
        Answered = 1 // A question is marked as answered not when it has a reply, but when that reply is maked as the accepted answer. Either the question author or a product member can mark a question as answered
    }
}
