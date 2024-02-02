using static UnityEditorInternal.VersionControl.ListControl;
using UnityEngine;
using UnityEditor;

public interface IState
{
    public void Enter();
    public void Execute();
    public void Exit();
}

public class MenuStateMachine
{
    IState currentState;

    public MenuStateMachine(GUIController owner, MenuScriptableObject menuSO)
    {
        currentState = new DebugState(owner, menuSO);
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null) currentState.Execute();
    }
}

public abstract class MenuState : IState
{
    protected GUIController owner;
    protected MenuScriptableObject menuSO;

    public MenuState(GUIController owner, MenuScriptableObject menuSO)
    {
        this.owner = owner;
        this.menuSO = menuSO;
    }

    public virtual void Enter() { }
    public virtual void Execute() { }
    public virtual void Exit() { }

    protected void changeState(MenuState newState)
    {
        owner.menuStateMachine.ChangeState(newState);
    }
}

public class DebugState : MenuState
{
    public DebugState(GUIController owner, MenuScriptableObject menuSO) : base(owner, menuSO) { }

    public override void Execute()
    {
        Debug.Log("updating test state");
        GUILayout.BeginArea(new Rect(10, 10, 500, 500));
        if (GUILayout.Button("Rotate Gun"))
        {
            Debug.Log("Rotating Gun");
            menuSO.rotateGun();
        }
        if (GUILayout.Button("Start Game"))
        {
            changeState(new GameInitState(owner, menuSO));   
        }
        GUILayout.EndArea();
    }

}

public class GameInitState : MenuState
{
    public GameInitState(GUIController owner, MenuScriptableObject menuSO) : base(owner, menuSO) { }


    public override void Execute()
    {
        GUILayout.BeginArea(new Rect(10, 10, 500, 500));
        GUILayout.Label("The Game Has Begun!");
        GUILayout.Label("Here the game manager would shuffle the deck and each player would draw two cards.");
        if (GUILayout.Button("Continue"))
        {
            changeState(new GameDrawPhaseState(owner, menuSO));
        }
        GUILayout.EndArea();
    }

}

public class GameDrawPhaseState : MenuState
{
    public GameDrawPhaseState(GUIController owner, MenuScriptableObject menuSO) : base(owner, menuSO) { }

    int selectedCard = -1;

    public override void Execute()
    {
        Debug.Log("updating test state");
        GUILayout.BeginArea(new Rect(10, 10, 500, 500));
        GUILayout.Label("Here the game manager would allow the player to pick one card from their hand and confirm.");

        if (selectedCard >= 0)
        {
            GUILayout.Label("Selected Card: " + (selectedCard + 1));
        }
        
        for(int i = 0; i < 6; i++)
        {
            if (GUILayout.Button("Card #" + (i+1)))
            {
                selectedCard = i;
            }
        }
        if (GUILayout.Button("Confirm"))
        {
            changeState(new CompareCardsPhaseState(owner, menuSO));
        }
        GUILayout.EndArea();
    }

}

public class CompareCardsPhaseState : MenuState
{
    public CompareCardsPhaseState(GUIController owner, MenuScriptableObject menuSO) : base(owner, menuSO) { }

    public override void Execute()
    {
        Debug.Log("updating test state");
        GUILayout.BeginArea(new Rect(10, 10, 500, 500));
        GUILayout.Label("Here the game manager would compare all of the cards that each player played.");

        //for (int i = 1; i < 7; i++)
        //{
        //    if (GUILayout.Button("Card #" + i))
        //    {
        //        changeState(new GameInitState(owner, menuSO));
        //    }
        //}
        //if (GUILayout.Button("Confirm"))
        //{
        //    changeState(new GameInitState(owner, menuSO));
        //}
        GUILayout.EndArea();
    }

}
