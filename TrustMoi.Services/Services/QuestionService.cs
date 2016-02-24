using System.Collections.Generic;
using System.Linq;
using TrustMoi.Data.Interfaces;
using TrustMoi.Services.Base;
using TrustMoi.Services.Mappers;
using TrustMoi.ViewModels;

namespace TrustMoi.Services.Services
{
    public class QuestionService : ServiceBase, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionAnswerMapper _questionAnswerMapper;

        public QuestionService(IQuestionRepository questionRepository, IQuestionAnswerMapper questionAnswerMapper)
        {
            _questionRepository = questionRepository;
            _questionAnswerMapper = questionAnswerMapper;
        }

        public IEnumerable<PersonQuestionAnswerVm> GetPersonQuestionAnswers()
        {
            return _questionRepository.GetAll().Select(p => _questionAnswerMapper.Map(p));
        }
    }

    public interface IQuestionService
    {
        IEnumerable<PersonQuestionAnswerVm> GetPersonQuestionAnswers();
    }
}