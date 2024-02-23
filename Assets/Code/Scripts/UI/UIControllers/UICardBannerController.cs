using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICardBannerController : MonoBehaviour
{
	
	// [SerializeField]
	// GameObject npcCard0;

	// [SerializeField]
	// GameObject npcCard1;

	// [SerializeField]
	// GameObject npcCard2;
	[SerializeField]
	GameObject[] npcCards;

	[SerializeField]
	GameObject playerCard;
	
	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	[SerializeField]
	Sprite _cardBackSprite;
	
	void Awake()
	{
		
	}
	
	void OnEnable() {
		if (uiScriptableObject.cardBannerCards.Count < 1)
		{
			Debug.LogError("Error! Could not update card banner because there are no cards to display!");	
			return;
		}
		
		playerCard.GetComponent<Image>().sprite = uiScriptableObject.cardBannerCards[0].GetFrontOfCard();
		
		for(int i = 0; i < npcCards.Length; i++)
		{
			if (uiScriptableObject.cardBannerCards[i + 1] != null)
			{
				npcCards[i].GetComponent<Image>().sprite = uiScriptableObject.cardBannerCards[i + 1].GetFrontOfCard();
			}
			else
			{
				npcCards[i].GetComponent<Image>().sprite = _cardBackSprite;
			}
		}
	}
	
	void Update()
	{
		
	}
	
	void ContinueButtonEventHandler()
	{

	}
	
}