using UnityEngine;
using TMPro;

public class DisplayCurrentItem : MonoBehaviour
{
    public ItemData Data { get; private set; }
    TextMeshProUGUI _nameLabel;
    TextMeshProUGUI _quantityLabel;
    [SerializeField] CharacterInventory characterInventory;
    void Awake()
    {
        _nameLabel = transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        _quantityLabel = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
    }
    void Start()
    {
        GetCurrentItem(characterInventory.SelectedItem);
        UpdateText(characterInventory.SelectedItem);
        characterInventory.ChangeItemEventHandler += GetCurrentItem;
    }

    void OnDisable() => characterInventory.ChangeItemEventHandler -= GetCurrentItem;

    void GetCurrentItem(ItemData item)
    {
        item.valueChangedEvent -= UpdateText;
        Data = item;
        Data.valueChangedEvent += UpdateText;
        UpdateText(item);
    }

    void UpdateText(ItemData item)
    {
        _nameLabel.text = item.ItemName;
        _quantityLabel.text = item.ItemQuantity.ToString();
    }
}