using Microsoft.AspNetCore.Mvc;

namespace SimpleExample01.Controllers
{
    [ApiController]
    [Route("api/documents")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class DocumentsController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet("{documentId}")]
        public IActionResult GetDocumentV1(
            [FromRoute] int documentId)
        {
            var doc = Data.Documents.FirstOrDefault
                (x => x.Id == documentId);

            if (doc is null)
                return NotFound(doc);

            return Ok(doc);
        }

        [HttpGet("{documentId}")]
        [MapToApiVersion("2.0")]
        public IActionResult GetDocumentV2([FromRoute] int documentId)
        {
            var doc = DataV2.Documents.FirstOrDefault
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

    public class DocumentResponseV2
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Tag { get; set; }
    }


    public class DataV2
    {
        public static readonly DocumentResponseV2[] Documents = new[]
        {
            new DocumentResponseV2() { Id = 1,
                Content = "Dokumentacja ASP.NET Core", Tag = "A"},
            new DocumentResponseV2() { Id = 2,
                Content = "Cały StackOverflow", Tag = "A"},

        };
    }
}
