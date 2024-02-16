using UnityEngine;

public class GameManagerGunState : GameManagerState
{
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	int _shotsRemaining;
	
	float timer;
	
	public GameManagerGunState(GameManager owner, GamePlayerScriptableObject targetPlayer, int additionalTriggerPulls) : base(owner) {
		_targetPlayerScriptableObject = targetPlayer;
		_shotsRemaining = additionalTriggerPulls + 1;
	 }

	public override void Enter()
	{
		// Fire the number of required times
		
		if (_targetPlayerScriptableObject.IsNpc())
		{
			timer = 0;
			// ExecuteNpcGunLogic();
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
		
		if (_targetPlayerScriptableObject.IsNpc())
		{
			if (timer > 2)
			{
				ExecuteNpcGunLogic();
				timer = 0;
				
			}
			else
			{
				timer += Time.deltaTime; 
			}
		}
		

		

	}
	
	
	void ExecuteNpcGunLogic()
	{
		bool bulletFired = _gunScriptableObject.OnFireGunEvent();
	
		if (bulletFired)
		{
			_targetPlayerScriptableObject.RemoveHeart();
			
			
			if(!_targetPlayerScriptableObject.IsPlayerAlive())
			{
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
		}
		_shotsRemaining--;
		
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
	}
	
	public override void OnGUI()
	{
		GUILayout.BeginArea(new Rect(10, 10, 500, 500));
		GUILayout.Label($"GunState with Target: {_targetPlayerScriptableObject.GetPlayerName()}");
		GUILayout.EndArea();
	}
	
}