namespace FlowerRpg.Stats;

public class Vital
{
    public event Action OnValueToMax;
    public event Action OnValueToMin;
    public event Action<float> OnValueChanged;
    
    public IStat MaxValue { get; private set; }
    public float MinValue { get; private set; }
    public float Value { get; private set; }

    public Vital(
        IStat maxValue,
        float minValue,
        float value,
        bool useRatio = false,
        float ratio = 0)
    {
        MaxValue = maxValue;
        MinValue = minValue;

        MaxValue.OnValueChanged += OnMaxValueChanged;

        if (useRatio)
        {
            Value = maxValue.Value * ratio;
            return;
        }
        Value = value;
    }

    public void SetMaxValue(IStat stat)
    {
        MaxValue.OnValueChanged -= OnMaxValueChanged;
        MaxValue = stat;
        MaxValue.OnValueChanged += OnMaxValueChanged;
    }

    public void SetMinValue(float value)
    {
        MinValue = value;
        SetValue(Value);
    }

    private void OnMaxValueChanged(float value)
    {
        SetValueByRatio(value / MaxValue.Value);
    }

    public void SetValueByRatio(float ratio) => SetValue(MaxValue.Value * ratio);

    public void SetValue(float value)
    {
        Value = Math.Clamp(value, MinValue, MaxValue.Value);
        OnValueChanged?.Invoke(Value);
        if (Value.Equals(MaxValue.Value)) OnValueToMax?.Invoke();
        if (Value.Equals(MinValue)) OnValueToMin?.Invoke();
    }

    public void Increase(float value) => SetValue(Value + value);
    
    public void Decrease(float value) => SetValue(Value - value);
    
    public void ResetToMax() => Value = MaxValue.Value;
    
    public void ResetToMin() => Value = MinValue;
}