namespace Shop.Vek.Assessment.Pages.Components;

public interface ICheckBoxForm
{
    bool IsChecked { get; }

    void Check();

    void Uncheck();

    void Toggle(bool setState);
}