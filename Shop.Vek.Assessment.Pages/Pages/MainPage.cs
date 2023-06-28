using Shop.Vek.Assessment.Pages.Locators;

namespace Shop.Vek.Assessment.Pages.Pages;

public class MainPage : BasePage
{
    public MainPage() : base(MainPageLocators.MainBanner, nameof(MainPage))
    {
    }

    protected override string UrlPart => string.Empty;
}