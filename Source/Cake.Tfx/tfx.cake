#r "Cake.Tfx.dll"

using Cake.Tfx.Extension.Create;

try
{
    TfxExtensionCreate(new TfxExtensionCreateSettings()
    {
         ManifestGlobs = new List<string>(){ "./extension-manifest.json" },
         Root = "C:/github/Organisations/cake-build/cake-vso",
         OutputPath = "C:/github/Organisations/cake-build/cake-vso"
    });
}
catch(Exception ex)
{
    Error("{0}", ex);
}