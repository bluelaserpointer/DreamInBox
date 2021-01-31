using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ShowIfEnter : BaseDetector
{
    public List<GameObject> gameObjects;
    public bool inverse;

    public void Start()
    {
        OnTriggerExit();
    }
    public override void OnTriggerEnter()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(!inverse);
        }
    }

    public override void OnTriggerExit()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(inverse);
        }
    }
}
