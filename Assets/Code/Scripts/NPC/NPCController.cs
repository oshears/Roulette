using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

	// Animation anim = null;
	// Animator animator = null;
	
	[SerializeField]
	List<GameObject> npcHeartContainer;
	
	[SerializeField]
	NpcScriptableObject npcScriptableObject;
	
	[SerializeField] SpriteRenderer npcSpriteRenderer;
	
	// int _npcHeartsRemaining = 2;

	// bool playingDeathAnimation = false;
	
	void Awake()
	{
		// anim = GetComponent<Animation>();
		// animator = GetComponent<Animator>();
		
		npcScriptableObject.playerDiedEvent.AddListener(NpcDiedEventHandler);
		npcScriptableObject.playerShotEvent.AddListener(NpcShotEventHandler);
		npcScriptableObject.playerInitEvent.AddListener(PlayerInitEventHandler);
		
		// _npcHeartsRemaining = 2;
		
		// foreach (GameObject npcHeart in npcHeartContainer)
		// {
		// 	npcHeart.SetActive(true);
		// }
		
		GetComponent<SpriteRenderer>().enabled = true;
	}

	// Start is called before the first frame update
	void Start()
	{
		
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
		// animator.SetBool("npcIsDead", false);
		
		// _npcHeartsRemaining = 2;
		
		foreach (GameObject npcHeart in npcHeartContainer)
		{
			npcHeart.SetActive(true);
		}
		
		GetComponent<SpriteRenderer>().enabled = true;
		
		npcSpriteRenderer.sprite = npcScriptableObject.npcAliveSprite;
	}
	
	void NpcShotEventHandler()
	{
		// npcHeartContainer[2 - _npcHeartsRemaining].SetActive(false);
		// _npcHeartsRemaining--;
	}
	
	void NpcDiedEventHandler()
	{
		// animator.SetBool("npcIsDead", true);
		// GetComponent<SpriteRenderer>().enabled = false;
		npcSpriteRenderer.sprite = npcScriptableObject.npcDeadSprite;
	}
}
