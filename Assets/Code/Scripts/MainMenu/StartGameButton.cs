using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGameButton : Selectable
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {

    }

    //public void 

    public override void OnSelect(BaseEventData eventData)
    {
        SceneManager.LoadScene("game_scene", LoadSceneMode.Single);
    }

}

