using Selencorator.Elements.Interfaces;

namespace Shop.Vek.Assessment.Pages.Components;

internal class CheckBoxForm : BaseComponent, ICheckBoxForm
{
    private readonly ICheckBox _checkBox;

    public CheckBoxForm(ICheckBox checkBox)
    {
        _checkBox = checkBox;
        CheckBoxElemValidation();
    }

    private void CheckBoxElemValidation()
    {
        if (_checkBox.State.WaitForDisplayed(TimeSpan.FromSeconds(1)))
        {
            var errorMessage =
                "Check box input is displayed, check you element state definition, should be in state 'ExistsInAnyState";
            throw new ArgumentException(errorMessage);
        }
    }

    public bool IsChecked => _checkBox.JsActions.IsChecked();

    public void Check()
    {
        _checkBox.JsActions.Check();
    }

    public void Uncheck()
    {
        _checkBox.JsActions.Uncheck();
    }

    public void Toggle(bool setState)
    {
        if (IsChecked == setState)
        {
            return;
        }

        if (setState)
        {
            Check();
        }
        else
        {
            Uncheck();
        }
    }
}