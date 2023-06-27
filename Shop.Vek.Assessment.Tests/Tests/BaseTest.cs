using NUnit.Framework;
using Selencorator.Browsers;
using Selencorator.Browsers.Services;
using Shop.Vek.Assessment.Tests.Utilities;

namespace Shop.Vek.Assessment.Tests.Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BaseTest
{
    /// <summary>
    /// Only one BeforeTest should be provide across the system
    /// Override in case if logic is needed to be changed
    /// </summary>
    [SetUp]
    public virtual void BeforeTest()
    {
        // Implement logic
    }

    /// <summary>
    /// Only one AfterTest should be provide across the system
    /// Override in case if logic is needed to be changed
    /// </summary>
    [TearDown]
    public virtual void AfterTest()
    {
        if (ConnectServices.IsBrowserStarted)
        {
            ScreenshotAttacher.AttachScreenshotOnFailedToTestResults();
            Browser.Quit();
        }
    }

    private Browser Browser => ConnectServices.Browser;
}