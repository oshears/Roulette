using static UnityEditorInternal.VersionControl.ListControl;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class GameManagerStateMachine
{
    GameManagerState _currentState;

    public GameManagerStateMachine(GUIController owner)
    {
        _currentState = new GameManagerInitState(owner);
    }

    public void ChangeState(GameManagerState newState)
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

public abstract class GameManagerState : IManagerState
{
    protected GUIController _owner;
    protected MenuScriptableObject _menuSO;

    public GameManagerState(GUIController owner)
    {
        this._owner = owner;
    }
    public virtual void Enter() {}
    public virtual void Execute() {}
    public virtual void Exit() {}
    protected void changeState(MenuState newState)
    {
        _owner.menuStateMachine.ChangeState(newState);
    }
}

public class GameManagerInitState : GameManagerState
{
    public GameManagerInitState(GUIController owner) : base(owner) { }

    override public void Execute() 
    { 
        // Reset Player Scores

    }
    
}

public class GameManagerNewRoundState : GameManagerState
{
    public GameManagerNewRoundState(GUIController owner) : base(owner) { }

    override public void Execute() 
    { 
        // Deal two cards to each player

        // Wait for all players to select their card choice

    }
}

public class GameManagerCardCompareState : GameManagerState
{
    public GameManagerCardCompareState(GUIController owner) : base(owner) { }

    override public void Execute() 
    { 
        // Flip the coin

        // Identify the losing player

        // If there is a tie, then let the dealer (house) decide on the loser

    }
    
}

public class GameManagerPlayerGunState : GameManagerState
{
    public GameManagerPlayerGunState(GUIController owner) : base(owner) { }

    override public void Execute() 
    { 
        // Allow the player to use a skip card

        // TODO: Complex skip logic will go here


        // Wait for player to either skip or pull trigger

    }
    
}

public class GameManagerPlayerPostGunState : GameManagerState
{
    public GameManagerPlayerPostGunState(GUIController owner) : base(owner) { }

    public override void Enter()
    {
        // Check if player dead

        // If plalyer dead
    }

    override public void Execute() 
    { 
        // Allow the player to play a card

        // Wait until the player has confirmed the end of their turn

        

    }


    
}