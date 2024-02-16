using UnityEngine;

public class GameManagerPostGunState : GameManagerState
{
	
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	int _additionalTriggerPulls = 0;
	
	public GameManagerPostGunState(GameManager owner, GamePlayerScriptableObject targetPlayer) : base(owner) { 
		_targetPlayerScriptableObject = targetPlayer;
		_additionalTriggerPulls = 0;
		_uiScriptableObject.playerCardBannerButtonEvent.AddListener(PlayerCardBannerButtonEventHandler);
	}

	public override void Enter()
	{
		_uiScriptableObject.OnBeginPostGunPhase();
		
		while(_uiScriptableObject.uiState != UIScriptableObject.UIStateEnum.PostGunState)
		{
			continue;
		}
		
		// Check if player dead

		// If plalyer dead
		
		if (_targetPlayerScriptableObject.IsNpc())
		{
			CardSO playedCard = ((NpcScriptableObject) _targetPlayerScriptableObject).PlayPostGunPhaseCard();
			if (playedCard != null)
			{
				HandlePostGunCard(playedCard);
				_uiScriptableObject.OnShowPlayerCardBanner(playedCard, $"{_targetPlayerScriptableObject.GetPlayerName()} played a {playedCard.GetActionType()} card!");	

			} 
			else
			{
				GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
				changeState(new GameManagerPreGunState(_owner, nextTarget, 0));
			}
			
		}
		else
		{
			// TODO: Implement player post gun state logic
			Debug.LogError("Not yet implemented!!!");
		}
	}

	override public void Execute() 
	{ 
		// Allow the player to play a card

		// Wait until the player has confirmed the end of their turn

		

	}

	public override void Exit()
	{
		_uiScriptableObject.playerCardBannerButtonEvent.RemoveListener(PlayerCardBannerButtonEventHandler);
	}

	void HandlePostGunCard(CardSO card)
	{
		if (card.GetActionType() == CardActionType.Bullet)
		{
			_gunScriptableObject.OnAddBulletEvent();
		}
		else if (card.GetActionType() == CardActionType.TargetNextPlayer)
		{
			_additionalTriggerPulls++;
		}
		else if (card.GetActionType() == CardActionType.DrawTwo)
		{
			for (int i = 0; i < 2; i++)
			{
				_targetPlayerScriptableObject.AddCard(_deckScriptableObject.OnDrawCard());
			}
			
		}
		else if (card.GetActionType() == CardActionType.Joker)
		{
			_additionalTriggerPulls++;
		}
	}
	
	void PlayerCardBannerButtonEventHandler()
	{
		GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
		changeState(new GameManagerPreGunState(_owner, nextTarget, _additionalTriggerPulls));
	}
	
	public override void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0, 500, 500, 500));
		GUILayout.Label($"PostGunState with Target: {_targetPlayerScriptableObject.GetPlayerName()}");
		GUILayout.EndArea();
	}
	
}