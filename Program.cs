using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Storage;
using Pulumi.AzureNative.Storage.Inputs;
using System.Collections.Generic;

return await Pulumi.Deployment.RunAsync(() =>
{

    // Setup args for GetResourceGroup function
    var args = new GetResourceGroupInvokeArgs { ResourceGroupName = "rg-ea-azurearc" };

    // Invoke GetResourceGroup function
    var group = GetResourceGroup.Invoke(args,null);

    // Get Resource Group Attributges
    var name = group.Apply(x => x.Name);
    var Id = group.Apply(x => x.Id);
    
    // Export attributes to view on console
    return new Dictionary<string, object?>
    {
        ["group"] =  name,
        ["Id"] = Id,
    };
});