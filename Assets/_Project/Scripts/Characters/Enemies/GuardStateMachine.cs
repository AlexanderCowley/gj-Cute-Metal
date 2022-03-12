using UnityEngine;
using UnityEngine.AI;

public class GuardStateMachine : AbstractStateMachine
{
    [SerializeField] CharacterStats stats;
    CharacterInventory _player;
    NavMeshAgent _navMeshAgent;

    public delegate void OnPlayerDetection();
    public event OnPlayerDetection _playerDetectionHandler;
    bool _playerDetected = false;
    public bool PlayerDetected
    {
        get =>_playerDetected;
        set 
        {
            _playerDetected = value;

            if (_playerDetected == true)
                _playerDetectionHandler?.Invoke();
        } 
    }

    [SerializeField] FieldOfView _fieldDfView;

    [SerializeField] Transform[] guardPoints = new Transform[]{};

    public Transform[] GuardPoints => guardPoints;

    void OnEnable() 
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (GetComponent<GuardPatrolState>() == null)
            ChangeState<GuardIdleState>();

        ChangeState<GuardPatrolState>(); 
    } 
}