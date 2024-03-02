using UnityEngine;

public class HealthHook : MonoBootstrapper
{
    private Health _health;

    public Health Health => _health;

    public override void Boot()
    {
        _health = new(Health.StartHealth);
    }
}
