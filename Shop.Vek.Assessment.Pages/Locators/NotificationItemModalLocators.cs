using OpenQA.Selenium;

namespace Shop.Vek.Assessment.Pages.Locators;

internal static class NotificationItemModalLocators
{
    internal static By Title = By.XPath("//*[@class= 'ui-dialog-title']");
    
    internal static By Close = By.XPath("//*[contains(@class, 'j-popup__close')]");
    
    internal static By Agreement = By.XPath("//*[@id='agreement']");
    
    internal static By Name = By.XPath("//*[@name='data[name]']");
    
    internal static By ErrorFormChild = By.XPath("//ancestor::label//*[@class= 'g-form__message']");
    
    internal static By Email = By.XPath("//*[@name='data[email]']");
    
    internal static By Send = By.XPath("//*[contains(@class, 'ui-dialog-content')]//button[@type='submit']");
    
    internal static By DialogContent = By.XPath("//*[contains(@class, 'g-form__label')]");
}