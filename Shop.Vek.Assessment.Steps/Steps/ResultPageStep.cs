using Shop.Vek.Assessment.Pages.Modals;
using Shop.Vek.Assessment.Pages.Pages;
using Shop.Vek.Assessment.Steps.Models.Request;
using Shop.Vek.Assessment.Steps.Models.View;

namespace Shop.Vek.Assessment.Steps.Steps;

public class ResultPageStep : BaseStep
{
    private readonly NotificationItemModal _notificationItemModal = new NotificationItemModal();
    
    private readonly ResultPage _resultPage = new ResultPage();
    
    public NotificationItemModalStep LearnAboutAdmissionFor(ItemRM itemRm)
    {
        _resultPage.ClickOnItemNotification(itemRm.Name);
        _notificationItemModal.WaitForEntityOpened();

        return new NotificationItemModalStep();
    }

    public ItemNotificationStateVM GetItemNotificationStateVm(ItemRM itemRm)
    {
        var message = _resultPage.GetItemNotificationLabelText(itemRm.Name).Trim();
        
        return new ItemNotificationStateVM(message);
    }
}