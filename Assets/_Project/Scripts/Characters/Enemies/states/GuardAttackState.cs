using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GuardAttackState : MonoBehaviour, IState
{
    [SerializeField] Transform targetTransform;

    [SerializeField] Transform gunTransform;

    [SerializeField] GameObject _bullet;

    [SerializeField] float attackRange;
    [SerializeField] float fireRate;
    float timeSinceLastShot;

    GuardStateMachine stateMachine;
    NavMeshAgent _agent;
    public void OnStateEntered()
    {
        stateMachine = GetComponent<GuardStateMachine>();
        _agent = GetComponent<NavMeshAgent>();
    }

    bool DistanceAwayFromPlayer()
    {
        float distance = Vector3.Distance(targetTransform.position, transform.position);
        return distance > attackRange;
    }

    void Attack()
    {
        if (!_agent.pathPending)
        {
            if (DistanceAwayFromPlayer())
            {
                stateMachine.ChangeState<GuardChaseState>();
            }
        }

        if(Time.time > timeSinceLastShot)
        {
            timeSinceLastShot = Time.time + fireRate / 1000;
            Vector3 direction = gunTransform.position - targetTransform.position;
            GameObject temp = Instantiate(_bullet, gunTransform.position, Quaternion.identity);
            temp.GetComponent<MoveBullet>().Init(gunTransform.position, targetTransform.position);
        }
    }

    public void OnStateExecute()
    {
        Attack();
    }

    public void OnStateExit()
    {
        
    }
}