using UnityEngine;

public class GameManagerPostGunState : GameManagerState
{
	
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	int _additionalTriggerPulls = 0;
	
	public GameManagerPostGunState(GameManager owner, GamePlayerScriptableObject targetPlayer) : base(owner) { 
		_targetPlayerScriptableObject = targetPlayer;
		_additionalTriggerPulls = 0;
		_uiScriptableObject.playerCardBannerButtonEvent.AddListener(PlayerCardBannerButtonEventHandler);
		_uiScriptableObject.playCardEvent.AddListener(PlayCardEventHandler);
		_uiScriptableObject.passButtonEvent.AddListener(PassButtonClickEventHandler);
		// _uiScriptableObject.uiReadyEvent.AddListener(UiReadyEventHandler);
	}

	public override void Enter()
	{
		// _uiScriptableObject.OnBeginPostGunPhase();
		
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
			// Debug.LogError("Not yet implemented!!!");
			
			// GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
			// changeState(new GameManagerPreGunState(_owner, nextTarget, 0));
			_uiScriptableObject.OnSetPlayerHandVisible(true);
			_uiScriptableObject.OnEnableCardSelection();
			_uiScriptableObject.OnSetPassButtonVisible(true);
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
		_uiScriptableObject.playCardEvent.RemoveListener(PlayCardEventHandler);
		_uiScriptableObject.passButtonEvent.RemoveListener(PassButtonClickEventHandler);
		// _uiScriptableObject.uiReadyEvent.RemoveListener(UiReadyEventHandler);
		
		
		_uiScriptableObject.OnSetPlayerHandVisible(false);
		_uiScriptableObject.OnSetPassButtonVisible(false);
		
	}
	
	void PlayCardEventHandler(int cardChoice)
	{
		CardSO playedCard = _playerScriptableObject.PlayPostGunPhaseCard(cardChoice);
		if (playedCard != null)
		{
			if (playedCard.GetActionType() == CardActionType.Joker)
			{
				_additionalTriggerPulls++;
			}
			else if (playedCard.GetActionType() == CardActionType.DrawTwo)
			{
				for (int i = 0; i < 2; i++)
				{
					CardSO drawnCard = _deckScriptableObject.OnDrawCard();
					_playerScriptableObject.AddCard(drawnCard);
					_uiScriptableObject.OnUpdateHandCards();
				}
				
			}
			else if (playedCard.GetActionType() == CardActionType.TargetNextPlayer)
			{
				_additionalTriggerPulls++;
			}
			else if (playedCard.GetActionType() == CardActionType.Bullet)
			{
				_gunScriptableObject.OnAddBullet();
				_gunScriptableObject.OnShuffleGun();
			}

			_uiScriptableObject.OnShowPlayerCardBanner(playedCard, $"{_targetPlayerScriptableObject.GetPlayerName()} played a {playedCard.GetActionType()} card!");	
			_uiScriptableObject.OnSetPlayerHandVisible(false);
		}
		
	}
	
	void HandlePostGunCard(CardSO card)
	{
		if (card.GetActionType() == CardActionType.Bullet)
		{
			_gunScriptableObject.OnAddBullet();
			_gunScriptableObject.OnShuffleGun();
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
	
	void PassButtonClickEventHandler()
	{
		GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
		changeState(new GameManagerPreGunState(_owner, nextTarget, 0));
	}
	
	public override void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0, 500, 500, 500));
		GUILayout.Label($"PostGunState with Target: {_targetPlayerScriptableObject.GetPlayerName()}");
		GUILayout.EndArea();
	}
	
}