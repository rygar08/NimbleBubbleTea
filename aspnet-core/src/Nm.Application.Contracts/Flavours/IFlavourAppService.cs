using System;
using Nm.Flavours.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Nm.Flavours
{
    public interface IFlavourAppService :
        ICrudAppService< 
            FlavourDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateFlavourDto,
            CreateUpdateFlavourDto>
    {

    }
}