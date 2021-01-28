using MediatR;

namespace Equinox.Domain.Core.Events
{
    public abstract class Message :IRequest<bool>
    {
      
       
        public string MessageType { get; protected set; }

        public int AggregateId { get; protected set; }
    
        protected Message()
        {
            MessageType = GetType().Name;

        }

    }
}