namespace Shop.Vek.Assessment.Pages.Pages;

public interface IWatableEntity
{
    void WaitForEntityOpened(TimeSpan? pageLoadTime = null);
}