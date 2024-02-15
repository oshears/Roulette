using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerGameDrawPhaseState : UIManagerState
{
	int _numCardsDrawn = 2;
	int _selectedCard;
	
	
	public UIManagerGameDrawPhaseState(UIManager owner) : base(owner) { 
		_uiScriptableObject.drawButtonClick.AddListener(DrawButtonClickEventHandler);
		_uiScriptableObject.playCardEvent.AddListener(PlayCardEventHandler);
	}

	public override void Enter()
	{	
		_numCardsDrawn = 0;
		_owner.SetDrawButtonActive(true);
		_owner.SetPlayerCardHandActive(true);
	}


	
	public override void Execute()
	{
		// GUILayout.BeginArea(new Rect(10, 10, 500, 500));
		// GUILayout.Label("Here the game manager would allow the player to pick one card from their hand and confirm.");

		// if (_selectedCard >= 0)
		// {
		// 	GUILayout.Label("Selected Card: " + (_selectedCard + 1));
		// }
		
		// for(int i = 0; i < _numPlayerCards; i++)
		// {
		// 	if (GUILayout.Button("Card #" + (i+1)))
		// 	{
		// 		_selectedCard = i;
		// 	}
		// }
		// if (GUILayout.Button($"Play Card: {_selectedCard + 1}"))
		// {
		// 	changeState(new UIManagerCompareCardsPhaseState(_owner));
		// 	_uiScriptableObject.OnPlayCard();
		// }
		// GUILayout.EndArea();
	}

	public override void Exit()
	{
		
	}
	
	public void DrawButtonClickEventHandler()
	{
		if (_numCardsDrawn < 1)
		{
			_numCardsDrawn++;
		}
		else
		{
			Debug.Log("Disabling Draw Button!");
			_owner.SetDrawButtonActive(false);
			_uiScriptableObject.OnEnableCardSelection();
		}
	}

	public void PlayCardEventHandler()
	{

	}
	

}