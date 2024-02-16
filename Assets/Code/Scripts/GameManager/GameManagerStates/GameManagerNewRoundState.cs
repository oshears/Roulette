public class GameManagerNewRoundState : GameManagerState
{
	public GameManagerNewRoundState(GameManager owner) : base(owner) { 
		// _uiScriptableObject.drawCardsEvent.AddListener(DrawCardsEventHandler);
		_uiScriptableObject.bannerButtonClick.AddListener(BannerContinueEventHandler);
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
		// Deal two cards to each player and show them to each player
		// _uiScriptableObject.OnDealCards();

		// Wait for all players to select their card choice

		// Go to compare card state
		// _stateMachine.ChangeState(new GameManagerNewRoundState(_owner));
	}

	public override void Exit()
	{
		_uiScriptableObject.bannerButtonClick.RemoveListener(BannerContinueEventHandler);
	}

	void BannerContinueEventHandler()
	{
		_uiScriptableObject.OnBeginPlayerDrawPhase();
		_stateMachine.ChangeState(new GameManagerDrawCardsState(_owner));
	}
	
	
}
