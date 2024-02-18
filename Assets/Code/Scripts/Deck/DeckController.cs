using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckController : MonoBehaviour
{
	
	
	[SerializeField]
	GameObject deckCard;
	
	int _numCards = 1;
	
	private List<GameObject> _cardsInDeck = new List<GameObject>();
	
	[SerializeField] DeckScriptableObject _deckScriptableObject;
	
	void Awake()
	{
		_deckScriptableObject.discardCardEvent.AddListener(UpdateDeckViewEventHandler);
		_deckScriptableObject.drawCardEvent.AddListener(UpdateDeckViewEventHandler);
		_deckScriptableObject.drawNpcCardEvent.AddListener(UpdateDeckViewEventHandler);
		_deckScriptableObject.shuffleCardsEvent.AddListener(UpdateDeckViewEventHandler);
		
		_numCards = _deckScriptableObject.GetNumCardsInDeck();
		
		// _cardsInDeck = new List<GameObject>();
	}
	
	// Start is called before the first frame update
	void Start()
	{
		GenerateCards();
	}

	// Update is called once per frame
	void Update()
	{
		
		
	}
	
	void GenerateCards()
	{
		RemoveAllCards();
		
		for(int i = 0; i < _numCards; i++)
		{
			GameObject card = Instantiate(deckCard, Vector3.zero, Quaternion.identity);
			card.transform.SetParent(transform,false);
			card.transform.position += Vector3.up * i * 0.01f;
			_cardsInDeck.Add(card);
		}
		
	}
	
	void RemoveAllCards()
	{
		// Delete all old card game objects
		foreach(GameObject card in _cardsInDeck)
		{
			Destroy(card);
		}
		_cardsInDeck.Clear();
	}
	
	void UpdateDeckViewEventHandler()
	{
		_numCards = _deckScriptableObject.GetNumCardsInDeck();
		GenerateCards();
	}
	
	// void OnGUI()
	// {
	// 	GUILayout.BeginArea(new Rect(0, Screen.height - 150, 150, 150));
	// 	if (GUILayout.Button("Add Card to Deck"))
	// 	{
	// 		foreach (GameObject card in _cardsInDeck)
	// 		{
	// 			Destroy(card);
	// 		}
	// 		_cardsInDeck.Clear();
			
	// 		_numCards =  (_numCards % 32) + 1;
			
	// 		GenerateCards();
	// 	}
	// 	GUILayout.EndArea();
	// }
	
	
}
