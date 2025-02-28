// ReSharper disable once CheckNamespace
namespace BD.WTTS.Settings.Abstractions;

public abstract class SettingsPropertyBase
{
    public abstract string PropertyName { get; }

    /// <summary>
    /// 自动保存
    /// </summary>
    public bool AutoSave { get; set; }

    public abstract void RaiseValueChanged(bool notSave = false);

    public abstract void Reset();
}

[DebuggerDisplay("Value={value}, ModelValue={ModelValue}, ModelValueIsNull={ModelValueIsNull}, Default={Default}, PropertyName={PropertyName}, AutoSave={AutoSave}")]
public abstract class SettingsPropertyBase<TValue> : SettingsPropertyBase, INotifyPropertyChanged
{
    /// <summary>
    /// 当前设置的值
    /// </summary>
    protected TValue? value;

    /// <summary>
    /// 获取模型上的值
    /// </summary>
    protected abstract TValue? ModelValue { get; }

    /// <summary>
    /// 获取模型上的值是否为 <see langword="null"/>
    /// </summary>
    protected bool ModelValueIsNull => ModelValue == null;

    /// <summary>
    /// 实际值
    /// </summary>
    protected abstract TValue? ActualValue { get; set; }

    public abstract TValue? Default { get; }

    protected virtual bool Equals(TValue? left, TValue? right)
    {
        return EqualityComparer<TValue>.Default.Equals(left, right);
    }

    public IDisposable Subscribe(Action<TValue?> listener, bool notifyOnInitialValue = true)
    {
        if (notifyOnInitialValue)
            listener(ActualValue);
        return new ValueChangedEventListener(this, listener);
    }

    protected sealed class ValueChangedEventListener : IDisposable
    {
        private readonly Action<TValue?> _listener;
        private readonly SettingsPropertyBase<TValue> _source;

        public ValueChangedEventListener(SettingsPropertyBase<TValue> property, Action<TValue?> listener)
        {
            _listener = listener;
            _source = property;
            _source.ValueChanged += HandleValueChanged;
        }

        private void HandleValueChanged(object? sender, SettingsPropertyValueChangedEventArgs<TValue> args)
        {
            _listener(args.NewValue);
        }

        public void Dispose()
        {
            _source.ValueChanged -= HandleValueChanged;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TValue?(SettingsPropertyBase<TValue> property)
        => property.ActualValue;

    #region events

    public event EventHandler<SettingsPropertyValueChangedEventArgs<TValue>>? ValueChanged;

    protected async void OnValueChanged(TValue? oldValue, TValue? newValue)
    {
        await MainThread2.InvokeOnMainThreadAsync(() =>
        {
            ValueChanged?.Invoke(this, new SettingsPropertyValueChangedEventArgs<TValue>(oldValue, newValue));
        });
    }

    readonly Dictionary<PropertyChangedEventHandler, EventHandler<SettingsPropertyValueChangedEventArgs<TValue>>>
        _handlers = new();

    event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
    {
        add
        {
            if (value == null) return;
            ValueChanged += _handlers[value] = (sender, args) => value(sender, new PropertyChangedEventArgs("Value"));
        }

        remove
        {
            if (value == null) return;
            if (_handlers.TryGetValue(value, out var handler))
            {
                ValueChanged -= handler;
                _handlers.Remove(value);
            }
        }
    }

    #endregion
}