using UnityEngine;
using System.Collections.Generic;
public class CharacterInventory : MonoBehaviour
{
    [SerializeField] List<ItemData> items = new List<ItemData>();
    public List<ItemData> Items => items;

    public delegate void ChangeItem(ItemData item);
    public event ChangeItem ChangeItemEventHandler;

    [SerializeField] ItemData selectedItem;

    public ItemData SelectedItem 
    { 
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            ChangeItemEventHandler?.Invoke(selectedItem);
        }
    }

    int index = 0;
    void Awake() => SelectedItem = Items[0];

    public List<ItemData> AvailableItems()
    {
        List<ItemData> filteredItems = new List<ItemData>();

        filteredItems.Add(items[0]);

        for (int i = items.Count -1; i >= 0; i--)
        {
            if (items[i].ItemQuantity <= 0)
                continue;

            filteredItems.Add(items[i]);
        }
        return filteredItems;
    }

    void NextItem()
    {
        index++;
        index = (index + AvailableItems().Count) % AvailableItems().Count;
        SelectedItem = AvailableItems()[index];
    }

    void UseCurrentItem() => selectedItem.UseItem();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            UseCurrentItem();

        if (Input.GetKeyDown(KeyCode.Tab))
            NextItem();
    }
}