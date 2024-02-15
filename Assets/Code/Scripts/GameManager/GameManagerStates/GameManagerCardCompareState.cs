public class GameManagerCardCompareState : GameManagerState
{
	public GameManagerCardCompareState(GameManager owner) : base(owner) { }

	public override void Enter()
	{
		_uiScriptableObject.flipCoinDoneEvent.AddListener(FlipCoinDoneEventHandler);
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonEventHandler);
		
		// Flip the coin
		_uiScriptableObject.OnFlipCoin();
	}
	override public void Execute() 
	{ 
		

		// Identify the losing player

		// If there is a tie, then let the dealer (house) decide on the loser

	}

	
	void FlipCoinDoneEventHandler(Coin.Side side)
	{
		// TODO:
		// 1. Determine whether highest or lowest card loses
		// 2. Get all the cards that the players placed
		// 3. Compare the cards that were played
		// 4. In the event of a tie, just choose a random player for now
		// 5. Add the number of bullets to the gun based on the number of bullet cards
		// 6. Proceed to the gun phase!!!
	}
	
	
	
	public void BannerButtonEventHandler()
	{
		changeState(new GameManagerPlayerGunState(_owner));
	}
	
}
