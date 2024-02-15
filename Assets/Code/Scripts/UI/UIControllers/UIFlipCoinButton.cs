using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIFlipCoinButton : MonoBehaviour
{
	
	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	void Awake()
	{
		GetComponent<Button>().onClick.AddListener(FlipCoinButtonEventHandler);
	}

	void Update()
	{
		
	}
	
	void FlipCoinButtonEventHandler()
	{
		Debug.Log("Coin Flip Button Pressed!");
		uiScriptableObject.OnFlipCoinButton();
	}
	
	
	
}