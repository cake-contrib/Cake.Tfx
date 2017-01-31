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

## TfxExtensionInstall

```csharp
#addin Cake.Tfx

Task("Install-Extension")
    .Does(() =>
{
    TfxExtensionInstall("c:/temp/test.vsix", new List<string>{ "account1" }, new TfxExtensionInstallSettings()
    {
         AuthType = TfxAuthType.Pat,
         Token = "abcdef"
    });
});
```

## TfxExtensionPublish

```csharp
#addin Cake.Tfx

Task("Publish-Extension")
    .Does(() =>
{
    TfxExtensionPublish(new TfxExtensionPublishSettings()
    {
        ManifestGlobs = new List<string>(){ ".\extension-manifest.json" },
        AuthType = TfxAuthType.Pat,
        Token = "abcdef"
    });
});
```

```csharp
#addin Cake.Tfx

Task("Publish-Extension")
    .Does(() =>
{
    TfxExtensionPublish("c:/temp/test.vsix", new List<string>{ "account1" }, new TfxExtensionPublishSettings()
    {
        AuthType = TfxAuthType.Pat,
        Token = "abcdef"
    });
});
```

## TfxExtensionShare

```csharp
#addin Cake.Tfx

Task("Share-Extension")
    .Does(() =>
{
    TfxExtensionShare("c:/temp/test.vsix", new List<string>{ "account1" }, new TfxExtensionShareSettings()
    {
        AuthType = TfxAuthType.Pat,
        Token = "abcdef"
    });
});