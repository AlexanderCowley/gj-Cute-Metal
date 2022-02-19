using UnityEngine;

public class Rotater : MonoBehaviour
{
    Transform _objectTransform;

    [SerializeField] int _rotateSpeed = 50;
    void Awake() => _objectTransform = GetComponent<Transform>();

    void rotateObject() => _objectTransform.Rotate(Vector3.up *
        _rotateSpeed * Time.deltaTime, Space.Self);

    void Update() => rotateObject();
}