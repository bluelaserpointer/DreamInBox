using UnityEngine;

[DisallowMultipleComponent]
public class MightAppear : MonoBehaviour
{
    [Range(0, 1)]
    public float rate;
    void Start()
    {
        System.Random random = new System.Random();
        gameObject.SetActive(random.NextDouble() < rate);
    }
}
