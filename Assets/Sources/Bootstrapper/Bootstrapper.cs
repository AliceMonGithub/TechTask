using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private MonoBootstrapper[] _bootstrappers;

    private void Awake()
    {
        foreach (MonoBootstrapper bootstrapper in _bootstrappers)
        {
            bootstrapper.Boot();
        }
    }
}
