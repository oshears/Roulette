using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverBannerController : MonoBehaviour
{


	[SerializeField] UIScriptableObject _uiScriptableObject;
	[SerializeField] GameObject _gameOverTextGameObject;
	

	void Awake()
	{
		if(_uiScriptableObject.playerWon)
		{
			_gameOverTextGameObject.GetComponent<TextMeshProUGUI>().text = "You won!";
			GetComponent<Image>().color = new Color(0,159,89);
		}
		else
		{
			_gameOverTextGameObject.GetComponent<TextMeshProUGUI>().text = "You were killed!";
			GetComponent<Image>().color = new Color(159,0,0);
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}


	
}
