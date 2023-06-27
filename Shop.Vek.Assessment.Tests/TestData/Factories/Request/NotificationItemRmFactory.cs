using Shop.Vek.Assessment.Steps.Models.Request;

namespace Shop.Vek.Assessment.Tests.TestData.Factories.Request;

internal static class NotificationItemRmFactory
{
    public static readonly NotificationItemRM GetTrueAgreement =
        new NotificationItemRM("John Doe", "JohnDoe@gmail.com", true);
}