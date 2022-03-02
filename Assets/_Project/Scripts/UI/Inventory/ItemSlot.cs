using UnityEngine;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public ItemData Data {get; private set;}
    TextMeshProUGUI _nameLabel;
    TextMeshProUGUI _quantityLabel;
    void Awake()
    {
        _nameLabel = transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        _quantityLabel = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
    }
    void OnDisable() => Data.valueChangedEvent -= UpdateUIText;

    public void Init(ItemData itemData)
    {
        Data = itemData;
        _nameLabel.text = itemData.ItemName;
        _quantityLabel.text = itemData.ItemQuantity.ToString();

        Data.valueChangedEvent += UpdateUIText;
    }

    void UpdateUIText(ItemData itemData)
    {
        _quantityLabel.text = itemData.ItemQuantity.ToString();
    }
}