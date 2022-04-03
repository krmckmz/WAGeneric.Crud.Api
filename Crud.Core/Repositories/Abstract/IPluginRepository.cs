using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.Core
{
    public interface IPluginRepository : IRepository<PluginDao>
    {
        Task<IEnumerable<PluginDao>> GetAllPluginsWithProject();
        Task AddPlugin(PluginDao item);
        Task<PluginDao> GetPluginWithProjectById(int id);
        Task<IEnumerable<PluginDao>> GetAllPluginsWithProjectByProjectId(int projectId);
    }
}