using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class Question : Thread
    {
        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public QuestionStatus? QuestionStatus { get; set; }

    }
}
