return await Pulumi.Deployment.RunAsync(() =>
{
    return azurelookup.Handler.Lookup();
});

