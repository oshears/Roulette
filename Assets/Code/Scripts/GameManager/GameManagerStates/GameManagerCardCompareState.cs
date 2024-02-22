using System.Collections.Generic;
using UnityEngine;

public class GameManagerCardCompareState : GameManagerState
{
	
	int _playerCardChoice;
	
	List<CardSO> playedCards;
	
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	int _numBullets = 1;
	
	bool _tooManyBullets = false;
	
	public GameManagerCardCompareState(GameManager owner, int playerCardChoice) : base(owner) { 
		_uiScriptableObject.flipCoinDoneEvent.AddListener(FlipCoinDoneEventHandler);
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonEventHandler);
		// _uiScriptableObject.uiReadyEvent.AddListener(UiReadyEventHandler);
		
		_playerCardChoice = playerCardChoice;
		playedCards = new List<CardSO>();
		_targetPlayerScriptableObject = null;
		_numBullets = 1;
		
		_tooManyBullets = false;
		
	}

	public override void Enter()
	{
		// _uiScriptableObject.OnBeginCompareCardPhase();
		
		if (_playerCardChoice < 0)
		{
			Debug.LogError("ERROR: Player's card choice was not registered successfully!");
		}
		
		// Reset CardBanner
		_uiScriptableObject.ResetCardBanner();
		
		
		// remove card from player's hand
		Debug.Log($"Player selected card index: {_playerCardChoice}");
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
		_uiScriptableObject.OnSetCardBannerVisible(true);
		
		foreach (CardSO playedCard in playedCards){
			if (playedCard.GetActionType() == CardActionType.Bullet)
			{
				_numBullets++;
			}
		}
		
		if (_numBullets > 5)
		{
			// TODO: Need to implement this functionality to move on to the next round
			Debug.LogError("ERROR! All cards played were bullet cards!!!");
			_tooManyBullets = true;
		}
		
		if (!_tooManyBullets)
		{
			_uiScriptableObject.OnSetCoinVisible(true);
		}
		else
		{
			_uiScriptableObject.SetBannerText("Too many bullet cards were played! Starting new round.");
			_uiScriptableObject.OnShowBanner();
		}
	}
	override public void Execute() 
	{ 
		

		// Identify the losing player

		// If there is a tie, then let the dealer (house) decide on the loser

	}

	public override void Exit()
	{
		Debug.Log("Exiting GameManagerCardCompareState");
		if (_numBullets < 6)
		{
			_gunScriptableObject.SetNumBullets(_numBullets);
			_gunScriptableObject.OnShuffleGun();
		}
		
		_uiScriptableObject.flipCoinDoneEvent.RemoveListener(FlipCoinDoneEventHandler);
		_uiScriptableObject.bannerButtonClick.RemoveListener(BannerButtonEventHandler);
		
		_uiScriptableObject.OnSetCardBannerVisible(false);
		// _uiScriptableObject.uiReadyEvent.RemoveListener(UiReadyEventHandler);
	}
	
	void FlipCoinDoneEventHandler(bool side)
	{
		_uiScriptableObject.SetBannerText(side ? "Lowest number loses!" : "Highest number loses!");
		_uiScriptableObject.OnShowBanner();
		
		Debug.Log("Done Flipping Coin! Determining Loser");
		_uiScriptableObject.OnSetCoinVisible(false);
		
		int lowestCardIndex = 0;
		int highestCardIndex = 0;
		
		
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
			
		}
		
		// 5. Determine whether highest or lowest card loses
		// int loserIndex = (side == CoinController.Side.Heads) ? lowestCardIndex : highestCardIndex;
		int loserIndex = side ? lowestCardIndex : highestCardIndex;
		Debug.Log($"Starting roulette with player: {loserIndex}"); 
		Debug.Log($"Starting roulette with {_numBullets} bullets"); 
		
		_targetPlayerScriptableObject = _playerScriptableObject;
		if (loserIndex > 0)
		{
			_targetPlayerScriptableObject = _npcScriptableObjects[loserIndex - 1];
		}
		
		// 6. Proceed to the gun phase!!!
		
	}
	
	void BannerButtonEventHandler()
	{
		if (_tooManyBullets)
		{
			changeState(new GameManagerDrawCardsState(_owner));
		}
		else
		{
			Debug.Log("Sending Roulette Start Phase!");
			changeState(new GameManagerPreGunState(_owner, _targetPlayerScriptableObject, 0));
		}
	}
	
	public override void OnGUI()
	{
		if (_targetPlayerScriptableObject != null)
		{
			GUILayout.BeginArea(new Rect(0, 500, 500, 500));
			GUILayout.Label($"GameManagerCardCompareState with Target: {_targetPlayerScriptableObject.GetPlayerName()}");
			GUILayout.EndArea();
		}
		else
		{
			GUILayout.BeginArea(new Rect(0, 500, 500, 500));
			GUILayout.Label($"GameManagerCardCompareState with Target: NONE");
			GUILayout.EndArea();
		}
		
	}
	
}
