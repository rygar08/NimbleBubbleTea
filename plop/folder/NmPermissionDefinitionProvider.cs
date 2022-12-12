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

            var bookingPerm = myGroup.AddPermission(Permissions.Booking.Default, L("Permission:Booking"));
            bookingPerm.AddChild(Permissions.Booking.Create, L("Permission:Create"));
            bookingPerm.AddChild(Permissions.Booking.Update, L("Permission:Update"));
            bookingPerm.AddChild(Permissions.Booking.Delete, L("Permission:Delete")); 
            
            var cupSizePerm = myGroup.AddPermission(Permissions.CupSize.Default, L("Permission:CupSize"));
            cupSizePerm.AddChild(Permissions.CupSize.Create, L("Permission:Create"));
            cupSizePerm.AddChild(Permissions.CupSize.Update, L("Permission:Update"));
            cupSizePerm.AddChild(Permissions.CupSize.Delete, L("Permission:Delete")); 
            
            var flavourPerm = myGroup.AddPermission(Permissions.Flavour.Default, L("Permission:Flavour"));
            flavourPerm.AddChild(Permissions.Flavour.Create, L("Permission:Create"));
            flavourPerm.AddChild(Permissions.Flavour.Update, L("Permission:Update"));
            flavourPerm.AddChild(Permissions.Flavour.Delete, L("Permission:Delete")); 
            
            var toppingPerm = myGroup.AddPermission(Permissions.Topping.Default, L("Permission:Topping"));
            toppingPerm.AddChild(Permissions.Topping.Create, L("Permission:Create"));
            toppingPerm.AddChild(Permissions.Topping.Update, L("Permission:Update"));
            toppingPerm.AddChild(Permissions.Topping.Delete, L("Permission:Delete")); 
            
            var teaPerm = myGroup.AddPermission(Permissions.Tea.Default, L("Permission:Tea"));
            teaPerm.AddChild(Permissions.Tea.Create, L("Permission:Create"));
            teaPerm.AddChild(Permissions.Tea.Update, L("Permission:Update"));
            teaPerm.AddChild(Permissions.Tea.Delete, L("Permission:Delete")); 
            

            
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<NmResource>(name);
        }
    }
}
