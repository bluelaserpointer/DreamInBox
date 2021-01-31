using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityBreath : MonoBehaviour
{
    private Light lightSource;
    public float lightIntensityMax = 15;
    public float lightIntensityMin = 1;
    public float lightBreathOffset = 1;
    public float lightBreathSpeed = 0.5f;
    private bool fadeIn = true;
    private float initlightIntensity;
    // Start is called before the first frame update
    void Start()
    {
        lightSource = GetComponent<Light>();
        lightSource.intensity = Random.Range(lightIntensityMin, lightIntensityMax);
        
        if(lightSource.intensity > lightIntensityMax - lightBreathOffset)
            fadeIn = false;
        else
            fadeIn = true;
    }

    // Update is called once per frame
    private void FixedUpdate() {   
        if(fadeIn)
        {
            lightSource.intensity = Mathf.Lerp(lightSource.intensity, lightIntensityMax, lightBreathSpeed * Time.deltaTime);
            if(lightSource.intensity > lightIntensityMax - lightBreathOffset)
                fadeIn = false;
        }else{
            lightSource.intensity = Mathf.Lerp(lightSource.intensity, lightIntensityMin, lightBreathSpeed * Time.deltaTime);
            if(lightSource.intensity < lightIntensityMin + lightBreathOffset)
                fadeIn = true;
        }
        
    }
}
