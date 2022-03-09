using UnityEngine;

public class ChangeMeshColor : MonoBehaviour
{
    MeshRenderer _meshRenderer;

    [SerializeField] Color _idleColor;
    [SerializeField] Color _cautionColor;
    [SerializeField] Color _alertColor;

    GuardStateMachine _stateMachine;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = _idleColor;

        _stateMachine = GetComponent<GuardStateMachine>();
    }

    void OnEnable()
    {
        _stateMachine._playerDetectionHandler += ChangeToAlert;
    }

    void ChangeToAlert() => _meshRenderer.material.color = _alertColor;

    void ChangeToCaution() => _meshRenderer.material.color = _cautionColor;

    void ChangeToIdle() => _meshRenderer.material.color = _idleColor;
}