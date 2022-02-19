using UnityEngine;
using System.Collections;

public class ItemPickUp : MonoBehaviour
{
    [Range(1f, 20f)]
    [SerializeField] int QuantityToAdd = 1;

    [SerializeField] ItemData ItemData;

    public delegate void InRange();
    public event InRange InRangeHandler;

    bool _inRange = false;
    void OnTriggerEnter(Collider other)
    {
        //Check for Inventory
        //Add Quantity of Item
        if (!other.GetComponent<Move>()) return;

        InRangeHandler?.Invoke();
        _inRange = true;
    }

    void PickUp()
    {
        print($"Add {ItemData.ItemName} to inventory");
        ItemData.ItemQuantity += QuantityToAdd;
        RemoveItem();
    }

    void RemoveItem()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Move>()) return;

        InRangeHandler?.Invoke();
        _inRange = false;
    }

    void Update()
    {
        if (_inRange && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }
}