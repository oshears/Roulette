using UnityEngine;

public class UIManagerStateMachine
{
	UIManager _owner;
	UIManagerState _currentState;

	public UIManagerStateMachine(UIManager owner)
	{
		// _currentState = new UIManagerDebugState(owner);
		_owner = owner;
	}

	public void ChangeState(UIManagerState newState)
	{
		if (_currentState != null)
			_currentState.Exit();

		_currentState = newState;
		_currentState.Enter();
	}

	public void Update()
	{
		if (_currentState != null) _currentState.Execute();
	}
}


