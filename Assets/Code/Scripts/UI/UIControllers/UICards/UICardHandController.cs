using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICardHandController : MonoBehaviour
{
	
	
	[SerializeField]
	GameObject handCard;
	
	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	private List<GameObject> _cardsInHand = new List<GameObject>();
	
	[SerializeField]
	PlayerScriptableObject playerScriptableObject;
	
	
	
	// Start is called before the first frame update
	void Start()
	{
		
		// _cardsInHand = new List<GameObject>();
		// uiScriptableObject.drawButtonClick.AddListener(DrawButtonClickEventHandler);
		uiScriptableObject.updateHandCardsEvent.AddListener(UpdateHandCardsEventHandler);

		RegenerateCards();
	}

	// Update is called once per frame
	void Update()
	{
		
		
	}
	
	void OnEnable()
	{
		RegenerateCards();
	}
	
	void UpdateHandCardsEventHandler()
	{
		RegenerateCards();
	}
	
	void RegenerateCards()
	{
		RemoveAllCards();

		int numCards = playerScriptableObject.cardsInHand.Count;
		if (playerScriptableObject.cardsInHand.Count == 0){
			return;
		}

		int cardSpreadDistance = 100 * numCards;
		int distanceBetweenCards = cardSpreadDistance / numCards;
		float currentCardPositionX = distanceBetweenCards * 0.5f;
		int startingOffset = cardSpreadDistance / 2;
		
		
		int maxShiftDown = 20 * numCards;
		int minShiftDown = -1 * (maxShiftDown / 2);
		int shiftBetweenCards = maxShiftDown / numCards;
		float currentCardPositionY = minShiftDown;
		

		int maxRotationDegrees = -60;
		int rotationBetweenCards = maxRotationDegrees / numCards;
		float firstCardRotation = transform.rotation.z - (maxRotationDegrees / 2);
		float currentCardRotation = rotationBetweenCards * 0.5f;

		
		for(int i = 0; i < numCards; i++)
		{
			CardSO cardSO = playerScriptableObject.cardsInHand[i];
			GameObject card = Instantiate(handCard, Vector3.zero, Quaternion.identity);
			card.GetComponent<UIHandCardController>().SetCardIndex(i);
			
			card.SetActive(true);
			card.transform.SetParent(transform,false);
			
			card.transform.position += Vector3.right * (currentCardPositionX - startingOffset) ;
			card.transform.rotation = Quaternion.Euler(0f,0f,firstCardRotation + currentCardRotation);
			
			_cardsInHand.Add(card);
			
			currentCardPositionX += distanceBetweenCards;
			currentCardPositionY += shiftBetweenCards;
			currentCardRotation += rotationBetweenCards;
		}
		
	}
	
	// void OnGUI()
	// {
	// 	GUILayout.BeginArea(new Rect(Screen.width - 150, Screen.height - 150, 150, 150));
	// 	if (GUILayout.Button("Add Card"))
	// 	{
	// 		numCards =  (numCards + 1) % 7;

	// 		RegenerateCards();
			
	// 	}
	// 	GUILayout.EndArea();
	// }
	
	void RemoveAllCards()
	{
		// Delete all old card game objects
		foreach(GameObject card in _cardsInHand)
		{
			Destroy(card);
		}
		_cardsInHand.Clear();
	}
	
}
