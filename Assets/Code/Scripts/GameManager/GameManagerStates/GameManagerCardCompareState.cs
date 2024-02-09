public class GameManagerCardCompareState : GameManagerState
{
	public GameManagerCardCompareState(GameManager owner) : base(owner) { }

	public override void Enter()
	{
		// Flip the coin
		_uiScriptableObject.OnFlipCoin();
	}
	override public void Execute() 
	{ 
		

		// Identify the losing player

		// If there is a tie, then let the dealer (house) decide on the loser

	}

	

	
}
