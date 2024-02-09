public abstract class UIManagerState : IManagerState
{
    protected UIManagerStateMachine _stateMachine;
    protected UIManager _owner;
    protected UIScriptableObject _uiScriptableObject;

    public UIManagerState(UIManager owner)
    {
        this._owner = owner;
        this._stateMachine = owner.stateMachine;
        this._uiScriptableObject = owner.uiScriptableObject;
    }
    public virtual void Enter() { }
    public virtual void Execute() { }
    public virtual void Exit() { }
    protected void changeState(UIManagerState newState)
    {
        _stateMachine.ChangeState(newState);
    }
}