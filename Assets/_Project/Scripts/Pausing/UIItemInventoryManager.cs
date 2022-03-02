using UnityEngine;
using System.Collections.Generic;

public class UIItemInventoryManager : MonoBehaviour
{
    [SerializeField] GameObject ItemSlotPrefab;

    //Store Seperatly Later as a List
    [SerializeField] List<ItemSlot> _itemSlots = new List<ItemSlot>();
    //Then it wont need this either
    [SerializeField] CharacterInventory characterInventory;

    [SerializeField] PauseData pauseData;

    //[SerializeField] float SlotOffset = 50;

    [SerializeField] float SlotSize;

    [SerializeField] float xCoordinates, yCoordinates;

    List<Vector3> GridCoordinates = new List<Vector3>();

    int gridIndex = 0;

    void OnEnable()
    {
        InitInventorySlots(characterInventory.AvailableItems());
    }

    void OnDisable()
    {
        pauseData.PauseEventHandler -= CheckAvailableItems;
        ClearInventorySlots();
    }

    void CheckAvailableItems()
    {
        //Subscribe to value changed to add slot item

        //within inventory create a bool method to check if quantity is greater than zero.
        //than add that to the list

        //list will later have an event run whenever another item is entered
        //Add item slot whenever that event is called

        //if (characterInventory.AvailableItems().Count == _itemSlots.Count)
            //return;

    }

    public void InitInventorySlots(List<ItemData> items)
    {
        InitGridCoordinates();

        for (int i = 0; i < items.Count; i++)
            AddItemSlot(items[i]);

        for (int i = 0; i < characterInventory.Items.Count; i++)
            characterInventory.Items[i].valueChangedEvent += AddItemSlot;

        pauseData.PauseEventHandler += CheckAvailableItems;
    }


    void InitGridCoordinates()
    {
        Vector3 result = this.transform.position;

        for (int rows = 0; rows < xCoordinates; rows++)
        {
            for (int columns = 0; columns < yCoordinates; columns++)
            {
                float xAxis = (columns * SlotSize);
                float yAxis = (rows * -SlotSize);
                Vector3 coordinates = new Vector3(xAxis, 0, yAxis);
                result += coordinates;
                GridCoordinates.Add(result);
            }
        }
    }

    void AddItemSlot(ItemData itemData)
    {
        GameObject slot = Instantiate(ItemSlotPrefab, this.transform, false);
        _itemSlots.Add(slot.GetComponent<ItemSlot>());
        slot.transform.position = GridCoordinates[gridIndex];
        gridIndex++;
        print(GridCoordinates[0]);

        slot.GetComponent<ItemSlot>().Init(itemData);
        itemData.valueChangedEvent -= AddItemSlot;
    }

    void RemoveItemSlot(ItemSlot itemSlot)
    {
        int index = _itemSlots.IndexOf(itemSlot);
        _itemSlots[index].Data.valueChangedEvent -= AddItemSlot;
        Destroy(_itemSlots[index], .2f);
    }

    void ClearInventorySlots()
    {
        for(int i = _itemSlots.Count -1; i >= 0; i--)
        {
            RemoveItemSlot(_itemSlots[i]);
            _itemSlots.RemoveAt(i);
        }

        _itemSlots.Clear();
    }
}