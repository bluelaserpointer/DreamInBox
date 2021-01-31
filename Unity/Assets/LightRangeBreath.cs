using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRangeBreath : MonoBehaviour
{
    private Light lightSource;
    public float lightRangeMax = 50;
    public float lightRangeMin = 5;
    public float lightBreathOffset = 5;
    public float lightBreathSpeed = 1.5f;
    private bool fadeIn = true;
    private float initLightRange;
    // Start is called before the first frame update
    void Start()
    {
        lightSource = GetComponent<Light>();
        lightSource.range = Random.Range(lightRangeMin, lightRangeMax);
        
        if(lightSource.range > lightRangeMax - lightBreathOffset)
            fadeIn = false;
        else
            fadeIn = true;
    }

    // Update is called once per frame
    private void FixedUpdate() {   
        if(fadeIn)
        {
            lightSource.range = Mathf.Lerp(lightSource.range, lightRangeMax, lightBreathSpeed * Time.deltaTime);
            if(lightSource.range > lightRangeMax - lightBreathOffset)
                fadeIn = false;
        }else{
            lightSource.range = Mathf.Lerp(lightSource.range, lightRangeMin, lightBreathSpeed * Time.deltaTime);
            if(lightSource.range < lightRangeMin + lightBreathOffset)
                fadeIn = true;
        }
        
    }
}
