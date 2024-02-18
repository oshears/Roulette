using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class UIBulletCounter : MonoBehaviour
{

	int _numBullets;

	[SerializeField]
	Sprite[] sprites;

	[SerializeField]
	UIScriptableObject menuSO;
	
	[SerializeField]
	GunScriptableObject _gunScriptableObject;
	
	[SerializeField] private Sprite[] _bulletCounterSprites;
	
	[SerializeField] private GameObject shotsRemainingTextGameObject;

	// Start is called before the first frame update
	void Awake()
	{
		_numBullets = 0;
		NumBulletsUpdatedEventHandler(_numBullets);
		
		// menuSO.increaseBulletCountEvent.AddListener(IncreaseBulletCountEventHandler);
		_gunScriptableObject.fireGunEvent.AddListener(FireGunEventHandler);
		_gunScriptableObject.addBulletEvent.AddListener(AddBulletEventHandler);
		_gunScriptableObject.numBulletsUpdatedEvent.AddListener(NumBulletsUpdatedEventHandler);
		_gunScriptableObject.initGunEvent.AddListener(InitGunEventHandler);
	}

	// Update is called once per frame
	void Update()
	{
		//if(Input.GetKeyDown(KeyCode.Q))
		//{
		//    num_rounds = (num_rounds + 1) % 5;
		//}

		// this.GetComponent<Image>().sprite = sprites[_numRounds];
	}

	// void IncreaseBulletCountEventHandler()
	// {
	// 	num_rounds = (num_rounds + 1) % 6;
	// }
	
	void InitGunEventHandler()
	{
		_numBullets = 0;
		NumBulletsUpdatedEventHandler(_numBullets);
		shotsRemainingTextGameObject.GetComponent<TextMeshProUGUI>().text = $"Gun is unloaded.";
	}
	
	void AddBulletEventHandler()
	{
		NumBulletsUpdatedEventHandler(_numBullets + 1);
	}
	
	void NumBulletsUpdatedEventHandler(int numBullets)
	{
		_numBullets = numBullets;
		GetComponent<Image>().sprite = _bulletCounterSprites[numBullets];
		UpdateShotsRemainingText();
	}
	
	void FireGunEventHandler(bool wasBullet)
	{
		if (wasBullet)
		{
			NumBulletsUpdatedEventHandler(_numBullets - 1);
		}
		
		UpdateShotsRemainingText();
	}
	
	void UpdateShotsRemainingText()
	{
		shotsRemainingTextGameObject.GetComponent<TextMeshProUGUI>().text = $"Empty Shells Remaining: {_gunScriptableObject.GetNumEmptyShells()}";
	}
}
