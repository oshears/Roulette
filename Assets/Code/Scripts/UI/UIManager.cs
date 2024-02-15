using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
	//UnityEvent rotateGunEvent;
	public UIScriptableObject uiScriptableObject;
	public PlayerScriptableObject playerScriptableObject;
	
	public UIManagerStateMachine stateMachine;

	[SerializeField]
	public GameObject drawCardButton;
	
	[SerializeField]
	public GameObject textBanner;
	
	[SerializeField]
	public GameObject playerCardHand;
	
	[SerializeField]
	public GameObject cardBanner;
	
	[SerializeField]
	public GameObject playerCardBanner;
	
	[SerializeField]
	public GameObject flipCoinButton;
	
	[SerializeField]
	public GameObject coinPrefab;
	
	
	// Start is called before the first frame update
	void Awake()
	{
		stateMachine = new UIManagerStateMachine(this);
		stateMachine.ChangeState(new UIManagerDebugState(this));
		
		SetDrawButtonActive(false);
		SetTextBannerActive(false);
		SetPlayerCardHandActive(false);
		SetCardBannerActive(false);
		SetFlipCoinButtonActive(false);
		SetPlayerCardBannerActive(false);
		
		
		uiScriptableObject.showBannerEvent.AddListener(ShowBannerEventHandler);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnGUI()
	{
		// Starts an area to draw elements
		/*
		GUILayout.BeginArea(new Rect(10, 10, 100, 100));
		if (GUILayout.Button("Rotate Gun"))
		{
			Debug.Log("Rotating Gun");
			uiScriptableObject.rotateGun();
		}
		GUILayout.EndArea();
		*/
		stateMachine.Update();
	}

	public void RotateGun()
	{
		uiScriptableObject.OnRotateGun();
	}

	// public void CreateCoin()
	// {
	// 	//Debug.Log("Flipping a coin!");
	// 	//Coin coin = new Coin();
	// 	//coin.transform.position = new Vector3(-7.57f, 4.88f, -1.34f);
	// 	//Instantiate(new Coin());
	// 	Instantiate(coin, new Vector3(-0.28f, 1.59f, -6.42f), Quaternion.identity);
	// }
	
	public void StartCoinFlip()
	{
		Debug.Log("Creating Coin!");
		GameObject newCoin = Instantiate(coinPrefab, new Vector3(0, 5f, 5f), Quaternion.Euler(-42.54f,0,0));
		CoinController newCoinController = newCoin.GetComponent<CoinController>();
		newCoinController.flipResult.AddListener( (CoinController.Side side) =>
			{
				uiScriptableObject.OnCoinFlipDone(side);
			});
		newCoin.SetActive(true);
		newCoinController.FlipCoin();
	}

	public void IncreaseBulletCount()
	{
		uiScriptableObject.OnIncreaseBulletCount();
	}
	
	public void SetDrawButtonActive(bool active)
	{
		drawCardButton.SetActive(active);
	}
	
	public void SetTextBannerActive(bool active)
	{
		textBanner.SetActive(active);
	}
	
	public void SetPlayerCardHandActive(bool active)
	{
		playerCardHand.SetActive(active);
	}
	
	public void SetCardBannerActive(bool active)
	{
		Debug.Log("I am UIManager and I am disabling the Card Banner!");
		cardBanner.SetActive(active);
	}
	
	public void SetFlipCoinButtonActive(bool active)
	{
		flipCoinButton.SetActive(active);
	}
	
	public void ShowBannerEventHandler()
	{
		textBanner.SetActive(true);
	}
	
	public void SetPlayerCardBannerActive(bool active)
	{
		playerCardBanner.SetActive(active);
	}

}
