using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter()
    {
        isGrounded = true;
    }

    void OnTriggerStay()
    {
        isGrounded = true;
    }

    void OnTriggerExit()
    {
        isGrounded = false;
    }
}
