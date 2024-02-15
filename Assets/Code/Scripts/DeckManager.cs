using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
	[SerializeField, Tooltip("Contains all cards of the deck")]
	private List<CardSO> deck;
	private int deckIndex;
	
	void Start()
	{
		// yes. so there are 5 different type of cards
		// bullet, empty, double card, plus one trigger, and joker
		// there are number 1-6, each number have 2 bullet, 1 empty(skip), 1 double card, 1 trigger, total of 30 cards
		// and there are 2 jokers
		
	}

	void Awake()
	{
		Shuffle();
	}

	public CardSO DrawCard()
	{
		if(deckIndex == deck.Count)
		{
			Shuffle();
		}
		return deck[deckIndex++];
	}

	public void NewGame()
	{
		Shuffle();
	}

	private void Shuffle()
	{
		deckIndex = 0;
		// Fisher-Yates shuffle
		for (int i = deck.Count - 1; i > 0; i--)
		{
			int index = Random.Range(0, i + 1);
			CardSO tempValue = deck[index];
			deck[index] = deck[i];
			deck[i] = tempValue;
		}
	}
}
