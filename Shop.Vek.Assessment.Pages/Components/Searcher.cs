using Selencorator.Elements.Interfaces;
using Shop.Vek.Assessment.Pages.Locators;

namespace Shop.Vek.Assessment.Pages.Components;

internal class Searcher : BaseComponent, ISearcher
{
    public void Search(string searchText)
    {
        SearchInput.SendKeys(searchText);
        SubmitSearchButton.ClickAndWait();
    }

    private ITextBox SearchInput => ElementFactory.GetTextBox(SearcherLocators.Search, "Search input");

    private IButton SubmitSearchButton =>
        ElementFactory.GetButton(SearcherLocators.SubmitSearch, "Search submit button");
}