using System;
using Volo.Abp.Application.Dtos;

namespace Nm.Teas.Dtos
{
    [Serializable]
    public class TeaDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}