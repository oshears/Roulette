public class GameManagerNewRoundState : GameManagerState
{
	public GameManagerNewRoundState(GameManager owner) : base(owner) { 
		// _uiScriptableObject.drawCardsEvent.AddListener(DrawCardsEventHandler);
		_uiScriptableObject.bannerButtonClick.AddListener(BannerContinueEventHandler);
	}

	override public void Execute() 
	{ 
		// Deal two cards to each player and show them to each player
		// _uiScriptableObject.OnDealCards();

		// Wait for all players to select their card choice

		// Go to compare card state
		// _stateMachine.ChangeState(new GameManagerNewRoundState(_owner));
	}
	
	void BannerContinueEventHandler()
	{
		_uiScriptableObject.OnBeginPlayerDrawPhase();
		_stateMachine.ChangeState(new GameManagerDrawCardsState(_owner));
	}
	
	
}
