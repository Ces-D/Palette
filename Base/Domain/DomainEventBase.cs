using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Base.Domain
{
    public class DomainEventBase : IDomainEvent
    {
        public Guid Id { get; init; }
        public DateTime OccuredOn { get; init; }
        public DomainEventBase()
        {
            this.Id = Guid.NewGuid();
            this.OccuredOn = DateTime.UtcNow;
        }
    }
}
