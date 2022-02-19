using UnityEngine;

[CreateAssetMenu(menuName = "New ItemType/Healing")]
public class HealingItems : ItemData
{
    public override void UseItem()
    {
        Debug.Log("Use Healing Item");
    }
}