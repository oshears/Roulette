using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIObjectiveController : MonoBehaviour
{
	
	[SerializeField]
	GameObject objectiveTextTransform;
	
	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	void Awake()
	{
		uiScriptableObject.updateObjectiveEvent.AddListener(UpdateObjectiveEventHandler);
	}
	
	private void OnEnable() {

	}

	void Update()
	{
		
	}
	
	void UpdateObjectiveEventHandler(String text)
	{
		objectiveTextTransform.GetComponent<TextMeshProUGUI>().text = text;
	}
	
}