using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerPostGunState : UIManagerState
{
	public UIManagerPostGunState(UIManager owner) : base(owner) { 
		
		_uiScriptableObject.showPlayerCardBannerEvent.AddListener(ShowPlayerCardBannerEventHandler);
		
	}

	public override void Enter()
	{	
		_uiScriptableObject.OnSetUiState(UIScriptableObject.UIStateEnum.PostGunState);
	}

	
	public override void Execute()
	{
		
	}

	public override void Exit()
	{
		_owner.SetPlayerCardBannerActive(false);
	}
	
	void ShowPlayerCardBannerEventHandler()
	{
		_owner.SetPlayerCardBannerActive(true);
	}
	
}
