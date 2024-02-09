using static UnityEditorInternal.VersionControl.ListControl;
using UnityEngine;
using UnityEditor;

public class UIManagerStateMachine
{
    UIManagerState _currentState;

    public UIManagerStateMachine(UIManager owner)
    {
        _currentState = new UIManagerDebugState(owner);
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


