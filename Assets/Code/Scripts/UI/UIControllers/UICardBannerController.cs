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
	
	void Awake()
	{
		
	}
	
	void OnEnable() {
		playerCard.GetComponent<Image>().sprite = uiScriptableObject.cardBannerCards[0].GetFrontOfCard();
		
		for(int i = 0; i < npcCards.Length; i++)
		{
			npcCards[i].GetComponent<Image>().sprite = uiScriptableObject.cardBannerCards[i + 1].GetFrontOfCard();
		}
	}
	
	void Update()
	{
		
	}
	
	void ContinueButtonEventHandler()
	{

	}
	
}