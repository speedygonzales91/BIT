using AutoMapper;
using BIT_Api.Managers;
using BIT_DataAccess.Data;
using BIT_Models;
using Microsoft.AspNetCore.Mvc;

namespace BIT_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private ProjectManager projectManager;

        public ProjectsController(ApplicationDbContext db, IMapper mapper)
        {
            projectManager = new ProjectManager(db, mapper);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var allProjects = await projectManager.GetAllProjects();
            return Ok(allProjects);
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetTicket(int? projectId)
        {
            if (projectId is null)
            {
                return BadRequest(new ErrorModel() { Title = "", ErrorMessage = "Invalid Project Id", StatusCode = StatusCodes.Status400BadRequest });
            }

            var ticket = await projectManager.GetProject(projectId.Value);
            if (ticket is null)
            {
                return BadRequest(new ErrorModel() { Title = "", ErrorMessage = "Invalid Project Id", StatusCode = StatusCodes.Status404NotFound });
            }

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectDTO project)
        {
            if (ModelState.IsValid)
            {
                var result = await projectManager.CreateProject(project);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel
                {
                    ErrorMessage = "Error while creating project"
                });
            }
        }

        [HttpPost("{projectId}")]
        public async Task<IActionResult> Update(int projectId,[FromBody] ProjectDTO project)
        {
            if (ModelState.IsValid)
            {
                var result = await projectManager.UpdateProject(projectId,project);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel
                {
                    ErrorMessage = "Error while updating project"
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int projectId)
        {
            var response = await projectManager.DeleteProject(projectId);

            if (response < 1)
            {
                return BadRequest(new ErrorModel
                {
                    ErrorMessage = "Error while deleting project"
                });
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
