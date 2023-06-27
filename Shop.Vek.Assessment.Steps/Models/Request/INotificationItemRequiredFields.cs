namespace Shop.Vek.Assessment.Steps.Models.Request;

public interface INotificationItemRequiredFields<T>
{
    public string Name { get; set; }

    public string Email { get; set; }

    public T Agreement { get; set; }
}