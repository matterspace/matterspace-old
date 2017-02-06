using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class QuestionStatusChangeEvent: ThreadStatusChangeEvent
    {
        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public QuestionStatus? QuestionStatusFrom { get; set; }

        /// <summary>
        /// </summary>
        /// <remarks>
        /// This has to be NULLABLE because we're using TPH
        /// </remarks>
        public QuestionStatus? QuestionStatusTo { get; set; }
    }
}
