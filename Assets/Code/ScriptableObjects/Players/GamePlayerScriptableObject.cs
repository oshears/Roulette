using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

// [CreateAssetMenu(fileName = "GamePlayerScriptableObject", menuName = "ScriptableObjects/GamePlayerScriptableObject")]
public class GamePlayerScriptableObject : ScriptableObject
{
	
	public List<CardSO> cardsInHand {get; private set;}
	
	int _heartRemaining = 2;
	
	public void InitializePlayer()
	{
		_heartRemaining = 2;
		InitializePlayerHand();
	}
	
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
	
	public void RemoveHeart()
	{
		_heartRemaining--;
	}
	
	public bool IsPlayerAlive()
	{
		return _heartRemaining > 0;
	}
	
	public bool HasFullHand()
	{
		return cardsInHand.Count > 5;
	}
	
	public CardSO PlayCard()
	{
		CardSO npcCard = cardsInHand[0];
		RemoveCard(npcCard);
		return npcCard;
	}
	
	public CardSO PlayCard(int i)
	{
		CardSO npcCard = cardsInHand[i];
		RemoveCard(npcCard);
		return npcCard;
	}
	
	
}