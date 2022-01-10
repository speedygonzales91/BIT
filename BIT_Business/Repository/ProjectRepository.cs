using AutoMapper;
using BIT_Business.Repository.IRepository;
using BIT_DataAccess.Data;
using BIT_Models;
using Microsoft.EntityFrameworkCore;

namespace BIT_Business.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProjectRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProjectDTO> CreateProject(ProjectDTO projectDTO)
        {
            try
            {
                var project = _mapper.Map<ProjectDTO, Project>(projectDTO);

                var addedProject = await _db.Projects.AddAsync(project);
                await _db.SaveChangesAsync();

                return _mapper.Map<Project, ProjectDTO>(addedProject.Entity);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<int> DeleteProject(int projectId)
        {
            var project = await _db.Projects.FindAsync(projectId);
            if (project != null)
            {
                //var allImages = await _db.HotelRoomImages.Where(x => x.RoomId == roomId).ToListAsync();
                //_db.HotelRoomImages.RemoveRange(allImages);

                _db.Projects.Remove(project);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjects()
        {
            try
            {
                IEnumerable<ProjectDTO> projectDTOs = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(await _db.Projects.ToListAsync());
                return projectDTOs.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ProjectDTO> GetProject(int projectId)
        {
            try
            {
                var project = _mapper.Map<Project, ProjectDTO>(await _db.Projects.FirstOrDefaultAsync(x => x.Id == projectId));

                var tickets = _db.Tickets.Count();
                var ticketsPerProject = _db.Tickets.Count(x=>x.ProjectId == projectId);
                project.TicketPercentage = ticketsPerProject / tickets;

                return project;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ProjectDTO> UpdateProject(int projectId, ProjectDTO projectDTO)
        {
            try
            {
                if (projectId == projectDTO.Id)
                {
                    var projectDetail = await _db.Projects.FindAsync(projectId);
                    var project = _mapper.Map<ProjectDTO, Project>(projectDTO, projectDetail);
                    var updatedProject = _db.Projects.Update(project);
                    await _db.SaveChangesAsync();

                    return _mapper.Map<Project, ProjectDTO>(updatedProject.Entity);
                }
                else
                {
                    //invalid
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
