using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Selencorator.Browsers;
using Selencorator.Browsers.Services;

namespace Shop.Vek.Assessment.Tests.Utilities;

internal static class ScreenshotAttacher
{
    private static Browser Browser => ConnectServices.Browser;

    internal static string UniqueFileName =>
        $"{TestContext.CurrentContext.Test.MethodName}_{DateTime.Now:dd-MM-yyyy_HH-mm}.png";

    internal static void AttachScreenshotToTestResults(string fullPathToSaveScreenshot,
        string screenshotName = null)
    {
        screenshotName ??= UniqueFileName;
        var fileFullPath = Path.Combine(fullPathToSaveScreenshot, screenshotName);
        Browser.SaveScreenshot(fileFullPath);
        TestContext.AddTestAttachment(fileFullPath, screenshotName);
    }

    internal static void AttachScreenshotOnFailedToTestResults()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            AttachScreenshotToTestResults(DirectoryBuilder.AttachmentsOnFailureDirectoryPath);
        }
    }
}