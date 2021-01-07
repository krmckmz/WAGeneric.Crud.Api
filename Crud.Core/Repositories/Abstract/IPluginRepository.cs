using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core
{
    public interface IPluginRepository:IRepository<PluginDao>
    {
        Task<IEnumerable<PluginDao>> GetAllWithProjects();
        Task<PluginDao> GetWithProjectByIdAsync(int id);
        Task<IEnumerable<PluginDao>> GetAllWithProjectByProjectIdAsync(int projectId);
    }
}
