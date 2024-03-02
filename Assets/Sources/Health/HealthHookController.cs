using System;
using System.Collections;
using UnityEngine;

public class HealthHookController : MonoBehaviour
{
    public const float TakeDamageTimer = 5f;

    public event Action OnAttack;

    [SerializeField] private Transform _hookedPointer;
    [SerializeField] private SpriteRenderer _hookedPointerSpriteRenderer;
    [SerializeField] private Vector3 _pointerOffset;

    private HealthHook _hooked;

    private float _timer;

    private void Update()
    {
        if (_hooked == null)
        {
            _hookedPointer.gameObject.SetActive(false);

            return;
        }

        TimerTick();

        if(_timer <= 0f)
        {
            TakeDamageToHooked();

            return;
        }

        PointerToTarget();
        SetColorForPointer();
    }

    private void TimerTick()
    {
        _timer -= Time.deltaTime;
    }

    private void PointerToTarget()
    {
        _hookedPointer.gameObject.SetActive(true);

        _hookedPointer.transform.position = _hooked.transform.position + _pointerOffset;
    }

    private void SetColorForPointer()
    {
        Color newColor = _hookedPointerSpriteRenderer.color;

        newColor.a = _timer / TakeDamageTimer;

        _hookedPointerSpriteRenderer.color = newColor;
    }

    public void SetHooked(HealthHook hooked)
    {
        if (hooked == null) throw new NullReferenceException();
        else if(hooked != null && _hooked == null)
        {
            _timer = TakeDamageTimer;
        }

        _hooked = hooked;
    }

    public void TakeDamageToHooked()
    {
        _hooked.Health.TakeDamage();

        _hooked = null;

        OnAttack?.Invoke();
    }
}
