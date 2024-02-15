using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDrawButtonController : MonoBehaviour
{
	
	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	void Awake()
	{
		GetComponent<Button>().onClick.AddListener(DrawButtonEventHandler);
	}

	void Update()
	{
		
	}
	
	void DrawButtonEventHandler()
	{
		uiScriptableObject.OnDrawButton();
	}
	
	
	
}