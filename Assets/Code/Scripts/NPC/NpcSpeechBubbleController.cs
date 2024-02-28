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
	float _charTimer = 0;
	
	int _visibleChars = 0;
	int _totalChars = 0;
	bool _writingOutChars = false;
	
	bool _speechTimerEnabled = false;
	
	TextMeshPro _textMeshPro;
	
	void Awake()
	{
		npcScriptableObject.updateNpcSpeechEvent.AddListener(UpdateNpcSpeechEvent);
		GetComponent<SpriteRenderer>().enabled = false;
		_textMeshPro = speechTextGameObject.GetComponent<TextMeshPro>();
		_textMeshPro.enabled = false;
	}
	
	private void OnEnable() {

	}

	void Update()
	{	
		if (_speechTimerEnabled){
			if (_speechTimer > 5)
			{
				GetComponent<SpriteRenderer>().enabled = false;
				_textMeshPro.enabled = false;
				_speechTimerEnabled = false;
			}
			else
			{
				_speechTimer += Time.deltaTime;
			}
		}
		
		if (_writingOutChars)
		{
			if (_charTimer < 0.05)
			{
				_charTimer += Time.deltaTime;
			}
			else
			{
				_visibleChars++;
				_textMeshPro.maxVisibleCharacters = _visibleChars;
				_charTimer = 0;
				
				if (_visibleChars >= _totalChars)
				{
					_writingOutChars = false;
					_speechTimerEnabled = true;
				}
				
			}
		}
		
	}
	
	void UpdateNpcSpeechEvent(string text)
	{
		GetComponent<SpriteRenderer>().enabled = true;
		_textMeshPro.enabled = true;
		_textMeshPro.text = text;
		_speechTimer = 0;
		_charTimer = 0;

		_totalChars = text.Length;
		_visibleChars = 1;
		_textMeshPro.maxVisibleCharacters = _visibleChars;
		_writingOutChars = true;
		_speechTimerEnabled = false;
	}
	
}