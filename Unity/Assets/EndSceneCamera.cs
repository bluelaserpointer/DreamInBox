using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneCamera : MonoBehaviour
{
    private Vector3 distance;
    void Start()
    {
        distance = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
    }

    void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position - distance;
    }
}
