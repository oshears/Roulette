using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UIScriptableObject", menuName = "ScriptableObjects/UIScriptableObject")]
public class UIScriptableObject : ScriptableObject
{
	//public string prefabName;

	//public int numberOfPrefabsToCreate;
	//public Vector3[] spawnPoints;

	public UnityEvent rotateGunEvent;
	public UnityEvent increaseBulletCountEvent;
	public UnityEvent shootGunEvent;
	public UnityEvent resetScoresEvent;
	public UnityEvent startGameEvent;
	public UnityEvent drawCardsEvent;
	public UnityEvent<int> playCardEvent;
	public UnityEvent flipCoinButtonClickEvent;
	public UnityEvent<bool> flipCoinDoneEvent;
	public UnityEvent bannerButtonClick;
	public UnityEvent showBannerEvent;
	public UnityEvent drawButtonClick;
	public UnityEvent dismissDrawButton;
	public UnityEvent beginPlayerDrawPhaseEvent;
	public UnityEvent enableHandCardSelection;
	public UnityEvent updateHandCardsEvent;
	public UnityEvent handCardsUpdatedEvent;
	public UnityEvent playedCardsReadyEvent;
	public UnityEvent beginRoulettePhaseEvent;
	// public UnityEvent displayCardBannerEvent;
	public UnityEvent showPlayerCardBannerEvent;
	public UnityEvent playerCardBannerButtonEvent;
	public UnityEvent beginGunPhaseEvent;
	public UnityEvent beginPreGunPhaseEvent;
	public UnityEvent beginPostGunPhaseEvent;
	public UnityEvent endGunPhaseEvent;
	
	public UnityEvent uiReadyEvent;
	
	public String bannerText {get; private set;}
	
	public List<CardSO> cardBannerCards;
	
	public CardSO playerCardBannerCard;
	
	public enum UIStateEnum 
	{
		DebugState,
		BeginGameState,
		CompareCardsState,
		PostGunState,
		PreGunState,
		DrawCardState,
		GunState,
		EndGunState,
		
	}
	
	public UIStateEnum uiState {get; private set;} = UIStateEnum.DebugState; 

	// Card _playerCardSelection;
	int _playerCardSelection;

	public void OnRotateGun()
	{
		rotateGunEvent?.Invoke();
	}

	public void OnIncreaseBulletCount()
	{
		increaseBulletCountEvent?.Invoke();
	}

	public void OnShootGun() => shootGunEvent?.Invoke();
	
	public void OnResetScores() => resetScoresEvent.Invoke();

	public void OnStartGame() => startGameEvent.Invoke();
	
	public void OnDrawCards() => drawCardsEvent.Invoke();
	
	public void OnPlayCard(int index){
		_playerCardSelection = index;
		playCardEvent.Invoke(index);
	}
	
	public void OnFlipCoinButton() => flipCoinButtonClickEvent.Invoke();
	public void OnBannerContinue() => bannerButtonClick.Invoke();
	public void OnShowBanner() => showBannerEvent.Invoke();
	public void OnDrawButton() => drawButtonClick.Invoke();
	public void OnBeginPlayerDrawPhase() => beginPlayerDrawPhaseEvent.Invoke();
	public void SetBannerText(String text) => bannerText = text;

	public void OnEnableCardSelection() => enableHandCardSelection.Invoke();


	public void OnUpdateHandCards()
	{
		updateHandCardsEvent.Invoke();
	}
	
	public int GetPlayerCardSelection()
	{
		return _playerCardSelection;
	}
	
	public void OnCoinFlipDone(bool side)
	{
		flipCoinDoneEvent.Invoke(side);
	}
	
	public void OnHandCardsUpdated()
	{
		handCardsUpdatedEvent.Invoke();
	}
	
	public void ResetCardBanner()
	{
		cardBannerCards.Clear();
	}
	
	public void AddCardBannerCard(CardSO card)
	{
		cardBannerCards.Add(card);
	}
	
	// public void OnUpdateCardBanner()
	// {
	// 	updateCardBannerEvent.Invoke();
	// }
	
	public void OnPlayedCardsReady()
	{
		playedCardsReadyEvent.Invoke();
	}
	
	public void OnBeginRoulettePhase()
	{
		beginRoulettePhaseEvent.Invoke();
	}
	
	public void OnShowPlayerCardBanner(CardSO card, String text)
	{
		playerCardBannerCard = card;
		bannerText = text;
		showPlayerCardBannerEvent.Invoke();
	}
	
	public void OnPlayerCardBannerButton()
	{
		playerCardBannerButtonEvent.Invoke();
	}
	
	
	public void OnBeginPreGunPhase()
	{
		beginPreGunPhaseEvent.Invoke();
	}
	
	public void OnBeginGunPhase()
	{
		beginGunPhaseEvent.Invoke();
	}
	
	public void OnBeginPostGunPhase()
	{
		beginPostGunPhaseEvent.Invoke();
	}
	
	public void OnEndGunPhase()
	{
		endGunPhaseEvent.Invoke();
	}
	
	public void OnUiReady()
	{
		uiReadyEvent.Invoke();
	}
	
	public void SetUiState(UIStateEnum newState)
	{
		uiState = newState;
	}
}