namespace Shop.Vek.Assessment.Steps.Models.Request;

public class SearchRM
{
    public SearchRM(string searchText)
    {
        SearchText = searchText;
    }

    public string SearchText { get; set; }
}