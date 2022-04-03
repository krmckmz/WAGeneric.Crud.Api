using Crud.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.Services
{
    public class PluginService : IPluginService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PluginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PluginDao> CreatePlugin(PluginDao plugin)
        {
            await _unitOfWork.Plugins.AddAsync(plugin);
            await _unitOfWork.CommitAsync();
            return plugin;

        }

        public async Task DeletePlugin(PluginDao plugin)
        {
            _unitOfWork.Plugins.Remove(plugin);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<PluginDao>> GetAllPluginsWithProject()
        {
            return await _unitOfWork.Plugins.GetAllPluginsWithProject();
        }

        public async Task<PluginDao> GetPluginById(int id)
        {
            return await _unitOfWork.Plugins.GetPluginWithProjectById(id);
        }

        public async Task<IEnumerable<PluginDao>> GetPluginsByProjectId(int projectId)
        {
            return await _unitOfWork.Plugins.GetAllPluginsWithProjectByProjectId(projectId);
        }

        public async Task UpdatePlugin(PluginDao pluginToUpdate, PluginDao plugin)
        {
            pluginToUpdate.Title = plugin.Title;
            pluginToUpdate.ProjectId = plugin.ProjectId;

            await _unitOfWork.CommitAsync();
        }
    }
}
