using System.Collections.Generic;

namespace TrustMoi.ViewModels
{
    public class PersonQuestionAnswerVm
    {
        public string Question { get; set; }
        public IEnumerable<string> Answers { get; set; }
    }
}