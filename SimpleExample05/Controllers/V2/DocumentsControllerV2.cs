using Microsoft.AspNetCore.Mvc;

namespace SimpleExample01.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DocumentsController : ControllerBase
    {
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
