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
	public UnityEvent<bool> setCoinVisibleEvent;
	public UnityEvent bannerButtonClick;
	public UnityEvent showBannerEvent;
	public UnityEvent showDrawButtonEvent;
	public UnityEvent drawButtonClick;
	public UnityEvent dismissDrawButton;
	public UnityEvent beginPlayerDrawPhaseEvent;
	public UnityEvent enableHandCardSelection;
	public UnityEvent updateHandCardsEvent;
	public UnityEvent handCardsUpdatedEvent;
	public UnityEvent playedCardsReadyEvent;
	// public UnityEvent beginRoulettePhaseEvent;
	// public UnityEvent displayCardBannerEvent;
	public UnityEvent showPlayerCardBannerEvent;
	public UnityEvent playerCardBannerButtonEvent;
	public UnityEvent beginGunPhaseEvent;
	public UnityEvent beginPreGunPhaseEvent;
	public UnityEvent beginPostGunPhaseEvent;
	public UnityEvent endGunPhaseEvent;
	
	public UnityEvent uiReadyEvent;
	
	public UnityEvent<bool> playerHandVisibleEvent;
	
	public UnityEvent beginCompareCardPhaseEvent;
	
	public UnityEvent<bool> setCardBannerVisibleEvent;
	
	public UnityEvent passButtonEvent;
	public UnityEvent<bool> passButtonVisibleEvent;
	
	public UnityEvent<bool> shootButtonVisibleEvent;
	
	public UnityEvent shootButtonClickEvent;
	
	public UnityEvent<bool> drawButtonVisibleEvent;
	public UnityEvent<bool> gameOverEvent;
	public UnityEvent<bool> gameOverBannerVisibleEvent;
	
	public UnityEvent playAgainButtonClickEvent;
	public UnityEvent quitButtonClickEvent;
	
	
	public String bannerText {get; private set;}
	
	public List<CardSO> cardBannerCards;
	
	public CardSO playerCardBannerCard;
	
	public bool playerWon {get; private set;} = false;
	
	public enum UIStateEnum 
	{
		InitState,
		DefaultState,
		BeginGameState,
		CompareCardsState,
		PostGunState,
		PreGunState,
		DrawCardState,
		GunState,
		EndGunState,
		
	}
	
	public UIStateEnum uiState {get; private set;} = UIStateEnum.InitState; 

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
	public void OnShowDrawButton() => showDrawButtonEvent.Invoke();
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
	
	// public void OnBeginRoulettePhase()
	// {
	// 	beginRoulettePhaseEvent.Invoke();
	// }
	
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
	
	public void OnSetUiState(UIStateEnum newState)
	{
		uiState = newState;
		uiReadyEvent.Invoke();
	}
	
	public void OnBeginCompareCardPhase()
	{
		beginCompareCardPhaseEvent.Invoke();
	}
	
	public void OnSetPlayerHandVisible(bool visible)
	{
		playerHandVisibleEvent.Invoke(visible);
	}
	
	public void OnSetCoinVisible(bool visible)
	{
		setCoinVisibleEvent.Invoke(visible);		
	}
	
	public void OnSetCardBannerVisible(bool visible)
	{
		setCardBannerVisibleEvent.Invoke(visible);
	}
	
	public void OnPassButtonClick()
	{
		passButtonEvent.Invoke();
	}
	
	public void OnSetPassButtonVisible(bool visible)
	{
		passButtonVisibleEvent.Invoke(visible);
	}
	
	public void OnSetShootButtonVisible(bool visible)
	{
		shootButtonVisibleEvent.Invoke(visible);
	}
	
	public void OnShootButtonClicked()
	{
		shootButtonClickEvent.Invoke();
	}
	
	public void OnDrawButtonVisible(bool visible)
	{
		drawButtonVisibleEvent.Invoke(visible);
	}
	
	public void OnGameOver(bool playerWon)
	{
		this.playerWon = playerWon;
		gameOverEvent.Invoke(playerWon);
	}
	
	public void OnGameOverBannerVisible(bool visible)
	{
		gameOverBannerVisibleEvent.Invoke(visible);
	}
	
	public void OnPlayAgainButtonClick()
	{
		playAgainButtonClickEvent.Invoke();
	}
	
	public void OnQuitButtonClick()
	{
		quitButtonClickEvent.Invoke();
	}
}