using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    void Awake()
    {
        
    }

    void Use() => itemData.UseItem();
}