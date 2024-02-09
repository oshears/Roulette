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

		// Go to New Round State
		_stateMachine.ChangeState(new GameManagerNewRoundState(_owner));
	}
	
}