public class GameManagerDrawCardsState : GameManagerState
{
	
	int _cardsDrawn = 0;
	public GameManagerDrawCardsState(GameManager owner) : base(owner) { 
		_uiScriptableObject.playCardEvent.AddListener(PlayCardEventHandler);
		_uiScriptableObject.drawButtonClick.AddListener(DrawButtonClickEventHandler);
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
	
	void DrawButtonClickEventHandler()
	{
		_cardsDrawn++;
		
		// if (_cardsDrawn == 0)
		// {
		// 	_stateMachine.ChangeState(new GameManagerCardCompareState(_owner));
		// }
	}
}
