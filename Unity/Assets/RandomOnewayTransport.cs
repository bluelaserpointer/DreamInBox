using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class RandomOnewayTransport : TransportSpot
{
    [Serializable]
    public struct DstAndWeight
    {
        public string sceneName;
        public int weight;
    }
    [Header(">>>去往与概率(上面的父类变量无效)")]
    public List<DstAndWeight> dstsAndWeight;

    private int totalWeight;

    private void Awake()
    {
        base.gotoScene = "Random";
        dstsAndWeight.ForEach(pair => totalWeight += pair.weight);
    }
    public override void Transport()
    {
        int randomNum = UnityEngine.Random.Range(0, totalWeight);
        foreach(var pair in dstsAndWeight)
        {
            if((randomNum -= pair.weight) < 0)
            {
                SceneManager.LoadScene(pair.sceneName);
            }
        }
    }
}
