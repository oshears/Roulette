using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartsController : MonoBehaviour
{

	// Animation anim = null;
	// Animator animator = null;
	
	[SerializeField] List<GameObject> _playerHeartContainer;
	
	[SerializeField] PlayerScriptableObject _playerScriptableObject;
	
	int _playerHeartsRemaining = 2;

	// bool playingDeathAnimation = false;
	
	void Awake()
	{
		_playerScriptableObject.playerDiedEvent.AddListener(PlayerDiedEventHandler);
		_playerScriptableObject.playerShotEvent.AddListener(PlayerShotEventHandler);
		_playerScriptableObject.playerInitEvent.AddListener(PlayerInitEventHandler);
		
		_playerHeartsRemaining = 2;
		
		foreach (GameObject playerHeart in _playerHeartContainer)
		{
			playerHeart.SetActive(true);
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		// anim = GetComponent<Animation>();
		// animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		// if (Input.GetKeyDown(KeyCode.Space)) {
		// 	playingDeathAnimation = !playingDeathAnimation;

		// 	animator.SetBool("npcIsDead", playingDeathAnimation);
		// }
		
	}
	
	void PlayerInitEventHandler()
	{
		_playerHeartsRemaining = 2;
		
		foreach (GameObject playerHeart in _playerHeartContainer)
		{
			playerHeart.SetActive(true);
		}
	}
	
	void PlayerShotEventHandler()
	{
		_playerHeartContainer[2 - _playerHeartsRemaining].SetActive(false);
		_playerHeartsRemaining--;
	}
	
	void PlayerDiedEventHandler()
	{
		// animator.SetBool("npcIsDead", true);
	}
}
