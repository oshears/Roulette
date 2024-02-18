using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEditor.Rendering;

// [CreateAssetMenu(fileName = "GamePlayerScriptableObject", menuName = "ScriptableObjects/GamePlayerScriptableObject")]
public class GamePlayerScriptableObject : ScriptableObject
{
	
	protected List<CardSO> _cardsInHand = new List<CardSO>();
	
	[SerializeField]
	int _heartRemaining = 2;
	
	public bool isDealer {get; private set;}
	
	[SerializeField]
	public Vector3 gunRotation;
	
	[SerializeField]
	// public int playerId {get; private set;}
	public int playerId;
	
	public UnityEvent playerDiedEvent;
	public UnityEvent playerShotEvent;
	
	public void InitializePlayer()
	{
		_heartRemaining = 2;
		InitializePlayerHand();
	}
	
	public void InitializePlayerHand()
	{
		_cardsInHand.Clear();
	}
	
	public void AddCard(CardSO card)
	{
		_cardsInHand.Add(card);
	}
	
	public void RemoveCard(CardSO card)
	{
		_cardsInHand.Remove(card);
	}
	
	public void RemoveHeart()
	{
		_heartRemaining--;
		playerShotEvent.Invoke();
	}
	
	public bool IsPlayerAlive()
	{
		return _heartRemaining > 0;
	}
	
	public bool HasFullHand()
	{
		return _cardsInHand.Count > 5;
	}
	
	public CardSO PlayCard()
	{
		foreach (CardSO card in _cardsInHand)
		{
			if (card.GetActionType() != CardActionType.Joker)
			{
				RemoveCard(card);
				return card;
			}
		}
		
		Debug.LogError($"ERROR: No valid cards can be played from {GetPlayerName()}'s hand!");
		
		
		// DEBUG: Remove this later
		CardSO jokerCard = _cardsInHand[0];
		RemoveCard(jokerCard);
		return jokerCard;
		
		
		// return null;
		
	}
	
	public CardSO PlayCard(int i)
	{
		if (i > _cardsInHand.Count - 1)
		{
			Debug.LogError($"ERROR: Trying to access card {i} in a list of {_cardsInHand.Count} cards");
		}
		CardSO npcCard = _cardsInHand[i];
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
	
	public void OnPlayerDied()
	{
		playerDiedEvent.Invoke();
	}
	
	public CardSO GetCard(int i)
	{
		return _cardsInHand[i];
	}
	
	public int GetNumCardsInHand()
	{
		return _cardsInHand.Count;
	}
	
	
}