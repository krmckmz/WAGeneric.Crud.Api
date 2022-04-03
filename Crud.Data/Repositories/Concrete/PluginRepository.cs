using Crud.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.Data
{
    public class PluginRepository : Repository<PluginDao>, IPluginRepository
    {
        public PluginRepository(CrudDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<PluginDao>> GetAllPluginsWithProjectByProjectId(int projectId)
        {
            return await CrudDbContext.Plugins
                  .Include(x => x.LocatedProject)
                  .ToListAsync();
        }

        public async Task<IEnumerable<PluginDao>> GetAllPluginsWithProject()
        {
            return await CrudDbContext.Plugins
                .Include(x => x.LocatedProject)
                .ToListAsync();
        }
        public async Task<PluginDao> GetPluginWithProjectById(int id)
        {
            return await CrudDbContext.Plugins
                .Include(x => x.LocatedProject)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddPlugin(PluginDao plugin)
        {
            await CrudDbContext.Plugins.AddAsync(plugin);
        }

        private CrudDbContext CrudDbContext { get { return context as CrudDbContext; } }
    }
}
