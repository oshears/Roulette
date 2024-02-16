using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UIManagerDebugState : UIManagerState
{
	public UIManagerDebugState(UIManager owner) : base(owner) { }

    public override void Enter()
    {
		_uiScriptableObject.OnSetUiState(UIScriptableObject.UIStateEnum.InitState);
    }

    
	public override void Execute()
	{
		GUILayout.BeginArea(new Rect(10, 10, 500, 500));
		if (GUILayout.Button("Rotate Gun"))
		{
			Debug.Log("Rotating Gun");
			_uiScriptableObject.OnRotateGun();
		}
		if (GUILayout.Button("Flip coin"))
		{
			_owner.StartCoinFlip();
		}
		if (GUILayout.Button("Increase Bullet Count"))
		{
			_owner.IncreaseBulletCount();
		}
		if (GUILayout.Button("Shoot Gun"))
		{
			_uiScriptableObject.OnShootGun();
		}
		if (GUILayout.Button("Start Game"))
		{
			changeState(new UIManagerDefaultState(_owner));   
			_uiScriptableObject.OnStartGame();
		}
		GUILayout.EndArea();
	}

}




