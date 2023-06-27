using OpenQA.Selenium;

namespace Shop.Vek.Assessment.Pages.Locators;

public class CookieModuleLocators
{
    internal static By CookieAcceptChild = By.XPath("//*[contains(@class, 'Button-module__blue-primary')]");
    
    internal static By CookieModule = By.XPath("//*[@id='modal-cookie']");
}