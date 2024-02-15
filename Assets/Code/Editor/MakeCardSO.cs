using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeScriptableObject {
	// OYS: Experimental method to create all 32 cards
	// yes. so there are 5 different type of cards
	// bullet, empty, double card, plus one trigger, and joker
	// there are number 1-6, each number have 2 bullet, 1 empty(skip), 1 double card, 1 trigger, total of 30 cards
	// and there are 2 jokers
	[MenuItem("Assets/Create/Make Card Scriptable Objects")]
	public static void CreateCardScriptableObjects()
	{
		for (int i = 0; i < 10; i++)
		{
			CardSO asset = ScriptableObject.CreateInstance<CardSO>();
			AssetDatabase.CreateAsset(asset, $"Assets/Code/ScriptableObjects/Deck/NewScripableObject{i}.asset");
			AssetDatabase.SaveAssets();
			EditorUtility.FocusProjectWindow();
		}
		// MyScriptableObjectClass asset = ScriptableObject.CreateInstance<MyScriptableObjectClass>();

		// AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
		// AssetDatabase.SaveAssets();

		// EditorUtility.FocusProjectWindow();

		// Selection.activeObject = asset;
	}
}