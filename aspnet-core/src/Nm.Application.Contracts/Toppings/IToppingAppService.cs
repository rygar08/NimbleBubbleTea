using System;
using Nm.Toppings.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Nm.Toppings
{
    public interface IToppingAppService :
        ICrudAppService< 
            ToppingDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateToppingDto,
            CreateUpdateToppingDto>
    {

    }
}