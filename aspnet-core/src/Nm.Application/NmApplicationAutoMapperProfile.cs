using Nm.Teas;
using Nm.Teas.Dtos;
using Nm.Flavours;
using Nm.Flavours.Dtos;
using Nm.Toppings;
using Nm.Toppings.Dtos;
using Nm.Bookings;
using Nm.Bookings.Dtos;
using AutoMapper; 

namespace Nm;

public class NmApplicationAutoMapperProfile : Profile
{
    public NmApplicationAutoMapperProfile()
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
