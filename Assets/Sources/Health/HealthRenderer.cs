using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthRenderer : MonoBootstrapper
{
    [SerializeField] private Image[] _healthPoints;
    [SerializeField] private HealthHook _healthHook;

    [Space]

    [SerializeField] private Color _fullHealthColor;

    public override void Boot()
    {
        _healthHook.Health.OnChange += RenderPoints;
    }

    public void RenderPoints(int value)
    {
        if(value <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            return;
        }

        foreach (var item in _healthPoints)
        {
            item.color = Color.gray;
        }

        for (int i = 0; i < value; i++)
        {
            _healthPoints[i].color = _fullHealthColor;
        }
    }
}
