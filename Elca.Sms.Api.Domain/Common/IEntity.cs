using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elca.Sms.Api.Domain.Common
{
    public interface IEntity    
    {
        int Id { get; set; }

        bool IsDeleted { get; set; }

        DateTimeOffset CreatedOn { get; set; }

        string CreatedBy { get; set; }

        DateTimeOffset UpdatedOn { get; set; }

        string UpdatedBy { get; set; }
    }
}
