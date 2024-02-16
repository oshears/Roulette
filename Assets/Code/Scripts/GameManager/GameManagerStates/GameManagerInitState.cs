public class GameManagerInitState : GameManagerState
{
	public GameManagerInitState(GameManager owner) : base(owner) { 
		_uiScriptableObject.startGameEvent.AddListener(StartGameEventHandler);
	}

    public override void Enter()
    {
        while(_uiScriptableObject.uiState != UIScriptableObject.UIStateEnum.BeginGameState)
		{
			continue;
		}
    }

    override public void Execute() 
	{ 
		

	}

	public override void Exit()
	{
		_uiScriptableObject.startGameEvent.RemoveListener(StartGameEventHandler);
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
		
		// Go to New Round State
		_stateMachine.ChangeState(new GameManagerNewRoundState(_owner));
	}
	
}