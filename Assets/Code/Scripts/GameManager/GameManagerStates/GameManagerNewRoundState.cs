public class GameManagerNewRoundState : GameManagerState
{
    public GameManagerNewRoundState(GameManager owner) : base(owner) { }

    override public void Execute() 
    { 
        // Deal two cards to each player and show them to each player
        _uiScriptableObject.OnDealCards();

        // Wait for all players to select their card choice

        // Go to compare card state
        _stateMachine.ChangeState(new GameManagerNewRoundState(_owner));
    }
}
