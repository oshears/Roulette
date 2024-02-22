using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCardController : MonoBehaviour
{

	[SerializeField] List<GameObject> _npcCards;
	
	[SerializeField] NpcScriptableObject npcScriptableObject;
	
	void Awake()
	{
		npcScriptableObject.playerAddCardEvent.AddListener(UpdateNpcCardsEventHandler);
		npcScriptableObject.playerRemoveCardEvent.AddListener(UpdateNpcCardsEventHandler);
		npcScriptableObject.playerInitEvent.AddListener(UpdateNpcCardsEventHandler);
	}
	
	void UpdateNpcCardsEventHandler()
	{
		_npcCards[0].SetActive(npcScriptableObject.GetNumCardsInHand() > 1);
		_npcCards[1].SetActive(npcScriptableObject.GetNumCardsInHand() > 0);
	}
	
}