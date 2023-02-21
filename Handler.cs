using Pulumi.AzureNative.RecoveryServices.Inputs;
using Pulumi.AzureNative.Resources;
using System.Collections.Generic;
using AzureNative = Pulumi.AzureNative;
using Network = Pulumi.AzureNative.Network;

namespace azurelookup;


public class Handler
{
    public static void LookupSubnet()
    {
        var x = Network.GetSubnet.Invoke(new()
        {
            SubnetName = "blah",
            VirtualNetworkName = "blah",
            ResourceGroupName = "blah"
        });
    }
    public static Dictionary<string, object?> Lookup()
    {
        // Setup args for GetResourceGroup function
        var args = new GetResourceGroupInvokeArgs { ResourceGroupName = "rg-ea-azurearc" };

        // Invoke GetResourceGroup function
        var group = GetResourceGroup.Invoke(args, null);

        var group2 = GetResourceGroup.Invoke(new() { 
            ResourceGroupName = "rg-ea-azurearc" 
        }, null);

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
