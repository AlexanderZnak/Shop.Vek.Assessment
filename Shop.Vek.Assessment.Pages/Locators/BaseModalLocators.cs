using OpenQA.Selenium;

namespace Shop.Vek.Assessment.Pages.Locators;

internal static class BaseModalLocators
{
    internal static By Close = By.XPath("//*[contains(@class, 'ui-icon-closethick')]");
}