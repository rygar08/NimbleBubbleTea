using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace {{ project }}.Bookings.Dtos {

    [Serializable]
    public class SubmitInput {
        public BookingDto Booking { get; set; }
    }

    [Serializable]
    public class BookingDto {
         
        public Guid Id { get; set; }  

        [Required]
        public Guid TeaId { get; set; }
        public string TeaName { get; set; }
        [Required]
        public Guid FlavourId { get; set; }
        public string FlavourName { get; set; }
        [Required]
        public Guid ToppingId { get; set; }
        public string ToppingName { get; set; }
        [Required]
        public Guid SizeId { get; set; }
        public string SizeName { get; set; }

        public Double Price { get; set; }


    }


    [Serializable]
    public class GetBookingOptionsOutput {

        public List<OptionDto> Teas { get; set; }
        public List<OptionDto> Flavours { get; set; }
        public List<OptionDto> Toppings { get; set; }
        public List<OptionDto> Sizes { get; set; }

    }

    [Serializable]
    public class OptionDto {

        public string Id { get; set; }
        public string Name { get; set; }

    }
 
}
