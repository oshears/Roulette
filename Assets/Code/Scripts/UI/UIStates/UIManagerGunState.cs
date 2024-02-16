using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerGunState : UIManagerState
{
	public UIManagerGunState(UIManager owner) : base(owner) { 
		_uiScriptableObject.beginPostGunPhaseEvent.AddListener(BeginPostGunPhaseEventHandler);
		_uiScriptableObject.endGunPhaseEvent.AddListener(EndGunPhaseEventHandler);
		_uiScriptableObject.beginPreGunPhaseEvent.AddListener(BeginPreGunphaseEventHandler);
	}

	public override void Enter()
	{	
		_uiScriptableObject.SetUiState(UIScriptableObject.UIStateEnum.GunState);
	}

	
	public override void Execute()
	{
		
	}

	public override void Exit()
	{ 
		_uiScriptableObject.beginPostGunPhaseEvent.RemoveListener(BeginPostGunPhaseEventHandler);
		_uiScriptableObject.endGunPhaseEvent.RemoveListener(EndGunPhaseEventHandler);
		_uiScriptableObject.beginPreGunPhaseEvent.RemoveListener(BeginPreGunphaseEventHandler);
	}
	
	public void BeginPostGunPhaseEventHandler()
	{
		changeState(new UIManagerPostGunState(_owner));
	}
	
	public void EndGunPhaseEventHandler()
	{
		changeState(new UIManagerEndGunState(_owner));
	}
	
	public void BeginPreGunphaseEventHandler()
	{
		changeState(new UIManagerPreGunState(_owner));
	}
	
}
