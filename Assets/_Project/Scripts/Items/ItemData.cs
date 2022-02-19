using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public delegate void OnValueChanged();
    public event OnValueChanged valueChangedEvent;

    [SerializeField] protected string _Name;

    [SerializeField] protected int _Value;

    [SerializeField] protected int _quantity;

    [SerializeField] protected int _maxQuantity;

    public string ItemName { get => _Name; }

    public int MaxQuantity { get => _maxQuantity; }

    public int ItemValue => _Value;
    public int ItemQuantity
    {
        get => _quantity;
        set
        {
            _quantity = Mathf.Clamp(_quantity, 0, MaxQuantity);
            _quantity = value;
            valueChangedEvent?.Invoke();
        }
    }

    public abstract void UseItem();

    void OnEnable() => _quantity = 0;
}