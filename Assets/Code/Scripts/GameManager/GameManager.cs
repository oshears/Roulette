using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	[SerializeField]
	public UIScriptableObject uiScriptableObject;
	// public NPCScriptableObject _npcScriptableObject;
	public DeckScriptableObject deckScriptableObject;
	public PlayerScriptableObject playerScriptableObject;

	public GameManagerStateMachine stateMachine;
	
	public NpcScriptableObject[] npcScriptableObjects;


	public int numPlayers {get; private set;}

	// Start is called before the first frame update
	void Awake()
	{
		stateMachine = new GameManagerStateMachine(this);
		stateMachine.ChangeState(new GameManagerInitState(this));
	}
	
	void Start()
	{
		numPlayers = npcScriptableObjects.Length + 1;
	}

	// Update is called once per frame
	void Update()
	{
		stateMachine.Update();
	}
}
