# Extension Demos

## Demo 0 - Extension example
 - DuoCode: Visual Studio extension that transpiles C# into JavaScript. Uses Roslyn to analyze the code (so they understand even advanced C# 6 features), and then backend emits JavaScript. 
 - Demo RayTrace project. Build it. Show all files - show generated .JS file
 - Open in Edge. F12 dev tools. Show source code mapping so that Edge is debugging C#!

## Demo 1 - VSIX Package
 - Build an empty VSIX
 - Quick walkthrough the manifest
 - Compile and show that it's a ZIP file
 - Install it locally
 - (Rabbit hole?) Open the .csproj and show MSBuild tasks

## Demo 2 - Basic commanding
 - Add new command
 - (Aside) Demonstrate C# 6 extension - expression-bodied members
 - Show the .vsct file - demonstrate hierarchy of items
 - Edit .vsct file to change command name
 - Show the C# file that goes with .vsct file
 - Run and debug - show how experimental instance works
 - Regedit to HKEY_CURRENT_USER\SOFTWARE\Microsoft\VisualStudio

## Demo 3 - Add some functionality
 - Add a reference from Extensions tab to:

   ```
Microsoft.VisualStudio.Editor
Microsoft.VisualStudio.CoreUtility
Microsoft.VisualStudio.Text
Microsoft.VisualStudio.Text.Data
Microsoft.VisualStudio.Text.UI
Microsoft.VisualStudio.Text.UI.Wpf
``` 
 - Add snippet gcvh

 - Add expression-bodied members and method:
 
 ```
   private string GetSelectedTextFromEditor(IWpfTextViewHost viewHost) => 
      viewHost.TextView.Selection.SelectedSpans[0].GetText();
      
   private string GetAllTextFromEditor(IWpfTextViewHost viewHost) =>
      viewHost.TextView.TextSnapshot.GetText();
      
   private string GetCurrentFilename(IWpfTextViewHost viewHost)
   {
      ITextDocument doc;
         
      viewHost.TextView.TextDataModel.DocumentBuffer.Properties.TryGetProperty(typeof(ITextDocument), out doc);
      return doc.FilePath;
   }
```

 - Edit Menu Callback
 - 
 ```
   var viewHost = GetCurrentViewHost();
   var filename = Path.GetFileName(GetCurrentFilename(viewHost));
   var codeToPublish = GetSelectedTextFromEditor(viewHost);
      
   VsShellUtilities.ShowMessageBox(
      this.ServiceProvider,
      codeToPublish,
      filename,
      OLEMSGICON.OLEMSGICON_INFO,
      OLEMSGBUTTON.OLEMSGBUTTON_OK,
      OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
```

## Demo 4 - Hook it up to GitHub
 - NuGet Package Manager for Pierre's GistsApi
 - Add app.config secrets from \code\snippets
 - Add code
 - 
  ```
       var gistClient = new GistsApi.GistClient(Properties.Settings.Default.ClientID,
           Properties.Settings.Default.ClientSecret, "GistsForVisualStudio/1.0");
       var gistFiles = new[] { Tuple.Create(filename, codeToPublish) };
       var result = await gistClient.CreateAGist("test description", true, gistFiles);
```
 - Edit message box to show result.html_url
 - Fix strong naming issue with Nivot. 
 - Copy location of GistsAPI.dll to clipboard and then:

   ```
PM> Install-Package Nivot.StrongNaming
PM> $key = Import-StrongNameKeyPair <Key.snk>
PM> $assembly = Get-Item (<DLL Location>)
PM> Set-StrongName -AssemblyFile $assembly -KeyPair $key
       ```
 - Turn on Fiddler
 - Debug and show auth failure

## Demo 5 - Adding authorization
 - Create a new WPF dialog, explain changes here
 - Add 
 
 ```
<WebBrowser x:Name="webBrowser" LoadCompleted="webBrowser_LoadCompleted" />
```

 - Add to LoadCompleted event handler the snippet lc
 - In MenuItemCallback(), insert the following under gistClient instantiation:

 ```
AuthorizeDialog authDialog = new AuthorizeDialog();
authDialog.webBrowser.Navigate(gistClient.AuthorizeUrl);
authDialog.ShowDialog();
if ((bool)authDialog.DialogResult == true)
{
      await gistClient.Authorize(authDialog.authCode);
```
 - be sure to fix the closing brace

## Demo 6 - Finesse with some dialogs
 - Show finished solution from Gists folder
 - (Uninstall demo extension from experimental instance)
