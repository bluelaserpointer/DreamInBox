using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightBreath : MonoBehaviour
{
    // Start is called before the first frame update
    private Light pointLight;
    public float lightRotateSpeed = 0.25f;
    void Start()
    {        
        pointLight = GetComponent<Light>();
    }

    private void FixedUpdate() {
        transform.Rotate(Vector3.up, lightRotateSpeed);
    }

}
