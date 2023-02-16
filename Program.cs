using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Storage;
using Pulumi.AzureNative.Storage.Inputs;
using System.Collections.Generic;

return await Pulumi.Deployment.RunAsync(() =>
{


    // Export the primary key of the Storage Account
    return new Dictionary<string, object?>
    {
        ["message"] = "Hello World"
    };
});