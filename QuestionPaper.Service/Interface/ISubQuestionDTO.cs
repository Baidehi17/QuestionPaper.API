using QuestionPaper.Data.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionPaper.BLL.Interface
{
    public interface ISubQuestionDTO
    {
        Task<IEnumerable<subQuestionsModel>> GetAllQuestionDetails();
        Task<IEnumerable<subQuestionsModel>> GetQuestionDetailsById(int id);
        public void InsertQuestionDetails(subQuestionsModel data);
        public  void UpdateQuestionDetails(subQuestionsModel user);
        public Task DeleteQuestionDetailsById(int id);
        public void DeleteById(int id);
    }
}
