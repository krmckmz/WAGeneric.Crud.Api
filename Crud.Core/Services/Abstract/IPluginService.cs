using Crud.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.Services
{
    public interface IPluginService
    {
        Task<PluginDao> CreatePlugin(PluginDao plugin);
        Task DeletePlugin(PluginDao plugin);
        Task<IEnumerable<PluginDao>> GetAllPluginsWithProject();
        Task<PluginDao> GetPluginById(int id);
        Task<IEnumerable<PluginDao>> GetPluginsByProjectId(int projectId);
        Task UpdatePlugin(PluginDao pluginToUpdate, PluginDao plugin);
    }
}