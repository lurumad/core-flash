# Core.Flash [![NuGet](https://img.shields.io/nuget/v/Core.Flash.svg)](https://www.nuget.org/packages/Core.Flash/)

Minimalistic flash message system for ASP.NET MVC Core to provide contextual feedback messages between actions based on [Bootstrap Alerts](https://getbootstrap.com/docs/4.0/components/alerts/)

### Install Core.Flash

You should install [Core.Flash](https://www.nuget.org/packages/Core.Flash/):

    Install-Package Core.Flash
    
This command from Package Manager Console will download and install Core.Flash and all required dependencies.

### Meet Core.Flash

Register **Core.Flash** services in your **Startup** class

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services
      .AddFlashes()
      .AddMvc();
}
```
Once you have been register **Core.Flash** services, you can inject the **IFlasher** interface in your Controllers:

```csharp
public HomeController(IFlasher f)
{
    this.f = f;
}
```
And call **Flash** method passing a type and the message:

```csharp
public IActionResult YourAction()
{
    f.Flash(Types.Success, "Flash message system for ASP.NET MVC Core", dismissable: true);
    f.Flash(Types.Danger, "Flash message system for ASP.NET MVC Core", dismissable: false);
    return RedirectToAction("AnotherAction");
}
```
Add **Core.Flash TagHelper** to your **_ViewImports.cs**

```csharp
@using Core.Flash.Web
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@addTagHelper *, Core.Flash
```
Add the TagHelper to your **_Layout.cs**

```html
<div class="container body-content">
    <div flashes></div>
    @RenderBody()
    <hr />
    <footer>
        <p>&copy; 2017</p>
    </footer>
</div>
```

**Core.Flash** uses [Bootstrap Alerts](https://v4-alpha.getbootstrap.com/components/alerts/).

![Sample](https://github.com/lurumad/core-flash/blob/master/assets/flash.gif)

_Copyright &copy; 2017 Lurumad Contributors

