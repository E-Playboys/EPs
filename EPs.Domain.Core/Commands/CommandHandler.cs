using EPs.Domain.Core.Interfaces;
using EPs.Domain.Core.Notification;

namespace EPs.Domain.Core.Commands
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public CommandHandler(IUnitOfWork unitOfWork, IBus bus, IDomainNotificationHandler<DomainNotification> notification)
        {
            _unitOfWork = unitOfWork;
            _notification = notification;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notification.HasNotifications()) return false;
            var commandResponse = _unitOfWork.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
