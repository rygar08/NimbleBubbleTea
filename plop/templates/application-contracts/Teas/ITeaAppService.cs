using System;
using Nm.Teas.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Nm.Teas
{
    public interface ITeaAppService :
        ICrudAppService< 
            TeaDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateTeaDto,
            CreateUpdateTeaDto>
    {

    }
}