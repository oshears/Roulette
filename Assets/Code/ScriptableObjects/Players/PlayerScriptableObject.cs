using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
	
	public List<CardSO> cardsInHand {get; private set;}
	
	public void InitializePlayerHand()
	{
		cardsInHand.Clear();
	}
	
	public void AddCard(CardSO card)
	{
		cardsInHand.Add(card);
	}
	
	public void RemoveCard(CardSO card)
	{
		cardsInHand.Remove(card);
	}
	
	
	
}