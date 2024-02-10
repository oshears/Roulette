using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHandController : MonoBehaviour
{
	
	
	[SerializeField]
	GameObject handCard;
	
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
		int cardSpreadDistance = 100 * _numCards;
		int distanceBetweenCards = cardSpreadDistance / _numCards;
		float firstCardPositionX = transform.position.x - (cardSpreadDistance / 2);
		float currentCardPositionX = distanceBetweenCards * 0.5f;
		
		
		
		int maxShiftDown = 20 * _numCards;
		int minShiftDown = -1 * (maxShiftDown / 2);
		int shiftBetweenCards = maxShiftDown / _numCards;
		float firstCardPositionY = (transform.position.y + 300f);
		// float firstCardShiftDown = transform.position.y - maxShiftDown;
		// float currentCardShiftDown = shiftBetweenCards;
		float currentCardPositionY = minShiftDown;
		

		int maxRotationDegrees = -60;
		int rotationBetweenCards = maxRotationDegrees / _numCards;
		float firstCardRotation = transform.rotation.z - (maxRotationDegrees / 2);
		float currentCardRotation = rotationBetweenCards * 0.5f;

		
		for(int i = 0; i < _numCards; i++)
		{
			
			// Quaternion rotation = Quaternion.Euler(0f,0f,0f);
			
			// Instantiate(handCard,position,rotation);
			GameObject card = Instantiate(handCard, Vector3.zero, Quaternion.identity);
			card.transform.SetParent(transform,true);
			
			// Vector3 newPosition = new Vector3(firstCardPositionX + currentCardPositionX, firstCardPositionY - Math.Abs(currentCardPositionY), card.transform.position.z);
			// Vector3 newPosition = new Vector3(firstCardPositionX + currentCardPositionX
			// card.transform.position = card.transform.position + Vector3.up * 300f;
			// card.transform.position += newPosition;
			// card.transform.rotation = rotation;
			// card.transform.position = newPosition;
			card.transform.position += Vector3.left * (firstCardPositionX + currentCardPositionX);
			card.transform.rotation = Quaternion.Euler(0f,0f,firstCardRotation + currentCardRotation);
			
			currentCardPositionX += distanceBetweenCards;
			currentCardPositionY += shiftBetweenCards;
			currentCardRotation += rotationBetweenCards;
		}
		
	}
	
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width - 500, Screen.height - 500, 500, 500));
		if (GUILayout.Button("Add Card"))
		{
			for(int i = transform.childCount - 1; i >= 0; i--)
			{
				Destroy(transform.GetChild(i).gameObject);
			}
			_numCards =  (_numCards % 6) + 1;
			GenerateCards();
		}
		GUILayout.EndArea();
	}
	
	
}
