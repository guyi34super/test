using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elca.Sms.Api.Domain.Enums
{
    public enum RequestStatus
    {
        NotStarted,
        InStock,
        ToOrder,
        Cancelled,
        NotApproved,
        Completed
    }
}
