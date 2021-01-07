using Crud.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Data
{
    public class PluginRepository : Repository<PluginDao>, IPluginRepository
    {
        public PluginRepository(CrudDbContext context):base(context)
        {

        }
        public async Task<IEnumerable<PluginDao>> GetAllWithProjectByProjectIdAsync(int projectId)
        {
            return await CrudDbContext.Plugins
                  .Include(x => x.LocatedProject)
                  .ToListAsync();
        }

        public async Task<IEnumerable<PluginDao>> GetAllWithProjects()
        {
            return await CrudDbContext.Plugins
                .Include(x => x.LocatedProject)
                .ToListAsync();
        }

        public async Task<PluginDao> GetWithProjectByIdAsync(int id)
        {
            return await CrudDbContext.Plugins
                .Include(x => x.LocatedProject)
                .SingleOrDefaultAsync(x=>x.Id==id);
        }

        private CrudDbContext CrudDbContext { get { return context as CrudDbContext; } }
    }
}
