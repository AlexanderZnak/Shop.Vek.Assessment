namespace Shop.Vek.Assessment.Steps.Models.View;

public class ItemNotificationStateVM
{
    public ItemNotificationStateVM(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}