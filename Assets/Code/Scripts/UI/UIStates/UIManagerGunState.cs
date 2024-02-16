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
		_uiScriptableObject.showBannerEvent.AddListener(ShowBannerEventHandler);
	}

	public override void Enter()
	{	
		
		_uiScriptableObject.OnSetUiState(UIScriptableObject.UIStateEnum.GunState);
	}

	
	public override void Execute()
	{
		GUILayout.BeginArea(new Rect(0, 1000, 500, 500));
		GUILayout.Label($"UIManager State: GunState");
		GUILayout.EndArea();
	}

	public override void Exit()
	{ 
		_owner.SetTextBannerActive(false);
		
		_uiScriptableObject.beginPostGunPhaseEvent.RemoveListener(BeginPostGunPhaseEventHandler);
		_uiScriptableObject.endGunPhaseEvent.RemoveListener(EndGunPhaseEventHandler);
		_uiScriptableObject.beginPreGunPhaseEvent.RemoveListener(BeginPreGunphaseEventHandler);
	}
	
	void ShowBannerEventHandler()
	{
		_owner.SetTextBannerActive(true);
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
