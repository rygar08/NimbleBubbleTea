using System;
using Nm.Permissions;
using Nm.Teas.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Nm.Teas
{
    public class TeaAppService : CrudAppService<Tea, TeaDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTeaDto, CreateUpdateTeaDto>,
        ITeaAppService
    {
        protected override string GetPolicyName { get; set; } = NmPermissions.Tea.Default;
        protected override string GetListPolicyName { get; set; } = NmPermissions.Tea.Default;
        protected override string CreatePolicyName { get; set; } = NmPermissions.Tea.Create;
        protected override string UpdatePolicyName { get; set; } = NmPermissions.Tea.Update;
        protected override string DeletePolicyName { get; set; } = NmPermissions.Tea.Delete;

        public TeaAppService(IRepository<Tea, Guid> repository) : base(repository)
        {
        }
    }
}
