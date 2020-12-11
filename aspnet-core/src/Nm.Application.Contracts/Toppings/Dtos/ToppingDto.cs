using System;
using Volo.Abp.Application.Dtos;

namespace Nm.Toppings.Dtos
{
    [Serializable]
    public class ToppingDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}