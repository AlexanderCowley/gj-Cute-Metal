public interface IState
{
    void OnStateEntered();
    void OnStateExecute();
    void OnStateExit();
}