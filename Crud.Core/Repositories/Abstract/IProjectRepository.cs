using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.Core
{
    public interface IProjectRepository : IRepository<ProjectDao>
    {
        Task<IEnumerable<ProjectDao>> GetAllWithProjectAsync();
        Task<ProjectDao> GetWithPluginsByIdAsync(int id);
    }
}
