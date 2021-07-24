using Glamz.Domain.Permissions;

namespace Glamz.Business.Common.Services.Security
{
    public static partial class StandardPermission
    {
        private static string CategoryReport => "Reports";

        public static readonly Permission ManageReports = new Permission
        {
            Name = "Manage Reports",
            SystemName = PermissionSystemName.Reports,
            Area = "Admin area",
            Category = CategoryReport
        };

    }
}
