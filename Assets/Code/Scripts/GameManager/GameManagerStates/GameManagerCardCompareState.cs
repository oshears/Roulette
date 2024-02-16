using System.Collections.Generic;
using UnityEngine;

public class GameManagerCardCompareState : GameManagerState
{
	
	int _playerCardChoice;
	
	List<CardSO> playedCards;
	
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	int _numBullets;
	
	public GameManagerCardCompareState(GameManager owner, int playerCardChoice) : base(owner) { 
		_uiScriptableObject.flipCoinDoneEvent.AddListener(FlipCoinDoneEventHandler);
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonEventHandler);
		_playerCardChoice = playerCardChoice;
		playedCards = new List<CardSO>();
		_targetPlayerScriptableObject = null;
		_numBullets = 0;
	}

	public override void Enter()
	{
		while(_uiScriptableObject.uiState != UIScriptableObject.UIStateEnum.CompareCardsState)
		{
			continue;
		}
		
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

	public override void Exit()
	{
		_gunScriptableObject.SetNumBullets(_numBullets);
		_gunScriptableObject.OnShuffleGun();
		_uiScriptableObject.flipCoinDoneEvent.RemoveListener(FlipCoinDoneEventHandler);
		_uiScriptableObject.bannerButtonClick.RemoveListener(BannerButtonEventHandler);
	}


	void FlipCoinDoneEventHandler(bool side)
	{
		
		Debug.Log("Done Flipping Coin! Determining Loser");
		
		int lowestCardIndex = 0;
		int highestCardIndex = 0;
		
		int numBullets = 1;
		
		// 1. Get all the cards that the players placed
		// 2. Compare the cards that were played
		// 3. In the event of a tie, just choose a random player for now
		// 4. Add the number of bullets to the gun based on the number of bullet cards
		for(int i = 0; i < playedCards.Count; i++)
		{
			CardSO currentCard = playedCards[i];
			if (currentCard.GetValue() < playedCards[lowestCardIndex].GetValue())
			{
				lowestCardIndex = i;
			}
			if (currentCard.GetValue() > playedCards[highestCardIndex].GetValue())
			{
				highestCardIndex = i;
			}
			
			if (currentCard.GetActionType() == CardActionType.Bullet)
			{
				numBullets++;
			}
		}
		
		if (numBullets == 5)
		{
			// TODO: Need to implement this functionality to move on to the next round
			Debug.LogError("ERROR! All cards played were bullet cards!!!");
		}
		
		// 5. Determine whether highest or lowest card loses
		// int loserIndex = (side == CoinController.Side.Heads) ? lowestCardIndex : highestCardIndex;
		int loserIndex = side ? lowestCardIndex : highestCardIndex;
		Debug.Log($"Starting roulette with player: {loserIndex}"); 
		Debug.Log($"Starting roulette with {numBullets} bullets"); 
		
		_targetPlayerScriptableObject = _playerScriptableObject;
		if (loserIndex > 0)
		{
			_targetPlayerScriptableObject = _npcScriptableObjects[loserIndex - 1];
		}
		
		// 6. Proceed to the gun phase!!!
		
	}
	
	
	
	void BannerButtonEventHandler()
	{
		Debug.Log("Sending Roulette Start Phase!");
		_uiScriptableObject.OnBeginRoulettePhase();
		changeState(new GameManagerPreGunState(_owner, _targetPlayerScriptableObject, 0));
	}
	
	void SetPlayerCardChoice(int cardIndex)
	{
		_playerCardChoice = cardIndex;
	}
	
	public override void OnGUI()
	{
		GUILayout.BeginArea(new Rect(10, 10, 500, 500));
		GUILayout.Label($"In CompareCardState!");
		GUILayout.EndArea();
	}
	
}
