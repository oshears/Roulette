public abstract class GameManagerState : IManagerState
{
    protected GameManagerStateMachine _stateMachine;
    protected GameManager _owner;
    protected UIScriptableObject _uiScriptableObject;

    public GameManagerState(GameManager owner)
    {
        _owner = owner;
        _stateMachine = owner.stateMachine;
        _uiScriptableObject = owner.uiScriptableObject;
    }
    public virtual void Enter() {}
    public virtual void Execute() {}
    public virtual void Exit() {}
    protected void changeState(GameManagerState newState)
    {
        _stateMachine.ChangeState(newState);
    }
}