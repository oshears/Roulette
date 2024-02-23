using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NpcSpeechBubbleController : MonoBehaviour
{
	
	[SerializeField]
	GameObject speechTextGameObject;
	
	[SerializeField]
	NpcScriptableObject npcScriptableObject;
	
	float _speechTimer = 0;
	
	void Awake()
	{
		npcScriptableObject.updateNpcSpeechEvent.AddListener(UpdateNpcSpeechEvent);
		GetComponent<SpriteRenderer>().enabled = false;
		speechTextGameObject.GetComponent<TextMeshPro>().enabled = false;
	}
	
	private void OnEnable() {

	}

	void Update()
	{
		if (_speechTimer > 5)
		{
			GetComponent<SpriteRenderer>().enabled = false;
			speechTextGameObject.GetComponent<TextMeshPro>().enabled = false;
		}
		else
		{
			_speechTimer += Time.deltaTime;
		}
	}
	
	void UpdateNpcSpeechEvent(String text)
	{
		GetComponent<SpriteRenderer>().enabled = true;
		speechTextGameObject.GetComponent<TextMeshPro>().enabled = true;
		speechTextGameObject.GetComponent<TextMeshPro>().text = text;
		_speechTimer = 0;
	}
	
}