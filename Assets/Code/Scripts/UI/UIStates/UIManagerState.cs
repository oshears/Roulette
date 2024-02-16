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
	protected PlayerScriptableObject _playerScriptableObject;

	public UIManagerState(UIManager owner)
	{
		_owner = owner;
		_stateMachine = owner.stateMachine;
		_uiScriptableObject = owner.uiScriptableObject;
		_playerScriptableObject = owner.playerScriptableObject;
	}
	public virtual void Enter() { }
	public virtual void Execute() { }
	public virtual void Exit() { }
	protected void changeState(UIManagerState newState)
	{
		_stateMachine.ChangeState(newState);
	}
}