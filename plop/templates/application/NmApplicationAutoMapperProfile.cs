using {{ project }}.Teas;
using {{ project }}.Teas.Dtos;
using {{ project }}.Flavours;
using {{ project }}.Flavours.Dtos;
using {{ project }}.Toppings;
using {{ project }}.Toppings.Dtos;
using {{ project }}.Bookings;
using {{ project }}.Bookings.Dtos;
using AutoMapper; 

namespace {{ project }};

public class {{ project }}ApplicationAutoMapperProfile : Profile
{
    public {{ project }}ApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */


        CreateMap<Tea, TeaDto>();
        CreateMap<CreateUpdateTeaDto, Tea>(MemberList.Source);
        CreateMap<Flavour, FlavourDto>();
        CreateMap<CreateUpdateFlavourDto, Flavour>(MemberList.Source);
        CreateMap<Topping, ToppingDto>();
        CreateMap<CreateUpdateToppingDto, Topping>(MemberList.Source);
        CreateMap<Booking, BookingDto>();
    }
}
