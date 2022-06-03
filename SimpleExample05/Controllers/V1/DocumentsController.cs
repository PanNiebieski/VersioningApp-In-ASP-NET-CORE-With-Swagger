using Microsoft.AspNetCore.Mvc;

namespace SimpleExample01.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DocumentsController : ControllerBase
    {
        [HttpGet("{documentId}")]
        [MapToApiVersion("1.0")]
        public IActionResult GetDocument(
            [FromRoute] int documentId)
        {
            var doc = Data.Documents.FirstOrDefault
                (x => x.Id == documentId);

            if (doc is null)
                return NotFound(doc);

            return Ok(doc);
        }

    }

    public class DocumentResponse
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }

    public class Data
    {
        public static readonly DocumentResponse[] Documents = new[]
        {
            new DocumentResponse() { Id = 1,
                Text = "Dokumentacja ASP.NET Core"},
            new DocumentResponse() { Id = 2,
                Text = "Cały StackOverflow"},

        };
    }

    
}
