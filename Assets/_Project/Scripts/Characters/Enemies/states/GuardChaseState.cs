using UnityEngine;
using UnityEngine.AI;

public class GuardChaseState : MonoBehaviour, IState
{
    [SerializeField] Transform targetTransform;

    [SerializeField] float attackRange;

    GuardStateMachine stateMachine;
    NavMeshAgent _agent;
    public void OnStateEntered()
    {
        stateMachine = GetComponent<GuardStateMachine>();
        _agent = GetComponent<NavMeshAgent>();
    }

    bool DistanceBetweenPlayer()
    {
        float distance = Vector3.Distance(targetTransform.position, transform.position);
        return distance < attackRange;
    }

    public void OnStateExecute()
    {
        if (!_agent.pathPending)
        {
            _agent.destination = targetTransform.position;
            if (DistanceBetweenPlayer())
                stateMachine.ChangeState<GuardAttackState>();
        }
    }

    public void OnStateExit()
    {
        _agent = null;
    }
}