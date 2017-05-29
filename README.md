# Core.Flash [![NuGet](https://img.shields.io/nuget/v/AspNetCore.Health.svg)](https://www.nuget.org/packages/Core.Flash/)

Minimalistic flash message system for ASP.NET MVC Core.

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
    f.Flash("success", "Flash message system for ASP.NET MVC Core");

    return RedirectToAction("AnotherAction");
}
```

**Core.Flash** uses [Bootstrap Alerts](https://v4-alpha.getbootstrap.com/components/alerts/) so you can pass types like success, info, warning, danger or your custom types.

![Sample](https://github.com/lurumad/core-flash/blob/master/assets/flash.gif)

_Copyright &copy; 2017 Lurumad Contributors

