using Selencorator.Core.Elements.Enums;
using Selencorator.Elements.Interfaces;
using Shop.Vek.Assessment.Pages.Components;
using Shop.Vek.Assessment.Pages.Locators;

namespace Shop.Vek.Assessment.Pages.Modals;

public class NotificationItemModal : BaseModal
{
    public NotificationItemModal() : base(NotificationItemModalLocators.Title, nameof(NotificationItemModal))
    {
    }

    public IErrorForm NameErrorForm => new ErrorForm(NameErrorLabel);

    public IErrorForm EmailErrorForm => new ErrorForm(EmailErrorLabel);

    public IErrorForm AgreementErrorForm => new ErrorForm(AgreementErrorLabel);

    public ICheckBoxForm AgreementCheckBox => new CheckBoxForm(AgreementBox);

    public void ClickSendButton()
    {
        SendButton.ClickAndWait();
    }

    public void TypeName(string name)
    {
        NameInput.SendKeys(name);
    }

    public void TypeEmail(string email)
    {
        EmailInput.SendKeys(email);
    }

    public string GetDialogContentLabelText(string? expectedText = null)
    {
        if (expectedText is null)
        {
            ConditionalWait.WaitFor(() => !string.IsNullOrEmpty(DialogContentLabel.GetText()));
        }
        else
        {
            ConditionalWait.WaitFor(() => DialogContentLabel.GetText().Contains(expectedText));
        }

        return DialogContentLabel.GetText();
    }

    public virtual void ClickCloseButton()
    {
        CloseButton.ClickAndWait();
    }

    private ILabel NameErrorLabel => ElementFactory.FindChildElement<ILabel>(
        NameInput,
        NotificationItemModalLocators.ErrorFormChild,
        "Name error label");

    private ILabel EmailErrorLabel => ElementFactory.FindChildElement<ILabel>(
        EmailInput,
        NotificationItemModalLocators.ErrorFormChild,
        "Email error label");

    private ILabel AgreementErrorLabel => ElementFactory.FindChildElement<ILabel>(
        AgreementBox,
        NotificationItemModalLocators.ErrorFormChild,
        "Agreement checkBox's error label");

    private IButton SendButton => ElementFactory.GetButton(NotificationItemModalLocators.Send, "Send button");

    private ICheckBox AgreementBox => ElementFactory.GetCheckBox(
        NotificationItemModalLocators.Agreement,
        "Agreement checkBox",
        ElementState.ExistsInAnyState);

    private ILabel DialogContentLabel => ElementFactory.GetLabel(
        NotificationItemModalLocators.DialogContent,
        "Dialog content label");

    private ITextBox NameInput => ElementFactory.GetTextBox(NotificationItemModalLocators.Name, "Name input");

    private ITextBox EmailInput => ElementFactory.GetTextBox(NotificationItemModalLocators.Email, "Email input");

    protected virtual IButton CloseButton => ElementFactory.GetButton(
        NotificationItemModalLocators.Close,
        "Close button");
}