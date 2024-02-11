using System;
using System.Collections;
using System.Collections.Generic;
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
		bannerTextTransform.GetComponent<Text>().text = uiScriptableObject.bannerText;
	}
	
	void ContinueButtonEventHandler()
	{
		bannerTextTransform.gameObject.SetActive(false);
		bannerButtonTransform.gameObject.SetActive(false);
		_image.enabled = false;
		uiScriptableObject.OnBannerContinue();
	}
	
	void ShowBannerEventHandler()
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