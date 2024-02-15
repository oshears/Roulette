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
	}

	public override void Enter()
	{	
		
	}

	
	public override void Execute()
	{
		
	}

	public override void Exit()
	{

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

}
