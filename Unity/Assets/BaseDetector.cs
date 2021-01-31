using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class BaseDetector : MonoBehaviour
{
    public abstract void OnTriggerEnter();

    public abstract void OnTriggerExit();
}
