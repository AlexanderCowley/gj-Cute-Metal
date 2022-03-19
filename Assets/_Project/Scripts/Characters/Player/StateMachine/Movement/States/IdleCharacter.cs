using UnityEngine;

public class IdleCharacter : MonoBehaviour, IState
{
    PlayerMovementStateMachine _stateMachine;
    Animator _animator;
    public void OnStateEntered()
    {
        _stateMachine = GetComponent<PlayerMovementStateMachine>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsIdle", true);
    }

    public void OnStateExecute()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            _stateMachine.ChangeState<MoveCharacter>();
    }

    public void OnStateExit()
    {
        _animator.SetBool("IsIdle", false);
    }
}