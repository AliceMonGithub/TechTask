using System;

public class Health
{
    public const int StartHealth = 5;

    public event Action<int> OnChange;

    public int Value { get; private set; }

    public Health(int value)
    {
        Value = value;
    }

    public void TakeDamage()
    {
        Value--;

        OnChange?.Invoke(Value);
    }
}
