using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPlayerCardBannerController : MonoBehaviour
{
	
	[SerializeField]
	GameObject bannerTextGameObject;
	
	[SerializeField]
	GameObject bannerButtonGameObject;
	
	[SerializeField]
	GameObject bannerCardImageGameObject;
	
	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	Image _image;
	
	
	void Awake()
	{
		bannerButtonGameObject.GetComponent<Button>().onClick.AddListener(ContinueButtonEventHandler);
		
		_image = GetComponent<Image>();
		
		
		// uiScriptableObject.showBannerEvent.AddListener(ShowBannerEventHandler);
		// uiScriptableObject.startGameEvent.AddListener(StartGameEventHandler);
		
		// Disable banner visibility on init
		// DisableBannerAction();
		bannerTextGameObject.SetActive(true);
		bannerButtonGameObject.SetActive(true);
		_image.enabled = true;
	}
	
	private void OnEnable() {
		bannerTextGameObject.GetComponent<TextMeshProUGUI>().text = uiScriptableObject.bannerText;
		bannerCardImageGameObject.GetComponent<Image>().sprite = uiScriptableObject.playerCardBannerCard.GetFrontOfCard();
	}

	void Update()
	{
		
	}
	
	void ContinueButtonEventHandler()
	{
		gameObject.SetActive(false);
		uiScriptableObject.OnPlayerCardBannerButton();
	}
	
}