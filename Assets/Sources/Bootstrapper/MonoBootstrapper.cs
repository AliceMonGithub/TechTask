using UnityEngine;

public abstract class MonoBootstrapper : MonoBehaviour, IBootstrapper
{
    public abstract void Boot();
}
