using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

	Animation anim = null;
	Animator animator = null;
	
	[SerializeField]
	List<GameObject> npcHeartContainer;
	
	[SerializeField]
	NpcScriptableObject npcScriptableObject;
	
	int _npcHeartsRemaining = 2;

	// bool playingDeathAnimation = false;
	
	void Awake()
	{
		npcScriptableObject.playerDiedEvent.AddListener(NpcDiedEventHandler);
		npcScriptableObject.playerShotEvent.AddListener(NpcShotEventHandler);
		_npcHeartsRemaining = 2;
		
		foreach (GameObject npcHeart in npcHeartContainer)
		{
			npcHeart.SetActive(true);
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animation>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		// if (Input.GetKeyDown(KeyCode.Space)) {
		// 	playingDeathAnimation = !playingDeathAnimation;

		// 	animator.SetBool("npcIsDead", playingDeathAnimation);
		// }
		
	}
	
	void NpcShotEventHandler()
	{
		npcHeartContainer[2 - _npcHeartsRemaining].SetActive(false);
	}
	
	void NpcDiedEventHandler()
	{
		animator.SetBool("npcIsDead", true);
	}
}
