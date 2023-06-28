using Shop.Vek.Assessment.Pages.Modals;
using Shop.Vek.Assessment.Pages.Pages;
using Shop.Vek.Assessment.Steps.Constants;
using Shop.Vek.Assessment.Steps.Models.Request;
using Shop.Vek.Assessment.Steps.Models.View;

namespace Shop.Vek.Assessment.Steps.Steps;

public class NotificationItemModalStep : BaseStep
{
    private readonly NotificationItemModal _notificationItemModal = new NotificationItemModal();

    private readonly ResultPage _resultPage = new ResultPage();

    public T SendNotification<T>() where T : ResultPageStep, new()
    {
        SendNotification();
        _resultPage.WaitForEntityOpened();
        return new T();
    }

    public NotificationItemModalStep SendNotification()
    {
        _notificationItemModal.ClickSendButton();
        return this;
    }

    public NotificationItemErrorFormVm GetErrorFormVm()
    {
        var nameError = _notificationItemModal.NameErrorForm.GetErrorFormMessage();
        var emailError = _notificationItemModal.EmailErrorForm.GetErrorFormMessage();
        var agreementError = _notificationItemModal.AgreementErrorForm.GetErrorFormMessage();

        var errorFormVm = new NotificationItemErrorFormVm(nameError, emailError, agreementError);

        return errorFormVm;
    }

    public NotificationItemModalStep FillAndSubmit(NotificationItemRM notificationItemRm)
    {
        _notificationItemModal.TypeName(notificationItemRm.Name);
        _notificationItemModal.TypeEmail(notificationItemRm.Email);
        _notificationItemModal.AgreementCheckBox.Toggle(notificationItemRm.Agreement);
        SendNotification();
        _notificationItemModal.WaitForEntityOpened();

        return this;
    }

    public LearnAboutAdmissionVM GetLearnAboutAdmissionVm(string expectedText = null)
    {
        var textToWait = expectedText ?? AppMessages.Admission;
        var dialogContent = _notificationItemModal.GetDialogContentLabelText(textToWait).Trim();

        return new LearnAboutAdmissionVM(dialogContent);
    }

    public ResultPageStep CloseNotificationItemModal()
    {
        _notificationItemModal.ClickCloseButton();
        _resultPage.WaitForEntityOpened();

        return new ResultPageStep();
    }
}