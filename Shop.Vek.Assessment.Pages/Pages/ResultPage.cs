using Selencorator.Elements.Interfaces;
using Shop.Vek.Assessment.Pages.Locators;

namespace Shop.Vek.Assessment.Pages.Pages;

public class ResultPage : BasePage
{
    public ResultPage() : base(ResultPageLocators.Header, nameof(ResultPage))
    {
    }

    protected override string UrlPart => "/search/?sa=&term={searchText}";

    private IButton ItemNotificationButton(string item) => ElementFactory.GetButton(
        ResultPageLocators.NotificationItem(item),
        $"Notification button for item '{item}'");

    public void ClickOnItemNotification(string item)
    {
        ItemNotificationButton(item).JsActions.ScrollToCenter();
        ItemNotificationButton(item).ClickAndWait();
    }

    public string GetItemNotificationLabelText(string item)
    {
        ConditionalWait.WaitFor(() => !string.IsNullOrEmpty(ItemNotificationButton(item).GetText()));
        return ItemNotificationButton(item).GetText();
    }
}