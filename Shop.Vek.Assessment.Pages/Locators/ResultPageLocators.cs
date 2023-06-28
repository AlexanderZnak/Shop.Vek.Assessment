using OpenQA.Selenium;

namespace Shop.Vek.Assessment.Pages.Locators;

internal static class ResultPageLocators
{
    internal static By Header = By.XPath("//*[contains(@class, 'content__header')]");

    internal static By NotificationItem(string item) => By.XPath(
        $"//*[contains(text(),\"{item}\")]//ancestor::li[contains(@class, 'result__item')]//descendant::*[@class='item__notification']");
}