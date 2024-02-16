using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerEndGunState : UIManagerState
{
	public UIManagerEndGunState(UIManager owner) : base(owner) { 
		
	}

	public override void Enter()
	{	
		_uiScriptableObject.OnSetUiState(UIScriptableObject.UIStateEnum.EndGunState);
	}

	
	public override void Execute()
	{
		
	}

	public override void Exit()
	{
		
	}
	
}
