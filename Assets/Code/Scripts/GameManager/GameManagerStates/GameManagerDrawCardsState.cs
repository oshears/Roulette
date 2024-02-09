public class GameManagerDrawCardsState : GameManagerState
{
	public GameManagerDrawCardsState(GameManager owner) : base(owner) { 
		_uiScriptableObject.playCardEvent.AddListener(PlayCardEventHandler);
	}

	override public void Execute() 
	{ 
		// Deal two cards to each player and show them to each player
		// _uiScriptableObject.OnDealCards();

		// Wait for all players to select their card choice

		
		
	}
	
	void PlayCardEventHandler()
	{
		// Go to compare card state
		_stateMachine.ChangeState(new GameManagerCardCompareState(_owner));
	}
}
