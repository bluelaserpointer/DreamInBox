using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Object rotates around this axis")]
    public Vector3 rotateAxis;
    public float rotateSpeed;
    public float anglePerFrame;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

        targetRotation = Quaternion.AngleAxis(anglePerFrame, rotateAxis) * transform.rotation;
    }
}
