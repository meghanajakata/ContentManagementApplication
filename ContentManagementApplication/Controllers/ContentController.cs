using ContentManagementApplication.Models;
using ContentManagementApplication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ContentManagementApplication.Filters;

namespace ContentManagementApplication.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IContentRepository contentRepository;
        public ContentController(IContentRepository _contentRepository)
        {
            contentRepository = _contentRepository;
        }

        [HttpGet("GetAllContent")]
        [ServiceFilter(typeof(ExceptionFilter))]
        public IEnumerable<Content> GetContents()
        {
            return contentRepository.GetContents();
        }

        [HttpPost("CreateContent")]
        [ServiceFilter(typeof(LoggingActionFilterAttribute))]
        [ServiceFilter(typeof(ExceptionFilter))]
        public ActionResult<Content> CreateContent(Content content)
        {
            bool isContentAdded = contentRepository.AddContent(content);
            if(isContentAdded)
            {
                return content;
            }
            return BadRequest();
        }

        [HttpPost("DeleteContent")]
        [ServiceFilter(typeof(LoggingActionFilterAttribute))]
        [ServiceFilter(typeof(ExceptionFilter))]
        public ActionResult DeleteContent(int id)
        {
            bool isContentDeleted = contentRepository.DeleteContent(id);
            if(isContentDeleted)
            {
                return Ok("Content deleted successfully");
            }
            return BadRequest();
        }
    }
}
