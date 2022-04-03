using Crud.Core;
using Crud.Core.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ProjectDao> CreateProject(ProjectDao project)
        {
            await _unitOfWork.Projects.AddAsync(project);
            return project;
        }

        public async Task DeleteProject(ProjectDao project)
        {
            _unitOfWork.Projects.Remove(project);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ProjectDao>> GetAllProjects()
        {
            return await _unitOfWork.Projects.GetAllAsync();
          
        }

        public async Task<ProjectDao> GetProjectById(int id)
        {
            return await _unitOfWork.Projects.GetByIdAsync(id);
        }

        public async Task UpdateProject(ProjectDao projectToUpdate, ProjectDao project)
        {
            projectToUpdate.Name = project.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
