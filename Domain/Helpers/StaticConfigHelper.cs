// Option: Domain/Helpers/StaticConfigHelper.cs (if Domain can reference Microsoft.Extensions.Configuration)
using System.Collections.Generic;

public static class StaticConfigHelper
{
    // This should be initialized at startup from IConfiguration
    public static List<string> SiteAdmins { get; private set; } = new List<string>();

    public static void Initialize(IEnumerable<string> admins)
    {
        SiteAdmins = new List<string>(admins ?? new string[0]);
    }

    public static List<string> GetSiteAdmins() => new List<string>(SiteAdmins);
}
