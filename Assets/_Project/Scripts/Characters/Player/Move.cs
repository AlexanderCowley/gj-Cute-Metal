using UnityEngine;

public class Move : MonoBehaviour, IState
{
    PlayerMovementStateMachine _stateMachine;
    CharacterController _characterController;
    Animator _animator;
    [SerializeField] float MovementSpeed;
    float defaultSpeed;

    public void OnStateEntered()
    {
        defaultSpeed = MovementSpeed;
        _stateMachine = GetComponent<PlayerMovementStateMachine>();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _animator.SetBool("IsWalking", true);
    }

    public void OnStateExecute()
    {
        MoveOnInput();
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            _stateMachine.ChangeState<IdleCharacter>();
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

    public void OnStateExit()
    {
        _animator.SetBool("IsWalking", false);
        _characterController = null;
    }
}