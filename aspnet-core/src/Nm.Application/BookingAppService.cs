using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;
using Nm;
using Nm.Bookings;
using Nm.Bookings.Dtos;
using Nm.Teas;
using Nm.Toppings;
using Nm.Flavours;
using Nm.CupSizes;
using Microsoft.AspNetCore.Authorization;

namespace Km.BookingRequests {


    [AllowAnonymous]
    public class BookingsAppService : NmAppService, IBookingAppService {

        private readonly IRepository<Tea, Guid> teaR;
        private readonly IRepository<Booking, Guid> bookingR;
        private readonly IRepository<Topping, Guid> toppingR;
        private readonly IRepository<Flavour, Guid> flavourR;
        private readonly IAsyncQueryableExecuter asyncExecuter;
        private readonly IRepository<CupSize, string> cupSizeR;


        public BookingsAppService(
            IRepository<Tea, Guid> teaR,
                IRepository<Booking, Guid> bookingR,
                IRepository<Topping, Guid> toppingR,
                IRepository<Flavour, Guid> flavourR,
                IAsyncQueryableExecuter asyncExecuter,
                IRepository<CupSize, string> cupSizeR) {

            this.teaR = teaR;
            this.bookingR = bookingR;
            this.toppingR = toppingR;
            this.flavourR = flavourR;
            this.asyncExecuter = asyncExecuter;
            this.cupSizeR = cupSizeR;

        }


        public async Task<GetBookingOptionsOutput> GetBookingOptions() {

            var output = new GetBookingOptionsOutput();

            output.Teas = (from s in (await teaR.ToListAsync()) select new OptionDto { Id = s.Id.ToString(), Name = s.Name }).ToList();
            output.Flavours = (from s in (await flavourR.ToListAsync()) select new OptionDto { Id = s.Id.ToString(), Name = s.Name }).ToList();
            output.Toppings = (from s in (await toppingR.ToListAsync()) select new OptionDto { Id = s.Id.ToString(), Name = s.Name }).ToList();
            output.Sizes = (from s in (await cupSizeR.ToListAsync()) select new OptionDto { Id = s.Id, Name = s.Name }).ToList();

            return output;

        }
    }


}
