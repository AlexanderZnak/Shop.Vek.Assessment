using Shop.Vek.Assessment.Pages.Pages;
using Shop.Vek.Assessment.Steps.Models.Request;

namespace Shop.Vek.Assessment.Steps.Steps;

public abstract class BaseStep
{
    private readonly MainPage _mainPage = new MainPage();
    private readonly ResultPage _resultPage = new ResultPage();

    public MainPageStep NavigateToMainPage()
    {
        _mainPage.Open();
        _mainPage.WaitForEntityOpened();
        if (_mainPage.CookieModule.IsEntityOpened)
        {
            _mainPage.CookieModule.AcceptCookie();
        }

        return new MainPageStep();
    }

    public ResultPageStep Search(ItemRM itemRm)
    {
        _mainPage.Searcher.Search(itemRm.Name);
        _resultPage.WaitForEntityOpened();
        return new ResultPageStep();
    }
}