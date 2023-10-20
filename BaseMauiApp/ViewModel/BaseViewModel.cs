using CommunityToolkit.Mvvm.ComponentModel;

namespace BaseMauiApp.ViewModel;

public class BaseViewModel<TControl> : ObservableObject where TControl : VisualElement
{
    public TControl Control { get; }

    public BaseViewModel(TControl control)
    {
        Control = control;
        Control.Loaded += async (sender, args) => await Loaded(sender, args);
        Control.Unloaded += async (sender, args) => await Unloaded(sender, args);
    }

    protected virtual Task Loaded(object sender, EventArgs args) => Task.CompletedTask;
    protected virtual Task Unloaded(object sender, EventArgs args) => Task.CompletedTask;
}