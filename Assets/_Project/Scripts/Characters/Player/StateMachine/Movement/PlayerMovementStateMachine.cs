using UnityEngine;

public class PlayerMovementStateMachine : AbstractStateMachine
{
    public CharacterStats Stats{get;}

    void OnEnable()
    {
        ChangeState<IdleCharacter>();
    }
}