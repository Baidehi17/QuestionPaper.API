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
    public class SubQuestionDTO : ISubQuestionDTO
    {
        private readonly IRepository<subQuestions> question;
        public SubQuestionDTO(IRepository<subQuestions> _question)
        {
            question = _question;
        }
        public async Task<IEnumerable<subQuestionsModel>> GetAllQuestionDetails()
        {
            IEnumerable<subQuestions> bookingList = await question.GetAll();
            IEnumerable<subQuestionsModel> lists = AutoMapper<subQuestions, subQuestionsModel>.Map(bookingList);
            return lists;
        }
        public async Task<IEnumerable<subQuestionsModel>> GetQuestionDetailsById(int id)
        {
            IEnumerable<subQuestions> bookingList = await question.GetAll();
            IEnumerable<subQuestions> subQuestions = bookingList.Where(b=>b.questionDetails_id == id);
           // IEnumerable<subQuestions> bookingList = await question.GetByIdSubQuestion(id);
           IEnumerable<subQuestionsModel> list = AutoMapper<subQuestions, subQuestionsModel>.Map(subQuestions);
            return list;
        }

        public void UpdateQuestionDetails(subQuestionsModel user)
        {
            subQuestions booking = AutoMapper<subQuestionsModel, subQuestions>.Map(user);
            question.Update(booking);
        }
        public void InsertQuestionDetails(subQuestionsModel data)
        {
            subQuestions booking = AutoMapper<subQuestionsModel, subQuestions>.Map(data);
            question.Add(booking);
        }

        public void DeleteById(int id)
        {
            question.Delete(id);
        }
    }
}

