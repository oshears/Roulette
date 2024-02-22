using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcHeartController : MonoBehaviour
{

	[SerializeField] List<GameObject> _npcHearts;
	
	[SerializeField] NpcScriptableObject npcScriptableObject;
	
	void Awake()
	{
		npcScriptableObject.playerInitEvent.AddListener(UpdateNpcHeartsEventHandler);
		npcScriptableObject.playerShotEvent.AddListener(UpdateNpcHeartsEventHandler);
	}
	
	void UpdateNpcHeartsEventHandler()
	{
		_npcHearts[0].SetActive(npcScriptableObject.GetHeartsRemaining() > 1);
		_npcHearts[1].SetActive(npcScriptableObject.GetHeartsRemaining() > 0);
	}
	
}