using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerPreGunState : GameManagerState
{
	
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	// bool _checkedForCard;
	
	int _additionalTriggerPulls;
	
	bool _skipThisPlayer;
	
	public GameManagerPreGunState(GameManager owner, GamePlayerScriptableObject targetPlayer, int additionalTriggerPulls) : base(owner) { 
		_targetPlayerScriptableObject = targetPlayer;
		// _checkedForCard = false;
		_skipThisPlayer = false;
		_additionalTriggerPulls = additionalTriggerPulls;
		_uiScriptableObject.bannerButtonClick.AddListener(OnBannerContinueEventHandler);
		_uiScriptableObject.playerCardBannerButtonEvent.AddListener(PlayerCardBannerButtonEventHandler);
	}

	public override void Enter()
	{
		_uiScriptableObject.OnBeginPreGunPhase();
		
		while(_uiScriptableObject.uiState != UIScriptableObject.UIStateEnum.GunState)
		{
			continue;
		}
		
		
		_uiScriptableObject.SetBannerText($"{_targetPlayerScriptableObject.GetPlayerName()} is now the target!");
		_uiScriptableObject.OnShowBanner();
		
		_gunScriptableObject.OnUpdateGunRotation(_targetPlayerScriptableObject.gunRotation);
	}

	override public void Execute() 
	{ 
		// Allow the player to use a skip card

		// TODO: Complex skip logic will go here


		// Wait for player to either skip or pull trigger
		
		

	}

	public override void Exit()
	{
		_uiScriptableObject.bannerButtonClick.RemoveListener(OnBannerContinueEventHandler);
		_uiScriptableObject.playerCardBannerButtonEvent.RemoveListener(PlayerCardBannerButtonEventHandler);
	}
	
	void OnBannerContinueEventHandler()
	{
		
		// if (!_checkedForCard)
		// {
		// 	_checkedForCard = T
		// }
		
		if (_targetPlayerScriptableObject.IsNpc())
		{
			NpcScriptableObject npc = (NpcScriptableObject) _targetPlayerScriptableObject;
			CardSO npcPreGunCard = npc.PlayPreGunPhaseCard();
			
			if (npcPreGunCard != null)
			{
				_skipThisPlayer = true;
				_uiScriptableObject.OnShowPlayerCardBanner(npcPreGunCard, $"{npc.GetPlayerName()} played a {npcPreGunCard.GetActionType()} card!");	
				
				if (npcPreGunCard.GetActionType() == CardActionType.Joker)
				{
					_additionalTriggerPulls++;
				}
			}
			
		}
		// else if player
		else
		{
			// TODO: Need to implement the functionality for the player's pre gun actions
			GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
			changeState(new GameManagerPreGunState(_owner, nextTarget, _additionalTriggerPulls));
		}
		
	}
	
	void PlayerCardBannerButtonEventHandler()
	{
		if (_skipThisPlayer)
		{
			Debug.Log($"Skipping this player: {_targetPlayerScriptableObject.GetPlayerName()}");
			GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
			Debug.Log($"Moving on to player: {nextTarget.GetPlayerName()}");
			changeState(new GameManagerPreGunState(_owner, nextTarget, _additionalTriggerPulls));
		}
		else
		{
			Debug.Log($"Entering gun phase with this player: {_targetPlayerScriptableObject.GetPlayerName()}");
			changeState(new GameManagerGunState(_owner, _targetPlayerScriptableObject, _additionalTriggerPulls));
		}
		
	}

	public override void OnGUI()
	{
		// https://stackoverflow.com/questions/52010746/how-can-i-change-guilayout-label-font-size
		//I am using two options: this
		// GUIStyle headStyle = new GUIStyle();
		// headStyle.fontSize = 30; 
		// GUI.Label(new Rect(Screen.width / 3, Screen.height / 2, 300, 50), "HELLO WORLD", headStyle);
		// or this
		// GUI.skin.label.fontSize = 30;
		// GUILayout.Label("HELLO WORLD", GUILayout.Width(300), GUILayout.Height(50)))
		
		GUILayout.BeginArea(new Rect(0, 500, 500, 500));
		GUILayout.Label($"PreGunState with Target: {_targetPlayerScriptableObject.GetPlayerName()}");
		GUILayout.EndArea();
	}

	
}