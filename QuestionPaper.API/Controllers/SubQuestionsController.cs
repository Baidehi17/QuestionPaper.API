using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionPaper.BLL.Interface;
using QuestionPaper.Data.Entities.Model;

namespace QuestionPaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubQuestionsController : ControllerBase
    {
        private readonly ISubQuestionDTO question;
        public SubQuestionsController(ISubQuestionDTO _question)
        {
            question = _question;
        }
        [HttpGet]
        public async Task<IEnumerable<subQuestionsModel>> GetAll()
        {
            return await question.GetAllQuestionDetails();
        }
        [HttpGet("id")]
        public async Task<IEnumerable<subQuestionsModel>> GetQuestionById(int id)
        {
            return await question.GetQuestionDetailsById(id);
        }
        [HttpPost]
        public void AddSubQuest(subQuestionsModel questionDetail)
        {
            question.InsertQuestionDetails(questionDetail);
        }
        [HttpPut("id")]
        public void UpdateAddSubquest(subQuestionsModel questionDetails)
        {
            question.UpdateQuestionDetails(questionDetails);
        }
        [HttpDelete("id")]
        public Task DeleteSubQuestionDetail(int id)
        {
           return question.DeleteQuestionDetailsById(id);
        }
        [HttpDelete("DeleteById")]
        public void DeleteById(int id)
        {
            question.DeleteById(id);
        }
    }
}
