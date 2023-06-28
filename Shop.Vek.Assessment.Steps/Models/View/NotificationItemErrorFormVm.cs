using Shop.Vek.Assessment.Steps.Models.Request;

namespace Shop.Vek.Assessment.Steps.Models.View;

public class NotificationItemErrorFormVm : INotificationItemRequiredFields<string>
{
    public NotificationItemErrorFormVm(string name, string email, string agreement)
    {
        Name = name;
        Email = email;
        Agreement = agreement;
    }

    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Agreement { get; set; }
}