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
	public UnityEvent playerInitEvent;
	public UnityEvent playerAddCardEvent;
	public UnityEvent playerPlayedCardEvent;
	public UnityEvent playerRemoveCardEvent;
	
	public virtual void OnInitializePlayer()
	{
		_heartRemaining = 2;
		InitializePlayerHand();
		playerInitEvent.Invoke();
	}
	
	public void InitializePlayerHand()
	{
		_cardsInHand.Clear();
	}
	
	public void AddCard(CardSO card)
	{
		_cardsInHand.Add(card);
		playerAddCardEvent.Invoke();
	}
	
	public void RemoveCard(CardSO card)
	{
		_cardsInHand.Remove(card);
		playerRemoveCardEvent.Invoke();
	}
	
	public List<CardSO> RemoveAllCards()
	{
		List<CardSO> removedCards = new List<CardSO>();
		foreach(CardSO card in _cardsInHand)
		{
			removedCards.Add(card);
		}
		_cardsInHand.Clear();
		playerRemoveCardEvent.Invoke();
		return removedCards;
	}
	
	public virtual void RemoveHeart()
	{
		_heartRemaining--;
		playerShotEvent.Invoke();
	}
	
	public int GetHeartsRemaining()
	{
		return _heartRemaining;
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
		CardSO card = _cardsInHand[i];
		RemoveCard(card);
		return card;
	}
	
	public CardSO PlayPreGunPhaseCard(int i)
	{
		if (i > _cardsInHand.Count - 1)
		{
			Debug.LogError($"ERROR: Trying to access card {i} in a list of {_cardsInHand.Count} cards");
		}
		CardSO card = _cardsInHand[i];
		
		if (CardIsValidPreGunPhaseCard(card.GetActionType()))
		{
			RemoveCard(card);
			return card;
		}
		
		return null;
	}
	
	public CardSO PlayPostGunPhaseCard(int i)
	{
		if (i > _cardsInHand.Count - 1)
		{
			Debug.LogError($"ERROR: Trying to access card {i} in a list of {_cardsInHand.Count} cards");
		}
		CardSO card = _cardsInHand[i];
		
		if (CardIsValidPostGunPhaseCard(card.GetActionType()))
		{
			RemoveCard(card);
			return card;
		}
		
		return null;
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
	
	public virtual void OnPlayerDied()
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
	
	public bool CardIsValidPreGunPhaseCard(CardActionType cardAction)
	{
		return cardAction == CardActionType.Joker || cardAction == CardActionType.EmptyShell;
	}
	
	public bool CardIsValidPostGunPhaseCard(CardActionType cardAction)
	{
		// return cardAction != CardActionType.EmptyShell;
		return cardAction == CardActionType.DrawTwo || cardAction == CardActionType.Bullet || cardAction == CardActionType.TargetNextPlayer;
	}
	
	public bool HasValidPreGunPhaseCard()
	{
		foreach (CardSO card in _cardsInHand)
		{
			if (card.GetActionType() == CardActionType.Joker || card.GetActionType() == CardActionType.EmptyShell) return true;
		}
		
		return false;
	}
	
	public bool HasValidPostGunPhaseCard()
	{
		foreach (CardSO card in _cardsInHand)
		{
			if (card.GetActionType() == CardActionType.DrawTwo || card.GetActionType() == CardActionType.Bullet || card.GetActionType() == CardActionType.TargetNextPlayer) return true;
		}
		
		return false;
	}
}