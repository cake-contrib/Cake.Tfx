# Build Script

In order to make use of the Cake.Tfx Addin, you will need to first use the `#addin` preprocessor to install Cake.Tfx, but once that is done, you can directly use the available aliases.

## TfxExtensionCreate

Due to the way in which vsce works, it is possible to execute the command line utility directly, without any additional settings.  This will simply package the `package.json` file, and output the resulting `vsix` file to the same directory.

```csharp
#addin Cake.Tfx

Task("Create-Extension")
    .Does(() =>
{
    TfxExtensionCreate(new TfxExtensionCreateSettings()
    {
         ManifestGlobs = new List<string>(){ ".\extension-manifest.json" }
    });
});
```