using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Nm.Bookings {
    public class Booking : Entity<Guid> { 

        [Required]
        public Guid TeaId { get; set; } 
        [Required]
        public Guid FlavourId { get; set; } 
        [Required]
        public Guid ToppingId { get; set; } 
        [Required]
        public Guid SizeId { get; set; }  
        public Double Price { get; set; }

        public Booking(Guid id) : base(id) {
        }
    }
}
