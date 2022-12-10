 
using {{ project }}.Bookings.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace {{ project }}.Bookings {
    public interface IBookingAppService : IApplicationService { 

        Task<GetBookingOptionsOutput> GetBookingOptions();

    }


}
