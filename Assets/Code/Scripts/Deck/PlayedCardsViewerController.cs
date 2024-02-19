using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayedCardsViewerController : MonoBehaviour
{


	[SerializeField] GameObject[] _playedCards;
	
	[SerializeField] UIScriptableObject _uiScriptableObject;

	void Awake()
	{
		// _uiScriptableObject.
		_uiScriptableObject.playedCardsReadyEvent.AddListener(PlayedCardsReadyEventHandler);
		_uiScriptableObject.setCardBannerVisibleEvent.AddListener(SetCardBannerVisibleEventHandler);
		
		for (int i = 0; i < _playedCards.Length; i++)
		{
			_playedCards[i].SetActive(false);
		}
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	
	void PlayedCardsReadyEventHandler()
	{
		for (int i = 0; i < _playedCards.Length; i++)
		{
			_playedCards[i].GetComponent<SpriteRenderer>().sprite = _uiScriptableObject.cardBannerCards[i].GetFrontOfCard();
			_playedCards[i].SetActive(true);
		}
	}
	
	void SetCardBannerVisibleEventHandler(bool visible)
	{
		for (int i = 0; i < _playedCards.Length; i++)
		{
			_playedCards[i].SetActive(visible);
		}
	}


	
}
