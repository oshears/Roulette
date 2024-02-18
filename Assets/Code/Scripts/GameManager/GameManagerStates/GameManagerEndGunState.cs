using UnityEngine;

public class GameManagerEndGunState : GameManagerState
{
	
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	public GameManagerEndGunState(GameManager owner, GamePlayerScriptableObject targetPlayer) : base(owner) { 
		_targetPlayerScriptableObject = targetPlayer;
		
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonClickEventHandler);
	}

	public override void Enter()
	{
		Debug.LogError($"Done with gun phase! New dealer will be: {_targetPlayerScriptableObject.GetPlayerName()}");
		// _uiScriptableObject.OnEndGunPhase();
		
		_uiScriptableObject.SetBannerText($"No more empty shells remain. Starting new round!");
		_uiScriptableObject.OnShowBanner();
		
	}

	override public void Execute() 
	{ 

		

	}

    public override void Exit()
    {
        _uiScriptableObject.bannerButtonClick.RemoveListener(BannerButtonClickEventHandler);
    }

    
	void BannerButtonClickEventHandler()
	{
		changeState(new GameManagerDrawCardsState(_owner));
	}
	
	public override void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0, 500, 500, 500));
		GUILayout.Label($"EndGunState with Target: {_targetPlayerScriptableObject.GetPlayerName()}");
		GUILayout.EndArea();
	}
	
	
}