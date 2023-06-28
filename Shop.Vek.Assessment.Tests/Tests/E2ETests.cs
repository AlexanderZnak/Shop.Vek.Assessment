using FluentAssertions;
using NUnit.Framework;
using Shop.Vek.Assessment.Steps.Constants;
using Shop.Vek.Assessment.Steps.Models.View;
using Shop.Vek.Assessment.Steps.Steps;
using Shop.Vek.Assessment.Tests.TestData.Factories.Request;

namespace Shop.Vek.Assessment.Tests.Tests;

[TestFixture]
public class E2ETests : BaseTest
{
    [Test(Description = "Test 1")]
    [Description(
        "This test validates the functionality of the subscription feature for out-of-stock items on the 21vek.by website.")]
    public void Test_Notification_Subscription_For_Out_Of_Stock_Item()
    {
        // Prepare test data
        var itemRm = ItemRmFactory.GetExistentItemRm;
        var notificationItemRm = NotificationItemRmFactory.GetTrueAgreement;

        // STEP 1 : Navigates to the 'Main' page, search specific item, learn about admission for the item,
        // send notification and get error form details
        var step1 = new MainPageStep()
            .NavigateToMainPage()
            .Search(itemRm)
            .LearnAboutAdmissionFor(itemRm)
            .SendNotification();

        var actualErrorFormVm = step1.GetErrorFormVm();
        var expectedErrorFormVm = new NotificationItemErrorFormVm(
            AppMessages.RequiredErrorInput,
            AppMessages.RequiredErrorInput,
            AppMessages.RequiredErrorAgreement
        );

        // assert that error messages for all required fields were popped up
        actualErrorFormVm.Should().BeEquivalentTo(expectedErrorFormVm);

        // STEP 2 : Fill in notification items form and submit, and get notification message
        var step2 = step1.FillAndSubmit(notificationItemRm);

        var actualAdmissionVm = step2.GetLearnAboutAdmissionVm();
        var expectedAdmissionVm = new LearnAboutAdmissionVM(AppMessages.Admission);

        // assert that email notification message was popped up
        actualAdmissionVm.Should().BeEquivalentTo(expectedAdmissionVm);

        // STEP 3 : Close 'Notification item' modal and get time state details
        var actualItemNotificationStateVm = step2
            .CloseNotificationItemModal()
            .GetItemNotificationStateVm(itemRm);

        var expectedItemNotificationStateVm = new ItemNotificationStateVM(AppMessages.NotificationItemExpectation);

        // assert that item state message was displayed
        actualItemNotificationStateVm.Should().BeEquivalentTo(expectedItemNotificationStateVm);
    }
}