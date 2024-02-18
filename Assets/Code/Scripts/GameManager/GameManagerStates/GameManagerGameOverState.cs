using UnityEngine;

public class GameManagerGameOverState : GameManagerState
{
	
	// GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	bool _didPlayerWin;
	
	public GameManagerGameOverState(GameManager owner, bool didPlayerWin) : base(owner) { 
		// _targetPlayerScriptableObject = targetPlayer;
		
		// _uiScriptableObject.bannerButtonClick.AddListener(BannerButtonClickEventHandler);
		_didPlayerWin = didPlayerWin;
		
		_uiScriptableObject.playAgainButtonClickEvent.AddListener(PlayerAgainButtonClickEventHandler);
		_uiScriptableObject.quitButtonClickEvent.AddListener(QuitButtonClickEventHandler);
	}

	public override void Enter()
	{
		// Debug.LogError($"Done with gun phase! New dealer will be: {_targetPlayerScriptableObject.GetPlayerName()}");
		// // _uiScriptableObject.OnEndGunPhase();
		
		// _uiScriptableObject.SetBannerText($"No more empty shells remain. Starting new round!");
		// _uiScriptableObject.OnShowBanner();
		
		_uiScriptableObject.OnGameOver(_didPlayerWin);
		_uiScriptableObject.OnGameOverBannerVisible(true);
		
	}

	override public void Execute() 
	{ 

		

	}

	public override void Exit()
	{
		// _uiScriptableObject.bannerButtonClick.AddListener(BannerButtonClickEventHandler);
		
		_uiScriptableObject.OnGameOverBannerVisible(false);
		
		_uiScriptableObject.playAgainButtonClickEvent.RemoveListener(PlayerAgainButtonClickEventHandler);
		_uiScriptableObject.quitButtonClickEvent.RemoveListener(QuitButtonClickEventHandler);
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
	
	void PlayerAgainButtonClickEventHandler()
	{
		changeState(new GameManagerInitState(_owner));
	}
	
	void QuitButtonClickEventHandler()
	{
		Application.Quit(0);
	}
	
	
}