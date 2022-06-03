using Microsoft.AspNetCore.Mvc;

namespace SimpleExample01.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController :  ControllerBase
    {
        public IActionResult GetDocument(
            [FromRoute] Guid documentId)
        {

        }
    }

    public class DocumentResponse
    {
        public Guid Id { get; set; }

        public string Text { get; set; }
    }
}
