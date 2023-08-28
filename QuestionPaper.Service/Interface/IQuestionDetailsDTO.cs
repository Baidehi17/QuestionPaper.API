using QuestionPaper.Data.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionPaper.BLL.Interface
{
    public interface IQuestionDetailsDTO
    {
        Task<IEnumerable<questionDetailsModel>> GetAllQuestionDetails();
        Task<questionDetailsModel> GetQuestionDetailsById(int id);
        public int InsertQuestionDetails(questionDetailsModel data);
        public void UpdateQuestionDetails(questionDetailsModel user);
        public void DeleteById(int id);
    }
}
