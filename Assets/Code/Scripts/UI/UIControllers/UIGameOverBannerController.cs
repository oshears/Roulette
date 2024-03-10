using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverBannerController : MonoBehaviour
{


	[SerializeField] UIScriptableObject _uiScriptableObject;
	[SerializeField] GameObject _gameOverTextGameObject;
	
	[SerializeField] GameObject _gameOverImageGameObject;
	
	[SerializeField] Sprite _winImage;
	[SerializeField] Sprite _loseImage;
	[SerializeField] TextMeshProUGUI highScoreText;
	[SerializeField] TextMeshProUGUI playerScoreText;

	void Awake()
	{
		if(_uiScriptableObject.playerWon)
		{
			_gameOverTextGameObject.GetComponent<TextMeshProUGUI>().text = "You won!";
			GetComponent<Image>().color = new Color(GetFloatColor(122), GetFloatColor(122), GetFloatColor(122));
			_gameOverImageGameObject.GetComponent<Image>().sprite = _winImage;
		}
		else
		{
			_gameOverTextGameObject.GetComponent<TextMeshProUGUI>().text = "You were killed!";
			GetComponent<Image>().color = new Color(GetFloatColor(85), GetFloatColor(55), GetFloatColor(55));
			_gameOverImageGameObject.GetComponent<Image>().sprite = _loseImage;
		}
		highScoreText.text = $"High Score {_uiScriptableObject.highScore}";
		playerScoreText.text = $"Your Score {_uiScriptableObject.playerScore}";
	}
	
	private void OnEnable() {
		if(_uiScriptableObject.playerWon)
		{
			_gameOverTextGameObject.GetComponent<TextMeshProUGUI>().text = "You won!";
			GetComponent<Image>().color = new Color(GetFloatColor(122), GetFloatColor(122), GetFloatColor(122));
			_gameOverImageGameObject.GetComponent<Image>().sprite = _winImage;
		}
		else
		{
			_gameOverTextGameObject.GetComponent<TextMeshProUGUI>().text = "You were killed!";
			GetComponent<Image>().color = new Color(GetFloatColor(85), GetFloatColor(55), GetFloatColor(55));
			_gameOverImageGameObject.GetComponent<Image>().sprite = _loseImage;
		}
		highScoreText.text = $"High Score {_uiScriptableObject.highScore}";
		playerScoreText.text = $"Your Score {_uiScriptableObject.playerScore}";
	}
	
	float GetFloatColor(float value)
	{
		return value / 256f;
	}

	// Update is called once per frame
	void Update()
	{
		
	}


	
}
