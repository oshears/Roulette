using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerDefaultState : UIManagerState
{
	public UIManagerDefaultState(UIManager owner) : base(owner) { 
		
		_uiScriptableObject.playedCardsReadyEvent.AddListener(PlayedCardsReadyEventHandler);

		_uiScriptableObject.setCoinVisibleEvent.AddListener(SetCoinVisibleEventHandler);
		_uiScriptableObject.flipCoinButtonClickEvent.AddListener(FlipCoinButtonEventHandler);
		_uiScriptableObject.flipCoinDoneEvent.AddListener(FlipCoinDoneEventHandler);

		_uiScriptableObject.showDrawButtonEvent.AddListener(ShowDrawButtonEventHandler);
		// _uiScriptableObject.drawButtonClick.AddListener(DrawButtonClickEventHandler);
		// _uiScriptableObject.updateHandCardsEvent.RemoveListener(UpdateHandCardsEventHandler);
		_uiScriptableObject.playerHandVisibleEvent.AddListener(SetPlayerHandVisibleEventHandler);
		
		_playerScriptableObject.playerHandFullEvent.AddListener(PlayerHandFullEventHandler);

		_uiScriptableObject.showBannerEvent.AddListener(ShowBannerEventHandler);
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonClickEventHandler);
		
		_uiScriptableObject.showPlayerCardBannerEvent.AddListener(ShowPlayerCardBannerEventHandler);
		_uiScriptableObject.playerCardBannerButtonEvent.AddListener(PlayerCardBannerButtonEventHandler);
		
		_uiScriptableObject.enableHandCardSelection.AddListener(EnableCardHandSelectionHandler);
		
		_uiScriptableObject.passButtonVisibleEvent.AddListener(SetPassButtonVisibleEventHandler);
		
		_uiScriptableObject.shootButtonVisibleEvent.AddListener(SetPassButtonVisibleEventHandler);
		
		// _uiScriptableObject.beginPreGunPhaseEvent.AddListener(BeginPreGunPhaseEventHandler);
		// _uiScriptableObject.beginPlayerDrawPhaseEvent.AddListener(BeginPlayerDrawPhaseEventHandler);
		// _uiScriptableObject.beginCompareCardPhaseEvent.AddListener(BeginComparePhaseEventHandler);
		// _uiScriptableObject.beginPreGunPhaseEvent.AddListener(BeginPreGunPhaseEventHandler);
		// _uiScriptableObject.beginGunPhaseEvent.AddListener(BeginGunPhaseEventHandler);
	}

	public override void Enter()
	{
		// _uiScriptableObject.OnSetUiState(UIScriptableObject.UIStateEnum.DefaultState);
		
		// _numCardsDrawn = 0;
		// _owner.SetDrawButtonActive(true);
		// _owner.SetPlayerCardHandActive(true);
		// _uiScriptableObject.OnSetUiState(UIScriptableObject.UIStateEnum.DrawCardState);
	}


	public override void Execute()
	{
		GUILayout.BeginArea(new Rect(0, 1000, 500, 500));
		GUILayout.Label($"Current GameManagerState: {this}");
		GUILayout.EndArea();
	}

	public override void Exit()
	{
		_uiScriptableObject.playedCardsReadyEvent.RemoveListener(PlayedCardsReadyEventHandler);

		_uiScriptableObject.setCoinVisibleEvent.RemoveListener(SetCoinVisibleEventHandler);
		_uiScriptableObject.flipCoinButtonClickEvent.RemoveListener(FlipCoinButtonEventHandler);
		_uiScriptableObject.flipCoinDoneEvent.RemoveListener(FlipCoinDoneEventHandler);

		_uiScriptableObject.showDrawButtonEvent.RemoveListener(ShowDrawButtonEventHandler);
		// _uiScriptableObject.drawButtonClick.RemoveListener(DrawButtonClickEventHandler);
		// _uiScriptableObject.updateHandCardsEvent.RemoveListener(UpdateHandCardsEventHandler);
		
		_playerScriptableObject.playerHandFullEvent.RemoveListener(PlayerHandFullEventHandler);
		_uiScriptableObject.playerHandVisibleEvent.AddListener(SetPlayerHandVisibleEventHandler);

		_uiScriptableObject.showBannerEvent.RemoveListener(ShowBannerEventHandler);
		_uiScriptableObject.bannerButtonClick.RemoveListener(BannerButtonClickEventHandler);
		
		_uiScriptableObject.showPlayerCardBannerEvent.RemoveListener(ShowPlayerCardBannerEventHandler);
		_uiScriptableObject.playerCardBannerButtonEvent.RemoveListener(PlayerCardBannerButtonEventHandler);
		
		_uiScriptableObject.enableHandCardSelection.RemoveListener(EnableCardHandSelectionHandler);
		
		_uiScriptableObject.passButtonVisibleEvent.RemoveListener(SetPassButtonVisibleEventHandler);
		
		_uiScriptableObject.shootButtonVisibleEvent.RemoveListener(SetPassButtonVisibleEventHandler);
		
		
		// _uiScriptableObject.beginPlayerDrawPhaseEvent.RemoveListener(BeginPlayerDrawPhaseEventHandler);
		// _uiScriptableObject.drawButtonClick.RemoveListener(DrawButtonClickEventHandler);
		// _playerScriptableObject.playerHandFullEvent.RemoveListener(PlayerHandFullEventHandler);
		// _uiScriptableObject.beginCompareCardPhaseEvent.RemoveListener(BeginComparePhaseEventHandler);
		// _uiScriptableObject.playedCardsReadyEvent.RemoveListener(PlayedCardsReadyEventHandler);
		// _uiScriptableObject.flipCoinButtonClickEvent.RemoveListener(FlipCoinButtonEventHandler);
		// _uiScriptableObject.flipCoinDoneEvent.RemoveListener(FlipCoinDoneEventHandler);
		// _uiScriptableObject.beginPreGunPhaseEvent.RemoveListener(BeginPreGunPhaseEventHandler);
		// _uiScriptableObject.showBannerEvent.RemoveListener(ShowBannerEventHandler);
		// _uiScriptableObject.bannerButtonClick.RemoveListener(BannerButtonClickEventHandler);
		// _uiScriptableObject.showPlayerCardBannerEvent.RemoveListener(ShowPlayerCardBannerEventHandler);
		// _uiScriptableObject.playerCardBannerButtonEvent.RemoveListener(PlayerCardBannerButtonEventHandler);
		// _uiScriptableObject.beginPreGunPhaseEvent.RemoveListener(BeginPreGunPhaseEventHandler);
		// _uiScriptableObject.beginGunPhaseEvent.RemoveListener(BeginGunPhaseEventHandler);
	}

	// public void BeginPlayerDrawPhaseEventHandler()
	// {
		
	// }
	
	public void ShowDrawButtonEventHandler()
	{
		_owner.SetDrawButtonActive(true);
	}
	
	
	// public void DrawButtonClickEventHandler()
	// {
	// 		_owner.SetDrawButtonActive(false);
	// }
	
	public void PlayerHandFullEventHandler()
	{
		_owner.SetDrawButtonActive(false);
	}
	
	void PlayedCardsReadyEventHandler()
	{
		_owner.SetCardBannerActive(true);
	}

	
	void FlipCoinButtonEventHandler(){
		Debug.Log("Coin Flip Button Pressed!");
		_owner.SetFlipCoinButtonActive(false);
		_owner.StartCoinFlip();
	}
	
	void FlipCoinDoneEventHandler(bool side)
	{
		if (side)
		{
			_uiScriptableObject.SetBannerText("Lowest number loses!");
		}
		else
		{
			_uiScriptableObject.SetBannerText("Highest number loses!");
		}
		_uiScriptableObject.OnShowBanner();
	}

	
	void ShowBannerEventHandler()
	{
		Debug.Log("Enabling Banner!");
		_owner.SetTextBannerActive(true);
	}
	
	void BannerButtonClickEventHandler()
	{
		Debug.Log("Disabling Banner (Button Click)!");
		_owner.SetTextBannerActive(false);
	}
	
	void ShowPlayerCardBannerEventHandler()
	{
		Debug.Log("Enabling CardBanner!");
		_owner.SetPlayerCardBannerActive(true);
	}
	void PlayerCardBannerButtonEventHandler()
	{
		Debug.Log("Disabling CardBanner (Button Click)!");
		_owner.SetPlayerCardBannerActive(false);
	}
	
	void EnableCardHandSelectionHandler()
	{
		Debug.Log("Disabling Draw Button!");
		_owner.SetDrawButtonActive(false);
	}
	
	void SetPlayerHandVisibleEventHandler(bool visible)
	{
		_owner.SetPlayerCardHandActive(visible);
	}
	
	void SetCoinVisibleEventHandler(bool visible)
	{
		_owner.SetFlipCoinButtonActive(visible);
	}
	
	void SetPassButtonVisibleEventHandler(bool visible)
	{
		_owner.SetPassButtonActive(visible);
	}
	
	void SetShootButtonVisibleEventHandler(bool visible)
	{
		_owner.SetPassButtonActive(visible);
	}
	
		
	// public void BeginComparePhaseEventHandler()
	// {
	// 	// changeState(new UIManagerCompareCardsPhaseState(_owner));
	// }
	// void BeginRoulettePhaseEventHandler()
	// {
	// 	Debug.Log("UI moving into UIManagerPreGunState!");
	// 	changeState(new UIManagerPreGunState(_owner));
	// }
	// void BeginPreGunPhaseEventHandler()
	// {
	// 	Debug.Log("UI moving into UIManagerPreGunState!");
	// }
	// void BeginGunPhaseEventHandler()
	// {
	// 	changeState(new UIManagerGunState(_owner));
	// }
	// void BeginPreGunPhaseEventHandler()
	// {
	// 	changeState(new UIManagerPreGunState(_owner));
	// }

	

}