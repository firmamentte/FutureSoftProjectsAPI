using FutureSoftProjectsAPI.BLL.BLLClasses;
using Microsoft.AspNetCore.Mvc;

namespace FutureSoftProjectsAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProjectController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ProjectBLL _projectBLL;

        public ProjectController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _projectBLL = new();
        }

        [Route("GetProjects")]
        [HttpGet]
        public async Task<ActionResult> GetProjects([FromQuery] string? searchValue)
        {
            return Ok(await _projectBLL.GetProjects(Path.Combine(_webHostEnvironment.ContentRootPath, "Data.json"), searchValue));
        }
    }
}