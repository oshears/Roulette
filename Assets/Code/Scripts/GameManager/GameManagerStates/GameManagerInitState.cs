public class GameManagerInitState : GameManagerState
{
	public GameManagerInitState(GameManager owner) : base(owner) { 
		_uiScriptableObject.startGameEvent.AddListener(StartGameEventHandler);
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonClickEventHandler);
	}

	public override void Enter()
	{
		
	}

	override public void Execute() 
	{ 
		

	}

	public override void Exit()
	{
		// _uiScriptableObject.startGameEvent.RemoveListener(StartGameEventHandler);
		_uiScriptableObject.startGameEvent.RemoveListener(StartGameEventHandler);
		_uiScriptableObject.bannerButtonClick.RemoveListener(BannerButtonClickEventHandler);
	}

	void StartGameEventHandler()
	{
		// Reset Player Scores
		_uiScriptableObject.OnResetScores();
		
		// Display Game Start
		_uiScriptableObject.SetBannerText("Game Start!");
		_uiScriptableObject.OnShowBanner();
		
		// Empty all cards from player hands
		_playerScriptableObject.InitializePlayer();
		foreach (NpcScriptableObject npc in _npcScriptableObjects)
		{
			npc.InitializePlayer();
		}

		// Initialize Deck
		_deckScriptableObject.OnInitializeDeck();
		
		
	}
	
	void BannerButtonClickEventHandler()
	{
		// Go to New Round State
		_stateMachine.ChangeState(new GameManagerNewRoundState(_owner));
	}
	
}