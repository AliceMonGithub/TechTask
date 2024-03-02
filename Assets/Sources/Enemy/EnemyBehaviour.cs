using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public readonly int AttackHash = Animator.StringToHash("Attack");

    [SerializeField] private float _attackAnimationDuration;

    [Space]

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private HealthHook _healthHook;

    [Space]

    [SerializeField] private HealthHookController _healthHookController;

    private void Awake()
    {
        _healthHookController.OnAttack += StartAnimation;

        StartAnimation();
    }

    private void StartAnimation()
    {
        _animator.SetTrigger(AttackHash);

        InvokeSetPlayerAsHooked();
    }

    private void InvokeSetPlayerAsHooked()
    {
        Invoke(nameof(SetPlayerAsHooked), _attackAnimationDuration);
    }

    private void SetPlayerAsHooked()
    {
        _healthHookController.SetHooked(_playerMovement.HealthHook);
    }
}
