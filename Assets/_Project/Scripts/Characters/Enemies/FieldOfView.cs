using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] float viewRadius;
    public float ViewRadius => viewRadius;

    [SerializeField, Range(0, 360)] float viewAngle;
    public float ViewAngle => viewAngle;

    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obstacleMask;

    GuardStateMachine _guardSM;

    void Awake()
    {
        _guardSM = GetComponentInParent<GuardStateMachine>();
        GetComponent<SphereCollider>().radius = ViewRadius;
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
            angleInDegrees += transform.eulerAngles.y;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, 
            Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterInventory>() == null)
            return;

        if (FindTarget() == true)
            _guardSM.PlayerDetected = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CharacterInventory>() == null)
            return;
        if (FindTarget() == true)
            _guardSM.PlayerDetected = true;
    }

    void FindTargetsInRange()
    {
        Collider[] targetsInView = Physics.OverlapSphere(transform.position, ViewRadius, targetMask);

        for(int i = 0; i < targetsInView.Length; i++)
        {
            Transform targetTransform = targetsInView[i].transform;
            Vector3 directionToTarget = (targetTransform.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, directionToTarget) < ViewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    //can see player
                }
            }
        }
    }

    public bool FindTarget()
    {
        Collider[] targetsInView = Physics.OverlapSphere(transform.position, ViewRadius, targetMask);

        for (int i = 0; i < targetsInView.Length; i++)
        {
            Transform targetTransform = targetsInView[i].transform;
            Vector3 directionToTarget = (targetTransform.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < ViewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                    return true;
            }
        }

        return false;
    }


}