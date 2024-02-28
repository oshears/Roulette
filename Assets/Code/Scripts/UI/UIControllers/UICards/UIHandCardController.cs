using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHandCardController : MonoBehaviour
{

	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	[SerializeField]
	GameObject handCardSpriteGameObject;
	
	
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

		
	}

	public void SetCardIndex(int index)
	{
		handCardSpriteGameObject.GetComponent<UIHandCardSpriteController>().SetCardIndex(index);
	}
	


}
