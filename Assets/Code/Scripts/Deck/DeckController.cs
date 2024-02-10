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
		
		for(int i = 0; i < _numCards; i++)
		{
			
			GameObject card = Instantiate(deckCard, Vector3.zero, Quaternion.identity);
			card.transform.SetParent(transform,false);
			
			
			card.transform.position += Vector3.up * i * 0.01f;

		}
		
	}
	
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0, Screen.height - 150, 150, 150));
		if (GUILayout.Button("Add Card to Deck"))
		{
			for(int i = transform.childCount - 1; i >= 0; i--)
			{
				Destroy(transform.GetChild(i).gameObject);
			}
			_numCards =  (_numCards % 24) + 1;
			GenerateCards();
		}
		GUILayout.EndArea();
	}
	
	
}
