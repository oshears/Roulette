public class GameManagerPreGunState : GameManagerState
{
	
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	bool _checkedForCard;
	
	int _additionalTriggerPulls;
	
	public GameManagerPreGunState(GameManager owner, GamePlayerScriptableObject targetPlayer, int additionalTriggerPulls) : base(owner) { 
		_targetPlayerScriptableObject = targetPlayer;
		_checkedForCard = false;
		_additionalTriggerPulls = additionalTriggerPulls;
		_uiScriptableObject.bannerButtonClick.AddListener(OnBannerContinueEventHandler);
		_uiScriptableObject.playerCardBannerButtonEvent.AddListener(PlayerCardBannerButtonEventHandler);
	}

	public override void Enter()
	{
		_uiScriptableObject.SetBannerText($"{_targetPlayerScriptableObject.GetPlayerName()} has been chosen as the first target!");
		_uiScriptableObject.OnShowBanner();
	}

	override public void Execute() 
	{ 
		// Allow the player to use a skip card

		// TODO: Complex skip logic will go here


		// Wait for player to either skip or pull trigger

	}

	public override void Exit()
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
				_uiScriptableObject.SetBannerText($"{npc.GetPlayerName()} played a {npcPreGunCard.GetActionType()} card!");
				_uiScriptableObject.OnShowPlayerCardBanner();	
			}
		}
		
	}
	
	void PlayerCardBannerButtonEventHandler()
	{
		changeState(new GameManagerGunState(_owner, _targetPlayerScriptableObject, _additionalTriggerPulls));
	}

	
}