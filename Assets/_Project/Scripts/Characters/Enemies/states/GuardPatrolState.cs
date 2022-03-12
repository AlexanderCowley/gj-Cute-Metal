using UnityEngine;
using UnityEngine.AI;

public class GuardPatrolState : MonoBehaviour, IState
{
    GuardStateMachine stateMachine;

    NavMeshAgent _agent;

    float distanceOffset = .25f;
    int guardPointIndex = 0;
    public void OnStateEntered()
    {
        stateMachine = GetComponent<GuardStateMachine>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.autoBraking = false;
        stateMachine._playerDetectionHandler += ChangeToAlertState;
    }

    void GoTo()
    {
        _agent.destination = stateMachine.GuardPoints[guardPointIndex].position;
        guardPointIndex++;
        guardPointIndex = (guardPointIndex + stateMachine.GuardPoints.Length) % stateMachine.GuardPoints.Length;
    }

    bool DistanceBetweenGuardPoint()
    {
        return _agent.remainingDistance < distanceOffset;
    }

    public void OnStateExecute()
    {
        if (!_agent.pathPending && DistanceBetweenGuardPoint())
            GoTo();
    }

    void ChangeToAlertState()
    {
        print("Enter Alert State");
    }

    public void OnStateExit()
    {
        _agent = null;
        guardPointIndex = 0;
        stateMachine._playerDetectionHandler -= ChangeToAlertState;
    }
}