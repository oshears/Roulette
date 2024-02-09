using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public UIScriptableObject uiScriptableObject;
    // public NPCScriptableObject _npcScriptableObject;
    // public DeckScriptableObject _deckScriptableObject;

    public GameManagerStateMachine stateMachine;



    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new GameManagerStateMachine(this);
        stateMachine.ChangeState(new GameManagerInitState(this));
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
