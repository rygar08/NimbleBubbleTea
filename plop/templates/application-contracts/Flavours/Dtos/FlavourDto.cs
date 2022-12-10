using System;
using Volo.Abp.Application.Dtos;

namespace Nm.Flavours.Dtos
{
    [Serializable]
    public class FlavourDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}