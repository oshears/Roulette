using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DeckScriptableObject", menuName = "ScriptableObjects/DeckScriptableObject")]
public class DeckScriptableObject : ScriptableObject
{
	int _numCardsInDeck = 0;
	
	List<Card> _deckOfCards = new List<Card>();
	
	public UnityEvent drawCardEvent;
	public UnityEvent giveCardEvent;
	public UnityEvent discardCardEvent;
	public UnityEvent shuffleCardsEvent;
	
	public void OnInitializeDeck()
	{
		
		
		_numCardsInDeck = 24;
		for (int i = 0; i < _numCardsInDeck; i++)
		{
			_deckOfCards.Add(new Card((Card.CardType) (i % 5), Random.Range(0,5)));
		}
	}
	
	public void OnShuffleDeck()
	{
		shuffleCardsEvent.Invoke();
		
		// Fisher-Yates shuffle:
		int n = _deckOfCards.Count;  
		while (n > 1) {  
			n--;  
			int k = Random.Range(0,n + 1);  
			Card card = _deckOfCards[k];  
			_deckOfCards[k] = _deckOfCards[n];  
			_deckOfCards[n] = card;  
		}  
	}
	
}