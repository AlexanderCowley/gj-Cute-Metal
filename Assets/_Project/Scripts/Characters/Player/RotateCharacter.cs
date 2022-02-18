using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    void RotateOnInput()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xAxis, 0, yAxis);

        direction.Normalize();

        if (direction != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 
                RotationSpeed * Time.deltaTime);
        }
    }

    void Update() => RotateOnInput();
}