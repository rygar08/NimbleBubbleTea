using {{ project }}.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace {{ project }}.Permissions
{
    public class {{ project }}PermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup({{ project }}Permissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission({{ project }}Permissions.MyPermission1, L("Permission:MyPermission1"));

            var teaPermission = myGroup.AddPermission({{ project }}Permissions.Tea.Default, L("Permission:Tea"));
            teaPermission.AddChild({{ project }}Permissions.Tea.Create, L("Permission:Create"));
            teaPermission.AddChild({{ project }}Permissions.Tea.Update, L("Permission:Update"));
            teaPermission.AddChild({{ project }}Permissions.Tea.Delete, L("Permission:Delete"));

            var flavourPermission = myGroup.AddPermission({{ project }}Permissions.Flavour.Default, L("Permission:Flavour"));
            flavourPermission.AddChild({{ project }}Permissions.Flavour.Create, L("Permission:Create"));
            flavourPermission.AddChild({{ project }}Permissions.Flavour.Update, L("Permission:Update"));
            flavourPermission.AddChild({{ project }}Permissions.Flavour.Delete, L("Permission:Delete"));

            var toppingPermission = myGroup.AddPermission({{ project }}Permissions.Topping.Default, L("Permission:Topping"));
            toppingPermission.AddChild({{ project }}Permissions.Topping.Create, L("Permission:Create"));
            toppingPermission.AddChild({{ project }}Permissions.Topping.Update, L("Permission:Update"));
            toppingPermission.AddChild({{ project }}Permissions.Topping.Delete, L("Permission:Delete"));

            var bookingPermission = myGroup.AddPermission({{ project }}Permissions.Booking.Default, L("Permission:Booking"));
            bookingPermission.AddChild({{ project }}Permissions.Booking.Create, L("Permission:Create"));
            bookingPermission.AddChild({{ project }}Permissions.Booking.Update, L("Permission:Update"));
            bookingPermission.AddChild({{ project }}Permissions.Booking.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<{{ project }}Resource>(name);
        }
    }
}
