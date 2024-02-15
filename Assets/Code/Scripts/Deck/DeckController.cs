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
	
	private List<GameObject> _cardsInDeck;
	
	// Start is called before the first frame update
	void Start()
	{
		_cardsInDeck = new List<GameObject>();
		GenerateCards();
	}

	// Update is called once per frame
	void Update()
	{
		
		
	}
	
	void GenerateCards()
	{
		for(int i = 0; i < _numCards; i++)
		{
			GameObject card = Instantiate(deckCard, Vector3.zero, Quaternion.identity);
			card.transform.SetParent(transform,false);
			card.transform.position += Vector3.up * i * 0.01f;
			_cardsInDeck.Add(card);
		}
		
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
