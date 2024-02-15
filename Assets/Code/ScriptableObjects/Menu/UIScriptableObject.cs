using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UIScriptableObject", menuName = "ScriptableObjects/UIScriptableObject")]
public class UIScriptableObject : ScriptableObject
{
	//public string prefabName;

	//public int numberOfPrefabsToCreate;
	//public Vector3[] spawnPoints;

	int _rotation = 0;

	public UnityEvent rotateGunEvent;
	public UnityEvent increaseBulletCountEvent;
	public UnityEvent shootGunEvent;
	public UnityEvent resetScoresEvent;
	public UnityEvent startGameEvent;
	public UnityEvent drawCardsEvent;
	public UnityEvent playCardEvent;
	public UnityEvent flipCoinEvent;
	public UnityEvent<Coin.Side> flipCoinDoneEvent;
	public UnityEvent bannerButtonClick;
	public UnityEvent showBannerEvent;
	public UnityEvent drawButtonClick;
	public UnityEvent dismissDrawButton;
	public UnityEvent beginPlayerDrawPhaseEvent;
	public UnityEvent enableHandCardSelection;
	public UnityEvent updateHandCardsEvent;
	
	public String bannerText {get; private set;}

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
		playCardEvent.Invoke();
	}
	
	public void OnFlipCoin() => flipCoinEvent.Invoke();
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
	
	public void OnCoinFlipDone(Coin.Side side)
	{
		flipCoinDoneEvent.Invoke(side);
	}
}