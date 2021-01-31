using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public enum TransformType
{
    [Description("初始")]
    Normal,
    [Description("种子")]
    Seed,
    [Description("手术刀")]
    Scalpel,
    [Description("火把")]
    Torch,
    [Description("绳索")]
    Lope,
    [Description("钥匙")]
    Key,
    [Description("药")]
    Medicine,
}
[DisallowMultipleComponent]
public class TransformItem : MonoBehaviour
{
    public TransformType type;
    // Start is called before the first frame update
    void Start()
    {
        if(Player.transforms.Contains(type))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
