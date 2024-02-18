using UnityEngine;

public class GameManagerGameOverState : GameManagerState
{
	
	// GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	public GameManagerGameOverState(GameManager owner) : base(owner) { 
		// _targetPlayerScriptableObject = targetPlayer;
		
		// _uiScriptableObject.bannerButtonClick.AddListener(BannerButtonClickEventHandler);
	}

	public override void Enter()
	{
		// Debug.LogError($"Done with gun phase! New dealer will be: {_targetPlayerScriptableObject.GetPlayerName()}");
		// // _uiScriptableObject.OnEndGunPhase();
		
		// _uiScriptableObject.SetBannerText($"No more empty shells remain. Starting new round!");
		// _uiScriptableObject.OnShowBanner();
		
	}

	override public void Execute() 
	{ 

		

	}

    public override void Exit()
    {
        // _uiScriptableObject.bannerButtonClick.AddListener(BannerButtonClickEventHandler);
    }

    
	// void BannerButtonClickEventHandler()
	// {
	// 	changeState(new GameManagerDrawCardsState(_owner));
	// }
	
	public override void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0, 500, 500, 500));
		GUILayout.EndArea();
	}
	
	
}