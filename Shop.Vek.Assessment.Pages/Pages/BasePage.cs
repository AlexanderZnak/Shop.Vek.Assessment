using OpenQA.Selenium;
using Selencorator.BaseWebComponent;
using Selencorator.Browsers.Services;
using Selencorator.Configurations.TimeConfigurations;
using Selencorator.Core.Utilities;
using Shop.Vek.Assessment.Pages.Components;

namespace Shop.Vek.Assessment.Pages.Pages;

public abstract class BasePage : WebComponent, IWatableEntity
{
    private readonly TimeSpan _pageLoadTime;

    protected BasePage(By locator, string name) : base(locator, name)
    {
        _pageLoadTime = ConnectServices.Get<ITimeoutConfiguration>().PageLoad;
    }

    private string BaseUrl => SettingsFile.GetValueOrThrowException<string>("webAppUrl");

    private ISettingsFile SettingsFile => ConnectServices.Get<ISettingsFile>();

    public ISearcher Searcher => new Searcher();
    
    public ICookieModule CookieModule => new CookieModule();

    protected abstract string UrlPart { get; }

    public Uri Url => new Uri(BaseUrl.TrimEnd('/') + "/" + UrlPart.TrimStart('/'));

    public virtual void Open()
    {
        Browser.GoTo(Url);
    }

    public virtual void WaitForEntityOpened(TimeSpan? pageLoadTime = null)
    {
        pageLoadTime ??= _pageLoadTime;
        var errorMessage =
            $"'{Name}' was not opened. Unique page element '{UniquePageElement.Name}' by locator '{UniquePageElement.Locator}' was not found";
        ConditionalWait.WaitForTrue(
            () => State.IsDisplayed,
            message: errorMessage,
            timeout: pageLoadTime);
    }

    public virtual bool IsEntityOpened => ConditionalWait.WaitFor(() => State.IsDisplayed);
}