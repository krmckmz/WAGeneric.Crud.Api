using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core
{
    public interface IProjectRepository:IRepository<ProjectDao>
    {
        Task<IEnumerable<ProjectDao>> GetAllWithProjectAsync();
        Task<ProjectDao> GetWithPluginsByIdAsync(int id);
    }
}
