using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NpcScriptableObject", menuName = "ScriptableObjects/NpcScriptableObject")]
public class NpcScriptableObject : GamePlayerScriptableObject
{
	
	public UnityEvent<string> updateNpcSpeechEvent;

	public CardSO PlayPreGunPhaseCard()
	{
		foreach(CardSO card in _cardsInHand)
		{
			if (card.GetActionType() == CardActionType.Joker || card.GetActionType() == CardActionType.EmptyShell)
			{
				RemoveCard(card);
				OnUpdateNpcSpeech(card.GetActionType() == CardActionType.EmptyShell ? "Looks like I'll be skipping my turn!" : "Bet you didn't see that coming!");
				return card;
			}
		}
		
		return null;
	}
	
	public CardSO PlayPostGunPhaseCard()
	{
		foreach(CardSO card in _cardsInHand)
		{
			if (card.GetActionType() == CardActionType.DrawTwo || card.GetActionType() == CardActionType.Bullet || card.GetActionType() == CardActionType.TargetNextPlayer)
			{
				RemoveCard(card);
				
				if (card.GetActionType() == CardActionType.DrawTwo )
				{
					OnUpdateNpcSpeech("I'm going to need some more of these.");
				}
				else if(card.GetActionType() == CardActionType.Bullet )
				{
					OnUpdateNpcSpeech("Let's make things more interesting!");
				}
				else if(card.GetActionType() == CardActionType.TargetNextPlayer )
				{
					OnUpdateNpcSpeech("Let's see if you can survive this!");
				}
				
				return card;
			}
		}
		
		return null;
	}
	
	public void OnUpdateNpcSpeech(string text)
	{
		updateNpcSpeechEvent.Invoke(text);
	}

	public override void RemoveHeart()
	{
		base.RemoveHeart();
	}

	

}