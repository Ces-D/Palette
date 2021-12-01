using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Palette.Base.Domain
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }
        DateTime OccuredOn { get; }
    }
}
