using System.Linq;
using TrustMoi.Data;
using TrustMoi.Services.Base;
using TrustMoi.Services.Interfaces;
using TrustMoi.ViewModels;

namespace TrustMoi.Services.Mappers
{
    public class QuestionAnswerMapper : MapperBase, IQuestionAnswerMapper
    {
        public PersonQuestionAnswerVm Map(Question source)
        {
            return new PersonQuestionAnswerVm
            {
                Question = source.Question1,
                Answers = source.Answers.Select(p => p.Answer1)
            };
        }
    }

    public interface IQuestionAnswerMapper : IMapper<Question, PersonQuestionAnswerVm>
    {
    }
}