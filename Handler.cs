using Pulumi.AzureNative.Resources;
using System.Collections.Generic;

namespace azurelookup;


public class Handler
{
    public static Dictionary<string, object?> Lookup()
    {
        // Setup args for GetResourceGroup function
        var args = new GetResourceGroupInvokeArgs { ResourceGroupName = "rg-ea-azurearc" };

        // Invoke GetResourceGroup function
        var group = GetResourceGroup.Invoke(args, null);

        var group2 = GetResourceGroup.Invoke(new GetResourceGroupInvokeArgs { ResourceGroupName = "rg-ea-azurearc" }, null);

        // Get Resource Group Attributges
        var name = group.Apply(x => x.Name);
        var Id = group.Apply(x => x.Id);

        // Export attributes to view on console
        return new Dictionary<string, object?>
        {
            ["group"] = name,
            ["Id"] = Id,
        };
    }
}
