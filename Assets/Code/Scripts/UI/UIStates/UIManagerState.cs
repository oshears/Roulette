using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class UIManagerState : IManagerState
{
	protected UIManagerStateMachine _stateMachine;
	protected UIManager _owner;
	protected UIScriptableObject _uiScriptableObject;

	public UIManagerState(UIManager owner)
	{
		_owner = owner;
		_stateMachine = owner.stateMachine;
		_uiScriptableObject = owner.uiScriptableObject;
		Debug.Log(_stateMachine);
	}
	public virtual void Enter() { }
	public virtual void Execute() { }
	public virtual void Exit() { }
	protected void changeState(UIManagerState newState)
	{
		Debug.Log(_stateMachine);
		_stateMachine.ChangeState(newState);
	}
}