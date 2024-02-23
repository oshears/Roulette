using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerInitState : GameManagerState
{
	bool _gameStarting = false;
	public GameManagerInitState(GameManager owner) : base(owner) { 
		_uiScriptableObject.startGameEvent.AddListener(StartGameEventHandler);
		_uiScriptableObject.bannerButtonClick.AddListener(BannerButtonClickEventHandler);
		_gameStarting = false;
	}

	public override void Enter()
	{
		_uiScriptableObject.OnUpdateObjectiveText("Click start when you are ready to play!");
		
		Debug.Log("Preparing to initialize New Game!");
		
		InitializeGame();
		_uiScriptableObject.OnInitializeGui();
		
		
	}

	override public void Execute() 
	{ 
		

	}

	public override void Exit()
	{
		_uiScriptableObject.startGameEvent.RemoveListener(StartGameEventHandler);
		_uiScriptableObject.bannerButtonClick.RemoveListener(BannerButtonClickEventHandler);
		
		foreach (NpcScriptableObject npc in _npcScriptableObjects)
		{
			npc.OnUpdateNpcSpeech("Let the game, begin.");
		}
	}

	void StartGameEventHandler()
	{
		Debug.Log("Initializing New Game!");
		
		// Display Game Start
		_uiScriptableObject.SetBannerText("Game Start!");
		_uiScriptableObject.OnShowBanner();
				
		// Initialize Game Objects / Managers / Controllers
		InitializeGame();
		
		// indicate game is starting
		_gameStarting = true;
		
	}
	
	void InitializeGame()
	{
		// Reset Player Scores
		_uiScriptableObject.OnResetScores();
		
		// Empty all cards from player hands
		_playerScriptableObject.OnInitializePlayer();
		foreach (NpcScriptableObject npc in _npcScriptableObjects)
		{
			npc.OnInitializePlayer();
		}

		// Initialize Deck
		_deckScriptableObject.OnInitializeDeck();
		
		// Initialize Gun
		_gunScriptableObject.OnInitializeGun();
	}
	
	void BannerButtonClickEventHandler()
	{
		// Go to New Round State
		_stateMachine.ChangeState(new GameManagerNewRoundState(_owner));
	}
	
	override public void OnGUI()
	{
		if (!_gameStarting)
		{
			GUILayout.BeginArea(new Rect(10, 10, 500, 500));
			if (GUILayout.Button("Start Game"))
			{
				
		
				// changeState(new UIManagerDefaultState(_owner));   
				_uiScriptableObject.OnStartGame();
			}
			GUILayout.EndArea();
			
			// if (GUILayout.Button("Rotate Gun"))
			// {
			// 	Debug.Log("Rotating Gun");
			// 	_uiScriptableObject.OnRotateGun();
			// }
			// if (GUILayout.Button("Flip coin"))
			// {
			// 	_owner.StartCoinFlip();
			// }
			// if (GUILayout.Button("Increase Bullet Count"))
			// {
			// 	_owner.IncreaseBulletCount();
			// }
			// if (GUILayout.Button("Shoot Gun"))
			// {
			// 	_uiScriptableObject.OnShootGun();
			// }
			
		}
		
	}
	
	
}