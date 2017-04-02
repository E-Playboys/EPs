using EPs.Domain.Core.Models;

namespace EPs.Domain.Core.Events
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
