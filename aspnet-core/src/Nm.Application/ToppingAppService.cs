using System;
using Nm.Permissions;
using Nm.Toppings.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Nm.Toppings
{
    public class ToppingAppService : CrudAppService<Topping, ToppingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateToppingDto, CreateUpdateToppingDto>,
        IToppingAppService
    {
        protected override string GetPolicyName { get; set; } = NmPermissions.Topping.Default;
        protected override string GetListPolicyName { get; set; } = NmPermissions.Topping.Default;
        protected override string CreatePolicyName { get; set; } = NmPermissions.Topping.Create;
        protected override string UpdatePolicyName { get; set; } = NmPermissions.Topping.Update;
        protected override string DeletePolicyName { get; set; } = NmPermissions.Topping.Delete;

        public ToppingAppService(IRepository<Topping, Guid> repository) : base(repository)
        {
        }
    }
}
