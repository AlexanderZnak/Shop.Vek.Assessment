using OpenQA.Selenium;

namespace Shop.Vek.Assessment.Pages.Locators;

internal static class SearcherLocators
{
    internal static By Search = By.XPath("//*[@id='catalogSearch']");

    internal static By SubmitSearch = By.XPath("//button[contains(@class, 'Search_searchBtn')]");
}