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
		_uiScriptableObject.playCardEvent.AddListener(PlayCardEventHandler);
		_uiScriptableObject.passButtonEvent.AddListener(PassButtonClickEventHandler);
		// _uiScriptableObject.uiReadyEvent.AddListener(UiReadyEventHandler);
	}

	public override void Enter()
	{
		if (_targetPlayerScriptableObject.IsNpc())
		{
			_uiScriptableObject.OnUpdateObjectiveText("Survive the roulette!");
		}
		else
		{
			_uiScriptableObject.OnUpdateObjectiveText("Select a pre-roulette card to play!");
		}
		
		// _uiScriptableObject.OnBeginPreGunPhase();
		if (!_targetPlayerScriptableObject.IsPlayerAlive())
		{
			Debug.Log($"Skipping this player: {_targetPlayerScriptableObject.GetPlayerName()}");
			GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
			Debug.Log($"Moving on to player: {nextTarget.GetPlayerName()}");
			changeState(new GameManagerPreGunState(_owner, nextTarget, _additionalTriggerPulls));
			return;
		}
		
		
		_uiScriptableObject.SetBannerText($"{_targetPlayerScriptableObject.GetPlayerName()} is now the target!");
		_uiScriptableObject.OnShowBanner();
		
		// _gunScriptableObject.OnUpdateGunRotation(_targetPlayerScriptableObject.gunRotation);
		_gunScriptableObject.OnUpdateGunRotation(_targetPlayerScriptableObject.playerId);
		
		
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
		_uiScriptableObject.playCardEvent.RemoveListener(PlayCardEventHandler);
		_uiScriptableObject.passButtonEvent.RemoveListener(PassButtonClickEventHandler);
		// _uiScriptableObject.uiReadyEvent.RemoveListener(UiReadyEventHandler);
		
		_uiScriptableObject.OnSetPlayerHandVisible(false);
		_uiScriptableObject.OnSetPassButtonVisible(false);

	}
	
	void UiReadyEventHandler()
	{
		
		
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
			else
			{
				Debug.Log($"Entering gun phase with this player: {_targetPlayerScriptableObject.GetPlayerName()}");
				changeState(new GameManagerGunState(_owner, _targetPlayerScriptableObject, _additionalTriggerPulls));
			}
			
		}
		// else if player
		else
		{
			// TODO: Need to implement the functionality for the player's pre gun actions
			// Debug.LogError("Skipping player's turn for now");
			// GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
			// changeState(new GameManagerPreGunState(_owner, nextTarget, _additionalTriggerPulls));
			
			// skip this phase if the player doesn't have a valid pregunphase card
			if(!_targetPlayerScriptableObject.IsNpc() && !_targetPlayerScriptableObject.HasValidPreGunPhaseCard())
			{
				changeState(new GameManagerGunState(_owner, _targetPlayerScriptableObject, _additionalTriggerPulls));
			}
			else
			{
				_uiScriptableObject.OnSetPlayerHandVisible(true);
				_uiScriptableObject.OnEnableCardSelection();
				_uiScriptableObject.OnSetPassButtonVisible(true);
			}
		}
		
	}
	
	
	void PlayCardEventHandler(int cardChoice) {
		Debug.Log("Handling player card selection!");
		
		CardSO playedCard = _playerScriptableObject.PlayPreGunPhaseCard(cardChoice);
		if (playedCard != null)
		{
			if (playedCard.GetActionType() == CardActionType.Joker)
			{
				_additionalTriggerPulls++;
				_skipThisPlayer = true;
			}
			else if (playedCard.GetActionType() == CardActionType.EmptyShell)
			{
				_skipThisPlayer = true;
			}
			_uiScriptableObject.OnShowPlayerCardBanner(playedCard, $"{_targetPlayerScriptableObject.GetPlayerName()} played a {playedCard.GetActionType()} card!");	
			_uiScriptableObject.OnSetPlayerHandVisible(false);
			_uiScriptableObject.OnSetPassButtonVisible(false);
		}
	}
	
	void PassButtonClickEventHandler()
	{
		//TODO: Need to debug why this isn't running?
		Debug.Log($"Entering gun phase with this player: {_targetPlayerScriptableObject.GetPlayerName()}");
		changeState(new GameManagerGunState(_owner, _targetPlayerScriptableObject, _additionalTriggerPulls));
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