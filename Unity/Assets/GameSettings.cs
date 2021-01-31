using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings
{
    public static GameSettings instance;

    public static float volume = 0.5f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        volume = 0.5f;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void IncreaseVolume()
    {
        GameSettings.volume = GameSettings.volume + 0.1f > 1.0f ? 1.0f : GameSettings.volume + 0.1f;
    }

    public static void DecreaseVolume()
    {
        GameSettings.volume = GameSettings.volume - 0.1f < 0.0f ? 0.0f : GameSettings.volume - 0.1f;
    }
}
