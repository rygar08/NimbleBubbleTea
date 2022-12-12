namespace Nm.Permissions
{
    public static class NmPermissions
    {
        public const string GroupName = "Nm";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Booking
        {
            public const string Default = GroupName + ".Booking";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class CupSize
        {
            public const string Default = GroupName + ".CupSize";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class Flavour
        {
            public const string Default = GroupName + ".Flavour";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class Topping
        {
            public const string Default = GroupName + ".Topping";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
        public class Tea
        {
            public const string Default = GroupName + ".Tea";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
