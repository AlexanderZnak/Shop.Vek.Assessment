using Selencorator.Elements.Interfaces;
using Shop.Vek.Assessment.Pages.Locators;

namespace Shop.Vek.Assessment.Pages.Components;

internal class CookieModule : BaseComponent, ICookieModule
{
    public bool IsEntityOpened => CookieModuleLabel.State.IsDisplayed;

    public void AcceptCookie()
    {
        AcceptButton.ClickAndWait();
    }

    private ILabel CookieModuleLabel => ElementFactory.GetLabel(
        CookieModuleLocators.CookieModule,
        nameof(CookieModule));

    private IButton AcceptButton => ElementFactory.FindChildElement<IButton>(
        CookieModuleLabel,
        CookieModuleLocators.CookieAcceptChild,
        "Cookie accept button");
}