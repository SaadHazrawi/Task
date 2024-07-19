using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace Task.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StackOverflowController : ControllerBase
    {
        private readonly IStackOverflowApiService _stackOverflowApiService;

        public StackOverflowController(IStackOverflowApiService stackOverflowApiService)
        {
            _stackOverflowApiService = stackOverflowApiService;
        }

        [HttpGet("latestQuestions")]
        public async Task<IActionResult> GetLatestQuestions(int pageSize = 50)
        {
                var questions = await _stackOverflowApiService.GetLatestQuestionsAsync(pageSize);
                return Ok(questions);
           
        }
    }
}
