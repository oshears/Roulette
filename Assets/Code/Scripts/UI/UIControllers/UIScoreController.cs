using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreController : MonoBehaviour
{


	[SerializeField] UIScriptableObject _uiScriptableObject;
	[SerializeField] TextMeshProUGUI scoreText;

	void Awake()
	{
		scoreText.text = $"Score: {_uiScriptableObject.playerScore}";
		
		_uiScriptableObject.resetScoresEvent.AddListener(UpdateScoresEventHandler);
		_uiScriptableObject.updateScoresEvent.AddListener(UpdateScoresEventHandler);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	
	void UpdateScoresEventHandler()
	{
		scoreText.text = $"Score: {_uiScriptableObject.playerScore}";
	}


	
}
