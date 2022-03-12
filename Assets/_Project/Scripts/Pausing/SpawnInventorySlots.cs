using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class SpawnInventorySlots : MonoBehaviour
{
    [SerializeField] GameObject ItemSlotPrefab;

    [SerializeField] float SlotOffset;

    [SerializeField] float SlotRange;
    public void InitInventorySlots(List<ItemData> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject slot = Instantiate(ItemSlotPrefab, this.gameObject.transform, false);
            //add component and data?
        }
    }
}