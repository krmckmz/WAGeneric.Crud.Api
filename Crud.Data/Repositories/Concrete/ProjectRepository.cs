using Crud.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.Data
{
    public class ProjectRepository : Repository<ProjectDao>, IProjectRepository
    {
        public ProjectRepository(CrudDbContext context):base(context)
        {
           
        }
        public async Task<IEnumerable<ProjectDao>> GetAllWithProjectAsync()
        {
            return await CrudDbContext.Projects
                .Include(a => a.Plugins)
                .ToListAsync();
        }

        public Task<ProjectDao> GetWithPluginsByIdAsync(int id)
        {
            return CrudDbContext.Projects
                 .Include(a => a.Plugins)
                 .SingleOrDefaultAsync(a => a.Id == id);
        }
        private CrudDbContext CrudDbContext
        {
            get { return context as CrudDbContext; }
        }
    }
}
