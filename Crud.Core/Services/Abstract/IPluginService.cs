using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Services.Abstract
{
    public interface IPluginService
    {
        Task<IEnumerable<PluginDao>> GetAllWithProject();
        Task<PluginDao> GetPluginById(int id);
        Task<IEnumerable<PluginDao>> GetPluginsByProjectId(int projectId);
        Task<PluginDao> CreatePlugin(PluginDao plugin);
        Task UpdatePlugin(PluginDao pluginToUpdate, PluginDao plugin);
        Task DeletePlugin(PluginDao plugin);
    }
}
