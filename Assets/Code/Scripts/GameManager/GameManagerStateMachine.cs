public class GameManagerStateMachine
{
    GameManagerState _currentState;

    public GameManagerStateMachine(GameManager owner)
    {
        _currentState = new GameManagerInitState(owner);
    }

    public void ChangeState(GameManagerState newState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    public void Update()
    {
        if (_currentState != null) _currentState.Execute();
    }
}









