namespace {{ project }}.Permissions
{
    public static class {{ project }}Permissions
    {
        public const string GroupName = "{{ project }}";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Tea
        {
            public const string Default = GroupName + ".Tea";
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

        public class Booking
        {
            public const string Default = GroupName + ".Booking";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
