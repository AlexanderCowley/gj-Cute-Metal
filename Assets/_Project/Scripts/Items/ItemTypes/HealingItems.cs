using UnityEngine;

[CreateAssetMenu(menuName = "New ItemType/Healing")]
public class HealingItems : ItemData
{
    public override void ApplyEffects()
    {
        Debug.Log("Heal");
    }
}