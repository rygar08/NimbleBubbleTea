using System;
using Nm.Permissions;
using Nm.Flavours.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Nm.Flavours
{
    public class FlavourAppService : CrudAppService<Flavour, FlavourDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateFlavourDto, CreateUpdateFlavourDto>,
        IFlavourAppService
    {
        protected override string GetPolicyName { get; set; } = NmPermissions.Flavour.Default;
        protected override string GetListPolicyName { get; set; } = NmPermissions.Flavour.Default;
        protected override string CreatePolicyName { get; set; } = NmPermissions.Flavour.Create;
        protected override string UpdatePolicyName { get; set; } = NmPermissions.Flavour.Update;
        protected override string DeletePolicyName { get; set; } = NmPermissions.Flavour.Delete;

        public FlavourAppService(IRepository<Flavour, Guid> repository) : base(repository)
        {
        }
    }
}
