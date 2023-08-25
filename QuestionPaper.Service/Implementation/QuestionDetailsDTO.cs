using CarPool.BLL.Implementation;
using QuestionPaper.BLL.Interface;
using QuestionPaper.Data.Entities.Model;
using QuestionPaper.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionPaper.BLL.Implementation
{
    public class QuestionDetailsDTO : IQuestionDetailsDTO
    {
        private readonly IRepository<questionDetails> question;
        public QuestionDetailsDTO(IRepository<questionDetails> _question)
        {
            question = _question;
        }
        public async Task<IEnumerable<questionDetailsModel>> GetAllQuestionDetails()
        {
            IEnumerable<questionDetails> bookingList = await question.GetAll();
            IEnumerable<questionDetailsModel> lists = AutoMapper<questionDetails, questionDetailsModel>.Map(bookingList);
            return lists;
        }
        public async Task<questionDetailsModel> GetQuestionDetailsById(int id)
        {
            questionDetails bookingList = await question.GetById(id);
            questionDetailsModel list = AutoMapper<questionDetails, questionDetailsModel>.Map(bookingList);
            return list;
        }

        public void UpdateQuestionDetails(questionDetailsModel user)
        {
            questionDetails booking = AutoMapper<questionDetailsModel, questionDetails>.Map(user);
            question.Update(booking);
        }
        public void InsertQuestionDetails(questionDetailsModel data)
        {
            questionDetails booking = AutoMapper<questionDetailsModel, questionDetails>.Map(data);
            question.Add(booking);
        }

        public void DeleteById(int id)
        {
            question.Delete(id);
        }
    }
}

