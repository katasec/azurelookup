using Pulumi.AzureNative.RecoveryServices.Inputs;
using Pulumi.AzureNative.Resources;
using System.Collections.Generic;
using AzureNative = Pulumi.AzureNative;
using Network = Pulumi.AzureNative.Network;

namespace azurelookup;


public class Handler
{

    public void CreateNic()
    {
        var mySubnetResult = Network.GetSubnet.Invoke(new()
        {
            SubnetName = "blah",
            VirtualNetworkName = "blah",
            ResourceGroupName = "blah"
        });

        var mySubnetId = mySubnetResult.Apply(x => x.Id);

        var networkInterface = new AzureNative.Network.NetworkInterface("networkInterface", new()
        {
            EnableAcceleratedNetworking = true,
            IpConfigurations = new[]
            {
                new AzureNative.Network.Inputs.NetworkInterfaceIPConfigurationArgs
                {
                    Name = "ipconfig1",
                    PublicIPAddress = new AzureNative.Network.Inputs.PublicIPAddressArgs
                    {
                        Id = "/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/publicIPAddresses/test-ip",
                    },
                    Subnet = new AzureNative.Network.Inputs.SubnetArgs
                    {
                        Id = mySubnetId
                    },
                },
            },
            Location = "eastus",
            NetworkInterfaceName = "test-nic",
            ResourceGroupName = "rg1",
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
