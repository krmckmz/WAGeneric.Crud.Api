using Crud.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly CrudDbContext _context;
        private PluginRepository _pluginRepository;
        private ProjectRepository _projectRepository;
        public UnitOfWork(CrudDbContext context)
        {
            _context = context;
        }
        public IPluginRepository Plugins => _pluginRepository = _pluginRepository ?? new PluginRepository(_context);
        public IProjectRepository Projects => _projectRepository = _projectRepository ?? new ProjectRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
