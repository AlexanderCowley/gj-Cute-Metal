using UnityEngine;
using TMPro;

public class DisplayPickUp : MonoBehaviour
{
    ItemPickUp _pickUp;
    MeshRenderer meshRenderer;
    bool _isActive = false;
    void Awake()
    {
        _pickUp = GetComponentInParent<ItemPickUp>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnEnable() => _pickUp.InRangeHandler += ToggleUI;

    void OnDisable() => _pickUp.InRangeHandler -= ToggleUI;

    void ToggleUI() 
    {
        _isActive = !_isActive;
        meshRenderer.enabled = _isActive;
    }
}