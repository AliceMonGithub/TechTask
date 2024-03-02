using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private HealthHookController _healthHookController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out EnemyBehaviour enemy))
        {
            if(enemy.TryGetComponent(out HealthHook hook))
            {
                _healthHookController.SetHooked(hook);
            }
        }
    }
}
