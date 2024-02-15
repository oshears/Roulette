using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NpcScriptableObject", menuName = "ScriptableObjects/NpcScriptableObject")]
public class NpcScriptableObject : GamePlayerScriptableObject
{

	public CardSO PlayPreGunPhaseCard()
	{
		foreach(CardSO card in cardsInHand)
		{
			if (card.GetActionType() == CardActionType.Joker || card.GetActionType() == CardActionType.EmptyShell)
			{
				RemoveCard(card);
				return card;
			}
		}
		
		return null;
	}
	
	public CardSO PlayPostGunPhaseCard()
	{
		foreach(CardSO card in cardsInHand)
		{
			if (card.GetActionType() == CardActionType.DrawTwo || card.GetActionType() == CardActionType.Bullet || card.GetActionType() == CardActionType.TargetNextPlayer)
			{
				RemoveCard(card);
				return card;
			}
		}
		
		return null;
	}
	

}