using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeSlider : MonoBehaviour
{
    // private Slider volumeSlider;


    void Start()
    {
        // volumeSlider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        // volumeSlider.value = GameSettings.volume;
        gameObject.GetComponent<Slider>().value = GameSettings.volume;
    }



}
