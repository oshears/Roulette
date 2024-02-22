using UnityEngine;
using UnityEngine.Analytics;

public class GameManagerGunState : GameManagerState
{
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	int _shotsRemaining;
	
	float timer;
	
	public GameManagerGunState(GameManager owner, GamePlayerScriptableObject targetPlayer, int additionalTriggerPulls) : base(owner) {
		_targetPlayerScriptableObject = targetPlayer;
		_shotsRemaining = additionalTriggerPulls + 1;
		
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonEventHandler);
		
		_uiScriptableObject.shootButtonClickEvent.AddListener(ShootButtonClickEventHandler);
		// _uiScriptableObject.uiReadyEvent.AddListener(UiReadyEventHandler);
	 }

	public override void Enter()
	{
		Debug.Log("Entered Gun State!");
		// _uiScriptableObject.OnBeginGunPhase();
		
		// Fire the number of required times
		
		if (_targetPlayerScriptableObject.IsNpc())
		{
			// timer = 0;
			ExecuteGunShotLogic();
		}
		else
		{
			// TODO: Implement player pulling the trigger phase!
			// Debug.LogError("Hey! You shouldn't be here yet!!");
			_uiScriptableObject.OnSetShootButtonVisible(true);
		}
		
		// Check if player dead

		// If plalyer dead
		
	}

	override public void Execute() 
	{ 
		// Allow the player to play a card

		// Wait until the player has confirmed the end of their turn
		
		// if (_targetPlayerScriptableObject.IsNpc())
		// {
		// 	if (timer > 2)
		// 	{
		// 		ExecuteNpcGunLogic();
		// 		timer = 0;
				
		// 	}
		// 	else
		// 	{
		// 		timer += Time.deltaTime; 
		// 	}
		// }
		

		

	}
	
	public override void Exit()
	{
		_uiScriptableObject.bannerButtonClick.RemoveListener(BannerButtonEventHandler);
		_uiScriptableObject.shootButtonClickEvent.RemoveListener(ShootButtonClickEventHandler);
		// _uiScriptableObject.uiReadyEvent.RemoveListener(UiReadyEventHandler);
		
		_uiScriptableObject.OnSetShootButtonVisible(false);
	}
	
	void ShootButtonClickEventHandler()
	{
		ExecuteGunShotLogic();
		
	}
	
	void BannerButtonEventHandler()
	{
		// End the game if the human player (who is the current target) has died.
		if (!_targetPlayerScriptableObject.IsNpc() && !_targetPlayerScriptableObject.IsPlayerAlive())
		{
			changeState(new GameManagerGameOverState(_owner, false));
		}
		// End the game if only player is alive.
		else if (_playerScriptableObject.IsPlayerAlive() && _owner.GetNumPlayersAlive() == 1)
		{
			changeState(new GameManagerGameOverState(_owner, true));
		}
		// If current player was shot and killed, move on to next player
		else if (!_targetPlayerScriptableObject.IsPlayerAlive())
		{
			GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
			changeState(new GameManagerPreGunState(_owner, nextTarget, 0));
		}
		// if no empty shells left in the gun, move to the end gun state
		// if the gun has only bullets, the current target becomes the dealer
		else if (_gunScriptableObject.HasOnlyBulletsLeft())
		{
			changeState(new GameManagerEndGunState(_owner, _targetPlayerScriptableObject));
		}
		else
		{
			// if there are no shots left to take
			if(_shotsRemaining == 0)
			{
				changeState(new GameManagerPostGunState(_owner, _targetPlayerScriptableObject));
			}
			// if there are still shots left to take
			else
			{
				// if the target is an npc, then execute the gun logic automatically
				if (_targetPlayerScriptableObject.IsNpc())
				{
					ExecuteGunShotLogic();
				}
				// else let the player click the button
				else
				{
					_uiScriptableObject.OnSetShootButtonVisible(true);
				}
			}
		}
	}
	
	
	void ExecuteGunShotLogic()
	{
		bool bulletFired = _gunScriptableObject.OnFireGunEvent();
		_shotsRemaining--;
		
		_uiScriptableObject.OnSetShootButtonVisible(false);
	
		if (bulletFired)
		{
			_targetPlayerScriptableObject.RemoveHeart();
			
			if (_playerScriptableObject.GetHeartsRemaining() < 2)
			{
				_uiScriptableObject.OnSetDamageColorizerVisible(true);
			}
			
			
			if(!_targetPlayerScriptableObject.IsPlayerAlive())
			{
				_uiScriptableObject.SetBannerText($"{_targetPlayerScriptableObject.GetPlayerName()} was shot and killed!");
				_uiScriptableObject.OnShowBanner();
			
				// move on to next player
				_targetPlayerScriptableObject.OnPlayerDied();
				// GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
				// if (_gunScriptableObject.HasOnlyBulletsLeft())
				// {
				// 	changeState(new GameManagerEndGunState(_owner, _targetPlayerScriptableObject));
				// }
				// else
				// {
				// 	changeState(new GameManagerPreGunState(_owner, nextTarget, 0));
				// }
				
			}
			else
			{
				_uiScriptableObject.SetBannerText($"{_targetPlayerScriptableObject.GetPlayerName()} was shot!");
				_uiScriptableObject.OnShowBanner();
			}
			
			
		}
		else
		{
			_uiScriptableObject.SetBannerText($"{_targetPlayerScriptableObject.GetPlayerName()} dodged a bullet!");
			_uiScriptableObject.OnShowBanner();
		}
		
		
		
	}
	
	public override void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0, 500, 500, 500));
		GUILayout.Label($"GunState with Target: {_targetPlayerScriptableObject.GetPlayerName()}");
		GUILayout.EndArea();
	}
	
}