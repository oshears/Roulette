using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITextBannerController : MonoBehaviour
{
	
	[SerializeField]
	Transform bannerTextTransform;
	
	[SerializeField]
	Transform bannerButtonTransform;
	
	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	Image _image;
	
	
	void Start()
	{
		bannerButtonTransform.gameObject.GetComponent<Button>().onClick.AddListener(ContinueButtonEventHandler);
		
		_image = GetComponent<Image>();
		
		
		uiScriptableObject.showBannerEvent.AddListener(ShowBannerEventHandler);
		uiScriptableObject.startGameEvent.AddListener(StartGameEventHandler);
		
		// Disable banner visibility on init
		DisableBannerAction();
	}

	void Update()
	{
		
	}
	
	void StartGameEventHandler()
	{
		bannerTextTransform.GetComponent<TextMeshProUGUI>().text = uiScriptableObject.bannerText;
		EnableBannerAction();
	}
	
	void ContinueButtonEventHandler()
	{
		DisableBannerAction();
		uiScriptableObject.OnBannerContinue();
	}
	
	void ShowBannerEventHandler()
	{
		EnableBannerAction();
	}
	
	void EnableBannerAction()
	{
		bannerTextTransform.gameObject.SetActive(true);
		bannerButtonTransform.gameObject.SetActive(true);
		_image.enabled = true;
	}
	
	void DisableBannerAction()
	{
		bannerTextTransform.gameObject.SetActive(false);
		bannerButtonTransform.gameObject.SetActive(false);
		_image.enabled = false;
	}
		
}