using Nm.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Nm.Permissions
{
    public class NmPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(NmPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(NmPermissions.MyPermission1, L("Permission:MyPermission1"));

            var teaPermission = myGroup.AddPermission(NmPermissions.Tea.Default, L("Permission:Tea"));
            teaPermission.AddChild(NmPermissions.Tea.Create, L("Permission:Create"));
            teaPermission.AddChild(NmPermissions.Tea.Update, L("Permission:Update"));
            teaPermission.AddChild(NmPermissions.Tea.Delete, L("Permission:Delete"));

            var flavourPermission = myGroup.AddPermission(NmPermissions.Flavour.Default, L("Permission:Flavour"));
            flavourPermission.AddChild(NmPermissions.Flavour.Create, L("Permission:Create"));
            flavourPermission.AddChild(NmPermissions.Flavour.Update, L("Permission:Update"));
            flavourPermission.AddChild(NmPermissions.Flavour.Delete, L("Permission:Delete"));

            var toppingPermission = myGroup.AddPermission(NmPermissions.Topping.Default, L("Permission:Topping"));
            toppingPermission.AddChild(NmPermissions.Topping.Create, L("Permission:Create"));
            toppingPermission.AddChild(NmPermissions.Topping.Update, L("Permission:Update"));
            toppingPermission.AddChild(NmPermissions.Topping.Delete, L("Permission:Delete"));

            var bookingPermission = myGroup.AddPermission(NmPermissions.Booking.Default, L("Permission:Booking"));
            bookingPermission.AddChild(NmPermissions.Booking.Create, L("Permission:Create"));
            bookingPermission.AddChild(NmPermissions.Booking.Update, L("Permission:Update"));
            bookingPermission.AddChild(NmPermissions.Booking.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<NmResource>(name);
        }
    }
}
