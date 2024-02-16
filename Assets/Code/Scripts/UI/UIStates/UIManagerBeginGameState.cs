using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerBeginGameState : UIManagerState
{
	public UIManagerBeginGameState(UIManager owner) : base(owner) { 
		_uiScriptableObject.beginPlayerDrawPhaseEvent.AddListener(BeginPlayerDrawPhaseEventHandler);
	}

	public override void Enter()
	{
		_uiScriptableObject.OnSetUiState(UIScriptableObject.UIStateEnum.BeginGameState);
	}


	public override void Execute()
	{
		// BeginPopUpArea();
		// GUILayout.Label("The Game Has Begun!");
		// GUILayout.Label("Here the game manager would shuffle the deck and each player would draw two cards.");
		// if (GUILayout.Button("Draw Cards"))
		// {
		// 	changeState(new UIManagerGameDrawPhaseState(_owner));
		// 	_uiScriptableObject.OnDrawCards();
		// }
		// EndPopUpArea();
		
	}

	public override void Exit()
	{
		_uiScriptableObject.beginPlayerDrawPhaseEvent.RemoveListener(BeginPlayerDrawPhaseEventHandler);
	}

	public void BeginPlayerDrawPhaseEventHandler()
	{
		changeState(new UIManagerGameDrawPhaseState(_owner));
	}

	void BeginPopUpArea()
	{
		float topLeftCornerX = Screen.width*0.25f;
		float topLeftCornerY = Screen.height*0.25f;
		GUILayout.BeginArea(new Rect(topLeftCornerX, topLeftCornerY, Screen.width*0.5f, Screen.height*0.5f));
	}

	void EndPopUpArea()
	{
		GUILayout.EndArea();
	}

}