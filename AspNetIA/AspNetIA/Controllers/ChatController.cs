using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;


namespace AspNetIA.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGpt")]

        public async Task<IActionResult> UseChatGpt(string query)
        {
            string OutPutResult = "";
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Completions)
            {
                OutPutResult += completion.Text;
            }

            return Ok(OutPutResult);
        }

    }
}
