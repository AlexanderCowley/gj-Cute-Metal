using UnityEngine;

public class MoveCharacter : MonoBehaviour, IState
{
    PlayerMovementStateMachine _stateMachine;
    CharacterController _characterController;
    Animator _animator;
    [SerializeField] float MovementSpeed;
    float defaultSpeed;
    public void OnStateEntered()
    {
        defaultSpeed = MovementSpeed;
        _characterController = GetComponent<CharacterController>();
        _stateMachine = GetComponent<PlayerMovementStateMachine>();
        _animator = GetComponent<Animator>();

        _animator.SetBool("IsWalking", true);
    }

    public void OnStateExecute()
    {
        CheckInput();
        MoveOnInput();
    }

    void MoveOnInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            MovementSpeed *= 1.5f;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            MovementSpeed = defaultSpeed;

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 moveObject = new Vector3(xAxis, 0, yAxis);

        _characterController.Move(Time.deltaTime * MovementSpeed * moveObject);
    }

    void CheckInput()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            _stateMachine.ChangeState<IdleCharacter>();
    }

    public void OnStateExit()
    {
        _animator.SetBool("IsWalking", false);
    }
}