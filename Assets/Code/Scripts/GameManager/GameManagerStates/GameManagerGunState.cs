using UnityEngine;

public class GameManagerGunState : GameManagerState
{
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	int _shotsRemaining;
	
	float timer;
	
	public GameManagerGunState(GameManager owner, GamePlayerScriptableObject targetPlayer, int additionalTriggerPulls) : base(owner) {
		_targetPlayerScriptableObject = targetPlayer;
		_shotsRemaining = additionalTriggerPulls + 1;
		
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonEventHandler);
	 }

	public override void Enter()
	{
		_uiScriptableObject.OnBeginGunPhase();
		
		while(_uiScriptableObject.uiState != UIScriptableObject.UIStateEnum.GunState)
		{
			continue;
		}
		
		// Fire the number of required times
		
		if (_targetPlayerScriptableObject.IsNpc())
		{
			// timer = 0;
			ExecuteNpcGunLogic();
		}
		else
		{
			// TODO: Implement player pulling the trigger phase!
			Debug.LogError("Hey! You shouldn't be here yet!!");
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
		
	}
	
	void BannerButtonEventHandler()
	{
		if(_shotsRemaining == 0)
		{
			if (_gunScriptableObject.HasOnlyBulletsLeft())
			{
				changeState(new GameManagerEndGunState(_owner, _targetPlayerScriptableObject));
			}
			else
			{
				changeState(new GameManagerPostGunState(_owner, _targetPlayerScriptableObject));
			}
			
		}
		else
		{
			ExecuteNpcGunLogic();
		}
	}
	
	
	void ExecuteNpcGunLogic()
	{
		bool bulletFired = _gunScriptableObject.OnFireGunEvent();
		_shotsRemaining--;
	
		if (bulletFired)
		{
			
			
			_targetPlayerScriptableObject.RemoveHeart();
			
			
			if(!_targetPlayerScriptableObject.IsPlayerAlive())
			{
				_uiScriptableObject.SetBannerText($"{_targetPlayerScriptableObject.GetPlayerName()} was shot and killed!");
				_uiScriptableObject.OnShowBanner();
			
				// move on to next player
				_targetPlayerScriptableObject.OnPlayerDied();
				GamePlayerScriptableObject nextTarget = _owner.GetNextPlayer(_targetPlayerScriptableObject);
				if (_gunScriptableObject.HasOnlyBulletsLeft())
				{
					changeState(new GameManagerEndGunState(_owner, _targetPlayerScriptableObject));
				}
				else
				{
					changeState(new GameManagerPreGunState(_owner, nextTarget, 0));
				}
				
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