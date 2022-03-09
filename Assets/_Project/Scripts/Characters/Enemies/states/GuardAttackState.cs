using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GuardAttackState : MonoBehaviour, IState
{
    [SerializeField] Transform targetTransform;

    [SerializeField] Transform gunTransform;

    [SerializeField] float attackRange;
    [SerializeField] float fireRate;

    [SerializeField] float fireRateRadius;

    int _damage = 3;

    float timeSinceLastShot;

    GuardStateMachine _stateMachine;
    NavMeshAgent _agent;
    public void OnStateEntered()
    {
        _stateMachine = GetComponent<GuardStateMachine>();
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
                _stateMachine.ChangeState<GuardChaseState>();
            }
            //Subscribe Fire Bullet with player spotted?
            if (Time.time > timeSinceLastShot && _stateMachine.PlayerDetected)
                FireBullet();
        }


    }

    void FireBullet()
    {
        timeSinceLastShot = Time.time + fireRate / 1000;
        print("attack");
        RaycastHit hit;
        if(Physics.SphereCast(gunTransform.position, fireRateRadius, transform.forward, out hit))
        {
            IDamagable damagableData;
            hit.transform.TryGetComponent<IDamagable>(out damagableData);

            damagableData?.OnTakeDamage(_damage);
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