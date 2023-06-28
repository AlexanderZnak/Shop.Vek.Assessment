namespace Shop.Vek.Assessment.Steps.Models.Request;

public class NotificationItemRM : INotificationItemRequiredFields<bool>
{
    public NotificationItemRM(string name, string email, bool agreement)
    {
        Name = name;
        Email = email;
        Agreement = agreement;
    }

    public string Name { get; set; }

    public string Email { get; set; }

    public bool Agreement { get; set; }
}