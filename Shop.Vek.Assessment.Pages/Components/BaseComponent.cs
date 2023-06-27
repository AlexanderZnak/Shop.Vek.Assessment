using Selencorator.Browsers.Services;
using Selencorator.Core.Utilities;
using Selencorator.Core.Waitings;
using Selencorator.Elements.Interfaces;

namespace Shop.Vek.Assessment.Pages.Components;

internal abstract class BaseComponent
{
    protected IElementFactory ElementFactory => ConnectServices.Get<IElementFactory>();

    protected IConditionalWait ConditionalWait => ConnectServices.Get<IConditionalWait>();

    protected IActionRetrier ActionRetrier => ConnectServices.Get<IActionRetrier>();
}