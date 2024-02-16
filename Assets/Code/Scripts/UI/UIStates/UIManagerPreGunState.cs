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
		_uiScriptableObject.beginPreGunPhaseEvent.AddListener(BeginPreGunPhaseEventHandler);
		_uiScriptableObject.beginGunPhaseEvent.AddListener(BeginGunPhaseEventHandler);
	}

	public override void Enter()
	{	
		_uiScriptableObject.OnSetUiState(UIScriptableObject.UIStateEnum.PreGunState);
	}

	
	public override void Execute()
	{
		GUILayout.BeginArea(new Rect(0, 1000, 500, 500));
		GUILayout.Label($"UIManager State: PreGunState");
		GUILayout.EndArea();
	}

	public override void Exit()
	{
		_owner.SetTextBannerActive(false);
		_owner.SetPlayerCardBannerActive(false);
		
		
		_uiScriptableObject.showBannerEvent.RemoveListener(ShowBannerEventHandler);
		_uiScriptableObject.bannerButtonClick.RemoveListener(BannerButtonClickEventHandler);
		_uiScriptableObject.showPlayerCardBannerEvent.RemoveListener(ShowPlayerCardBannerEventHandler);
		_uiScriptableObject.playerCardBannerButtonEvent.RemoveListener(PlayerCardBannerButtonEventHandler);
		_uiScriptableObject.beginPreGunPhaseEvent.RemoveListener(BeginPreGunPhaseEventHandler);
		_uiScriptableObject.beginGunPhaseEvent.RemoveListener(BeginGunPhaseEventHandler);
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
	
	void BeginGunPhaseEventHandler()
	{
		changeState(new UIManagerGunState(_owner));
	}
	
	void BeginPreGunPhaseEventHandler()
	{
		changeState(new UIManagerPreGunState(_owner));
	}

}
