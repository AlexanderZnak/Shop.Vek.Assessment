using OpenQA.Selenium;
using Selencorator.BaseWebComponent;
using Selencorator.Elements.Interfaces;
using Shop.Vek.Assessment.Pages.Locators;
using Shop.Vek.Assessment.Pages.Pages;

namespace Shop.Vek.Assessment.Pages.Modals;

public abstract class BaseModal : WebComponent, IWatableEntity
{
    protected BaseModal(By locator, string name) : base(locator, name)
    {
    }

    public virtual void ClickCloseModal()
    {
        CloseIcon.ClickAndWait();
    }

    public virtual void WaitForEntityOpened(TimeSpan? pageLoadTime = null)
    {
        var errorMessage =
            $"'{Name}' was not opened. Unique modal element '{UniquePageElement.Name}' by locator '{UniquePageElement.Locator}' was not found";
        ConditionalWait.WaitForTrue(
            () => State.IsDisplayed,
            message: errorMessage,
            timeout: pageLoadTime);
    }

    protected virtual IButton CloseIcon => ElementFactory.GetButton(BaseModalLocators.Close, "Close icon");
}