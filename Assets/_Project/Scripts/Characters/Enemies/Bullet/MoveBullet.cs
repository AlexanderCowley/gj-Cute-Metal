using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] int damage;

    IDamagable damagable;

    Vector3 _direction;
    public void Init(Vector3 origin, Vector3 target)
    {
        _direction = (target - origin).normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamagable>() != null)
        {
            damagable = other.GetComponent<IDamagable>();
            damagable?.OnTakeDamage(damage);
            Destroy(this, .25f);
        }
    }

    void Update()
    {
        transform.position += _direction * movementSpeed * Time.deltaTime;
    }
}