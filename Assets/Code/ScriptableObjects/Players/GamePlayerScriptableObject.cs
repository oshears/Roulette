using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEditor.Rendering;

// [CreateAssetMenu(fileName = "GamePlayerScriptableObject", menuName = "ScriptableObjects/GamePlayerScriptableObject")]
public class GamePlayerScriptableObject : ScriptableObject
{
	
	public List<CardSO> cardsInHand {get; private set;}
	
	int _heartRemaining = 2;
	
	public bool isDealer {get; private set;}
	
	public Vector3 GunRotation;
	
	public int playerId {get; private set;}
	
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
		foreach (CardSO card in cardsInHand)
		{
			if (card.GetActionType() != CardActionType.Joker)
			{
				RemoveCard(card);
				return card;
			}
		}
		
		Debug.LogError($"ERROR: No valid cards can be played from {GetPlayerName()}'s hand!");
		
		return null;
		
	}
	
	public CardSO PlayCard(int i)
	{
		CardSO npcCard = cardsInHand[i];
		RemoveCard(npcCard);
		return npcCard;
	}
	
	public void SetIsDealer(bool isDealer)
	{
		this.isDealer = isDealer;
	}
	
	public virtual bool IsNpc()
	{
		return true;
	}
	
	public string GetPlayerName()
	{
		if (IsNpc())
		{
			return $"NPC {playerId}";
		}
		else
		{
			return $"Player {playerId}";
		}
	}
	
	
}