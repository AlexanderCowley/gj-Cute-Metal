using UnityEngine;

public class Move : MonoBehaviour
{
    CharacterController _characterController;
    [SerializeField] float MovementSpeed;
    void Awake() => _characterController = GetComponent<CharacterController>();

    void MoveOnInput()
    {
        float xAxis = Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;
        float yAxis = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

        Vector3 moveObject = new Vector3(xAxis, 0, yAxis);

        object p = _characterController.Move(moveObject);
    }

    void Update() => MoveOnInput();
}