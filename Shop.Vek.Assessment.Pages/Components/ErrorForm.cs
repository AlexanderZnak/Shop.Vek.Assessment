using Selencorator.Elements.Interfaces;

namespace Shop.Vek.Assessment.Pages.Components;

internal class ErrorForm : BaseComponent, IErrorForm
{
    private readonly ILabel _errorLabel;

    public ErrorForm(ILabel errorLabel)
    {
        _errorLabel = errorLabel;
    }

    public string GetErrorFormMessage()
    {
        ConditionalWait.WaitFor(() => !string.IsNullOrEmpty(_errorLabel.GetText()));
        return _errorLabel.GetText();
    }
}