using UnityEngine;

public class ItemData : ScriptableObject
{
    public string itemName;

    int quantity;

    public int MaxQuantity;

    public int Quantity
    {
        get
        {
            
            return quantity;
        }
        set
        {
            quantity = Mathf.Clamp(quantity, 0, MaxQuantity);
            quantity = value;

            //Check if quantity is greater than zero
        }
    }
}