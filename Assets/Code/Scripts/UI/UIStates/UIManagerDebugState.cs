using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UIManagerDebugState : UIManagerState
{
    public UIManagerDebugState(UIManager owner) : base(owner) { }

    public override void Execute()
    {
        Debug.Log("updating test state");
        GUILayout.BeginArea(new Rect(10, 10, 500, 500));
        if (GUILayout.Button("Rotate Gun"))
        {
            Debug.Log("Rotating Gun");
            _uiScriptableObject.OnRotateGun();
        }
        if (GUILayout.Button("Flip coin"))
        {
            _owner.createCoin();
        }
        if (GUILayout.Button("Increase Bullet Count"))
        {
            _owner.increaseBulletCount();
        }
        if (GUILayout.Button("Shoot Gun"))
        {
            _uiScriptableObject.OnShootGun();
        }
        if (GUILayout.Button("Start Game"))
        {
            changeState(new UIManagerGameInitState(_owner));   
        }
        GUILayout.EndArea();
    }

}

public class UIManagerGameInitState : UIManagerState
{
    public UIManagerGameInitState(UIManager owner) : base(owner) { }


    public override void Execute()
    {
        GUILayout.BeginArea(new Rect(10, 10, 500, 500));
        GUILayout.Label("The Game Has Begun!");
        GUILayout.Label("Here the game manager would shuffle the deck and each player would draw two cards.");
        if (GUILayout.Button("Continue"))
        {
            changeState(new UIManagerGameDrawPhaseState(_owner));
        }
        GUILayout.EndArea();
    }

}

public class UIManagerGameDrawPhaseState : UIManagerState
{
    public UIManagerGameDrawPhaseState(UIManager owner) : base(owner) { }

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
            changeState(new UIManagerCompareCardsPhaseState(_owner));
        }
        GUILayout.EndArea();
    }

}

public class UIManagerCompareCardsPhaseState : UIManagerState
{
    public UIManagerCompareCardsPhaseState(UIManager owner) : base(owner) { }

    public override void Execute()
    {
        Debug.Log("updating test state");
        GUILayout.BeginArea(new Rect(10, 10, 500, 500));
        GUILayout.Label("Here the game manager would compare all of the cards that each player played.");
        GUILayout.EndArea();
    }

}
