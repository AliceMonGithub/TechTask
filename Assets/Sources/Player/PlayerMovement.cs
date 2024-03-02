using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public const string HorizontalInput = "Horizontal";
    public const string VerticalInput = "Vertical";

    public const string AttackButton = "Attack";

    public readonly int AttackAnimationHash = Animator.StringToHash("Attack");

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationOffset;

    [Space]

    [SerializeField] private float _attackAnimationDuration;

    [Space]

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;

    [SerializeField] private HealthHook _healthHook;
    [SerializeField] private Weapon _weapon;

    private bool _attacking;

    public HealthHook HealthHook => _healthHook;

    private void Update()
    {
        Move();
        Rotate();
        TryAttack();
    }

    private void Move()
    {
        Vector2 inputAxis = new(Input.GetAxisRaw(HorizontalInput) * _movementSpeed, Input.GetAxisRaw(VerticalInput) * _movementSpeed);

        Vector2 moveAxis = (inputAxis * Time.deltaTime);

        _rigidbody.velocity = moveAxis;
    }

    private void Rotate()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + _rotationOffset));
    }

    private void TryAttack()
    {
        if(Input.GetButtonDown(AttackButton) && _attacking == false)
        {
            _animator.SetTrigger(AttackAnimationHash);

            _weapon.enabled = true;
            _attacking = true;

            Invoke(nameof(AttackFinished), _attackAnimationDuration);
        }
    }

    private void AttackFinished()
    {
        _weapon.enabled = false;
        _attacking = false;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
