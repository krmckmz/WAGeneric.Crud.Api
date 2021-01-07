using System;
using System.Threading.Tasks;

namespace Crud.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPluginRepository Plugins { get; }
        IProjectRepository Projects { get; }
        Task<int> CommitAsync();
    }
}
