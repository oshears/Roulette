using System.Collections.Generic;
using UnityEngine;

public class GameManagerCardCompareState : GameManagerState
{
	
	int _playerCardChoice;
	
	List<CardSO> playedCards;
	
	public GameManagerCardCompareState(GameManager owner) : base(owner) { 
		_uiScriptableObject.flipCoinDoneEvent.AddListener(FlipCoinDoneEventHandler);
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonEventHandler);
		_playerCardChoice = -1;
		playedCards = new List<CardSO>();
	}

	public override void Enter()
	{
		
		if (_playerCardChoice < 0)
		{
			Debug.LogError("ERROR: Player's card choice was not registered successfully!");
		}
		
		// Reset CardBanner
		_uiScriptableObject.ResetCardBanner();
		
		
		// remove card from player's hand
		CardSO playerCard = _playerScriptableObject.PlayCard(_playerCardChoice);
		playedCards.Add(playerCard);
		_uiScriptableObject.AddCardBannerCard(playerCard);
		_deckScriptableObject.OnDiscardCard(playerCard);
		
		// Get a card from each NPC, add it to the card banner, then discard it into the bottom of the deck
		foreach (NpcScriptableObject npc in _npcScriptableObjects)
		{
			CardSO npcCard = npc.PlayCard();
			playedCards.Add(npcCard);
			_uiScriptableObject.AddCardBannerCard(npcCard);
			_deckScriptableObject.OnDiscardCard(npcCard);
		}
		
		_uiScriptableObject.OnPlayedCardsReady();
	}
	override public void Execute() 
	{ 
		

		// Identify the losing player

		// If there is a tie, then let the dealer (house) decide on the loser

	}

	
	void FlipCoinDoneEventHandler(CoinController.Side side)
	{
		// TODO:
		// 1. Determine whether highest or lowest card loses
		// 2. Get all the cards that the players placed
		// 3. Compare the cards that were played
		// 4. In the event of a tie, just choose a random player for now
		// 5. Add the number of bullets to the gun based on the number of bullet cards
		// 6. Proceed to the gun phase!!!
	}
	
	
	
	public void BannerButtonEventHandler()
	{
		changeState(new GameManagerPlayerGunState(_owner));
	}
	
	public void SetPlayerCardChoice(int cardIndex)
	{
		_playerCardChoice = cardIndex;
	}
	
}
