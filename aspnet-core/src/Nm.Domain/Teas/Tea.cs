using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Nm.Teas {
    public class Tea : Entity<Guid> {
        public string Name { get; set; }
 
    }
}
