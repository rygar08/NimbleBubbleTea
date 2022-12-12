using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Nm.CupSizes {
    public class CupSize : Entity<Guid> {  
          
        public string Name { get; set; }  
    
        public CupSize(string id) : base(id) { } 
       
    }
}
