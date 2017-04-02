using EPs.Domain.Core.Commands;
using EPs.Domain.Core.Events;

namespace EPs.Domain.Core
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
