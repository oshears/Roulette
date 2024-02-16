using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerPostGunState : UIManagerState
{
	public UIManagerPostGunState(UIManager owner) : base(owner) { 
		
	}

	public override void Enter()
	{	
		_uiScriptableObject.SetUiState(UIScriptableObject.UIStateEnum.PostGunState);
	}

	
	public override void Execute()
	{
		
	}

	public override void Exit()
	{
        _owner.SetTextBannerActive(false);
		_owner.SetPlayerCardBannerActive(false);
	}
	
}
