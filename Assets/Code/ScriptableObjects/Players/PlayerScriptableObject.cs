using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject")]
public class PlayerScriptableObject : GamePlayerScriptableObject
{
	
	public UnityEvent playerHandFullEvent;

    public override bool IsNpc()
    {
        return false;
    }

}