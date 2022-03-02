using UnityEngine;

public class Move : MonoBehaviour
{
    CharacterController _characterController;
    [SerializeField] float MovementSpeed;
    float defaultSpeed;
    void Awake() 
    {
        defaultSpeed = MovementSpeed;
        _characterController = GetComponent<CharacterController>(); 
    }

    void MoveOnInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            MovementSpeed *= 1.5f;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            MovementSpeed = defaultSpeed;

        float xAxis = Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;
        float yAxis = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

        Vector3 moveObject = new Vector3(xAxis, 0, yAxis);

        _characterController.Move(moveObject);
    }

    void Update() => MoveOnInput();
}