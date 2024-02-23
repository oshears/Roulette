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
	
	public GunScriptableObject gunScriptableObject;


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
	
	void OnGUI()
	{
		stateMachine.OnGUI();
	}
	
	public int GetNextPlayerIndex(int index)
	{
		return (index + 1) % numPlayers;
	}
	
	public int GetNumPlayersAlive()
	{
		int numPlayersAlive = 0;
		
		if (playerScriptableObject.IsPlayerAlive())
		{
			numPlayersAlive++;
		}
		
		foreach (NpcScriptableObject npc in npcScriptableObjects)
		{
			if (npc.IsPlayerAlive())
			{
				numPlayersAlive++;
			}
		}
		
		return numPlayersAlive;
	}
	
	public GamePlayerScriptableObject GetNextPlayer(GamePlayerScriptableObject currentPlayer)
	{
		GamePlayerScriptableObject nextPlayer = playerScriptableObject;
		int nextTargetIndex = GetNextPlayerIndex(currentPlayer.playerId);
		if(nextTargetIndex > 0)
		{
			nextPlayer = npcScriptableObjects[nextTargetIndex - 1];
		}
		
		return nextPlayer;
	}
	
	public void RandomNpcSpeech(string text)
	{
		npcScriptableObjects[Random.Range(0, npcScriptableObjects.Length)].OnUpdateNpcSpeech(text);
	}
}
