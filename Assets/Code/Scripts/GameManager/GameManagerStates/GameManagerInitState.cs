public class GameManagerInitState : GameManagerState
{
	public GameManagerInitState(GameManager owner) : base(owner) { 
		_uiScriptableObject.startGameEvent.AddListener(StartGameEventHandler);
	}

	override public void Execute() 
	{ 
		

	}

	void StartGameEventHandler()
	{
		// Reset Player Scores
		_uiScriptableObject.OnResetScores();
		
		// Display Game Start
		_uiScriptableObject.SetBannerText("Game Start!");
		_uiScriptableObject.OnShowBanner();

		// Initialize Deck
		_deckScriptableObject.OnInitializeDeck();
		
		// Go to New Round State
		_stateMachine.ChangeState(new GameManagerNewRoundState(_owner));
	}
	
}