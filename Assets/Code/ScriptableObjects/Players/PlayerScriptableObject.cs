using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject")]
public class PlayerScriptableObject : GamePlayerScriptableObject
{
	
	public UnityEvent playerHandFullEvent;
	
	public int highScore {get; private set;} = 0;
	public int currScore {get; private set;} = 0;

	public override bool IsNpc()
	{
		return false;
	}
	
	public void incrementScore(int amount)
	{
		currScore += amount;
	}
	
	override public void OnPlayerDied()
	{
		if (highScore < currScore)
		{
			highScore = currScore;
		}
		
		base.OnPlayerDied();
	}

	public override void OnInitializePlayer()
	{
		base.OnInitializePlayer();
		currScore = 0;
	}

}