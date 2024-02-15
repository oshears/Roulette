using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEditor;

[CreateAssetMenu(fileName = "DeckScriptableObject", menuName = "ScriptableObjects/DeckScriptableObject")]
public class DeckScriptableObject : ScriptableObject
{
	// List<Card> _deckOfCards;
	
	
	// List<CardSO> _cardScriptableObjects;
	[SerializeField]
	CardSO[] cardsArray;
	Queue<CardSO> _cardQueue;
	
	public UnityEvent drawCardEvent;
	// public UnityEvent giveCardEvent;
	public UnityEvent discardCardEvent;
	public UnityEvent shuffleCardsEvent;
	
	public void OnInitializeDeck()
	{
		_cardQueue = new Queue<CardSO>(cardsArray);
		OnShuffleDeck();
	}
	
	public void OnShuffleDeck()
	{
		shuffleCardsEvent.Invoke();
		
		// Fisher-Yates shuffle:
		CardSO[] tmpCardArray = _cardQueue.ToArray();
		int n = tmpCardArray.Length;  
		while (n > 1) {  
			n--;  
			int k = Random.Range(0,n + 1);  
			CardSO card = tmpCardArray[k];  
			tmpCardArray[k] = tmpCardArray[n];  
			tmpCardArray[n] = card;  
		}
		
		_cardQueue = new Queue<CardSO>(tmpCardArray);  
	}
	
	public CardSO OnDrawCard()
	{
		drawCardEvent.Invoke();
		return _cardQueue.Dequeue();
		
	}
	
	// public void DiscardCardEventHandler
	
}