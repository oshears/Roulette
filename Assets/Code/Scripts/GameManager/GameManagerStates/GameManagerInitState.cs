public class GameManagerInitState : GameManagerState
{
    public GameManagerInitState(GameManager owner) : base(owner) { }

    override public void Execute() 
    { 
        // Reset Player Scores
        _uiScriptableObject.OnResetScores();

        // Go to New Round State
        _stateMachine.ChangeState(new GameManagerNewRoundState(_owner));

    }
    
}