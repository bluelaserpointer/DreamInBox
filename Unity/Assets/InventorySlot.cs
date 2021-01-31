using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image BackgroundImage;
    public GameObject ItemImage;
    public Color UsedAllColor;
    public Color BeforeUsedAllColor;
    public TransformType thisSlotItemTransformType;

    void Start()
    {
        BackgroundImage.color = BeforeUsedAllColor;
        ItemImage.SetActive(false);
    }

    void Update()
    {
        CheckOwn();
        CheckCompletelyUsed();
    }

    private void CheckOwn()
    {
        if (Player.transforms.Contains(thisSlotItemTransformType))
        {
            ItemImage.SetActive(true);
        }
    }

    private void CheckCompletelyUsed()
    {
        if (Player.completelyUsedTransforms.Contains(thisSlotItemTransformType))
        {
            BackgroundImage.color = UsedAllColor;
        }
    }
}
