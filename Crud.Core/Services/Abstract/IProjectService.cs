using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Services.Abstract
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDao>> GetAllProjects();
        Task<ProjectDao> GetProjectById(int id);
        Task<ProjectDao> CreateProject(ProjectDao project);
        Task UpdateProject(ProjectDao projectToUpdate,ProjectDao project);
        Task DeleteProject(ProjectDao project);
    }
}
