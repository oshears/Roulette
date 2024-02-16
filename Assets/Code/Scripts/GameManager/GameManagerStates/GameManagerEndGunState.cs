using UnityEngine;

public class GameManagerEndGunState : GameManagerState
{
	
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	public GameManagerEndGunState(GameManager owner, GamePlayerScriptableObject targetPlayer) : base(owner) { 
		_targetPlayerScriptableObject = targetPlayer;
	}

	public override void Enter()
	{
		while(_uiScriptableObject.uiState != UIScriptableObject.UIStateEnum.EndGunState)
		{
			continue;
		}
		
		Debug.LogError($"Done with gun phase! New dealer will be: {_targetPlayerScriptableObject.GetPlayerName()}");
		_uiScriptableObject.OnEndGunPhase();
	}

	override public void Execute() 
	{ 

		

	}
	
	public override void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0, 500, 500, 500));
		GUILayout.Label($"EndGunState with Target: {_targetPlayerScriptableObject.GetPlayerName()}");
		GUILayout.EndArea();
	}
	
	
}