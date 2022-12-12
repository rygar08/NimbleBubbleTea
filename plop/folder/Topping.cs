using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Nm.Toppings {
    public class Topping : Entity<Guid> {  
          
        public string Name { get; set; }  
    
        public Topping(Guid id) : base(id) { } 
       
    }
}
