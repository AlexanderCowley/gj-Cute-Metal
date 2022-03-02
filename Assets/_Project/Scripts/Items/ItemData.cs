using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public delegate void OnValueChanged(ItemData itemData);
    public event OnValueChanged valueChangedEvent;
    public event OnValueChanged emptyItemEvent;

    [SerializeField] protected string _Name;

    [SerializeField] protected int _Value;

    [SerializeField] protected int _quantity;

    [SerializeField] protected int _amountPerUse = 1;

    [SerializeField] protected int _maxQuantity;

    public string ItemName { get => _Name; }

    public int MaxQuantity { get => _maxQuantity; }

    public int ItemValue => _Value;
    public int ItemQuantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            _quantity = Mathf.Clamp(_quantity, 0, MaxQuantity);

            if (!HasItem())
            {
                Debug.Log("is zero");
                emptyItemEvent?.Invoke(this);
            }
            else
            {
                Debug.Log("value changed");
                valueChangedEvent?.Invoke(this);
            }

        }
    }

    public virtual void UseItem()
    {
        ItemQuantity -= _amountPerUse;
        ApplyEffects();
    }

    public abstract void ApplyEffects();

    bool HasItem() => ItemQuantity > 0;

    //Remove this later
    void OnEnable() => _quantity = 0;
}