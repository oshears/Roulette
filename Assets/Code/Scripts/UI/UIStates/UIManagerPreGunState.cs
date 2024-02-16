using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerPreGunState : UIManagerState
{
	public UIManagerPreGunState(UIManager owner) : base(owner) { 
		_uiScriptableObject.showBannerEvent.AddListener(ShowBannerEventHandler);
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonClickEventHandler);
		_uiScriptableObject.showPlayerCardBannerEvent.AddListener(ShowPlayerCardBannerEventHandler);
		_uiScriptableObject.playerCardBannerButtonEvent.AddListener(PlayerCardBannerButtonEventHandler);
		_uiScriptableObject.beginGunPhaseEvent.AddListener(BeginGunPhaseEventHandler);
		
	}

	public override void Enter()
	{	
		_uiScriptableObject.SetUiState(UIScriptableObject.UIStateEnum.PreGunState);
	}

	
	public override void Execute()
	{
		
	}

	public override void Exit()
	{
		_owner.SetTextBannerActive(false);
		_owner.SetPlayerCardBannerActive(false);
		
		
		_uiScriptableObject.showBannerEvent.RemoveListener(ShowBannerEventHandler);
		_uiScriptableObject.bannerButtonClick.RemoveListener(BannerButtonClickEventHandler);
		_uiScriptableObject.showPlayerCardBannerEvent.RemoveListener(ShowPlayerCardBannerEventHandler);
		_uiScriptableObject.playerCardBannerButtonEvent.RemoveListener(PlayerCardBannerButtonEventHandler);
		_uiScriptableObject.beginGunPhaseEvent.RemoveListener(BeginGunPhaseEventHandler);
	}
	
	void ShowBannerEventHandler()
	{
		_owner.SetTextBannerActive(true);
	}
	
	void BannerButtonClickEventHandler()
	{
		_owner.SetTextBannerActive(false);
	}
	
	void ShowPlayerCardBannerEventHandler()
	{
		_owner.SetPlayerCardBannerActive(true);
	}
	void PlayerCardBannerButtonEventHandler()
	{
		_owner.SetPlayerCardBannerActive(false);
	}
	
	void BeginGunPhaseEventHandler()
	{
		changeState(new UIManagerGunState(_owner));
	}

}
