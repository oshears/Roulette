using UnityEngine;

public class GameManagerDrawCardsState : GameManagerState
{
	
	int _numCardsDrawn = 0;
	public GameManagerDrawCardsState(GameManager owner) : base(owner) { 
		_uiScriptableObject.playCardEvent.AddListener(PlayCardEventHandler);
		_uiScriptableObject.drawButtonClick.AddListener(DrawButtonClickEventHandler);
		_uiScriptableObject.handCardsUpdatedEvent.AddListener(HandCardsUpdatedEventHandler);
		_playerScriptableObject.playerHandFullEvent.AddListener(PlayerHandFullEventHandler);
	}

	public override void Enter()
	{
		_numCardsDrawn = 0;
		
		// Draw Cards for NPCs
		foreach (NpcScriptableObject npc in _npcScriptableObjects)
		{
			// Draw Two Cards for each NPC
			for (int i = 0; i < 2; i++)
			{
				if (!npc.HasFullHand())
				{
					npc.AddCard(_deckScriptableObject.OnDrawNpcCard());
				}
			}
		}
	}

	override public void Execute() 
	{ 
		// Deal two cards to each player and show them to each player
		// _uiScriptableObject.OnDealCards();

		// Wait for all players to select their card choice

		
		
	}
	
	void PlayCardEventHandler(int cardIndex)
	{
		
		// Go to compare card state
		GameManagerCardCompareState newState = new GameManagerCardCompareState(_owner, cardIndex);
		// newState.SetPlayerCardChoice(cardIndex);
		_stateMachine.ChangeState(newState);
	}
	
	void DrawButtonClickEventHandler()
	{
		_numCardsDrawn++;
		
		CardSO card = _deckScriptableObject.OnDrawCard();
		_playerScriptableObject.AddCard(card);
		_uiScriptableObject.OnUpdateHandCards();
		// if (_cardsDrawn == 0)
		// {
		// 	_stateMachine.ChangeState(new GameManagerCardCompareState(_owner));
		// }
		
	}
	
	public void HandCardsUpdatedEventHandler()
	{
		if (_numCardsDrawn == 2)
		{
			_uiScriptableObject.OnEnableCardSelection();
		}
	}
	
	public void PlayerHandFullEventHandler()
	{
		_uiScriptableObject.OnEnableCardSelection();
	}
	
}
