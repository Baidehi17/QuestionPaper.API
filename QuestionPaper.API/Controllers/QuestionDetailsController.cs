using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionPaper.BLL.Interface;
using QuestionPaper.Data.Entities.Model;

namespace QuestionPaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class questionDetailsController : ControllerBase
    {
        private readonly IQuestionDetailsDTO question;
        public questionDetailsController(IQuestionDetailsDTO _question)
        {
            question = _question;
        }
        [HttpGet]
        public async Task<IEnumerable<questionDetailsModel>> GetAll()
        {
            return await question.GetAllQuestionDetails();
        }
        [HttpGet("id")]
        public async Task<questionDetailsModel> GetQuestionById(int id)
        {
            return await question.GetQuestionDetailsById(id);
        }
        [HttpPost]
        public int AddQuestion(questionDetailsModel questionDetail)
        {
          return  question.InsertQuestionDetails(questionDetail);
        }
        [HttpPut("id")]
        public void Updatesubquestion(questionDetailsModel questionDetails)
        {
            question.UpdateQuestionDetails(questionDetails);
        }
        [HttpDelete("id")]
        public void DeleteQuestion(int id)
        {
            question.DeleteById(id);
        }
    }
}
