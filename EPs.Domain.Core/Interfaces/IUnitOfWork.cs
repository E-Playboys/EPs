using EPs.Domain.Core.Commands;
using System;

namespace EPs.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
