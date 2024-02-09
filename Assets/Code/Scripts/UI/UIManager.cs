using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    //UnityEvent rotateGunEvent;
    [SerializeField]
    public UIScriptableObject uiScriptableObject;

    public UIManagerStateMachine stateMachine;

    public Coin coin;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new UIManagerStateMachine(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        // Starts an area to draw elements
        /*
        GUILayout.BeginArea(new Rect(10, 10, 100, 100));
        if (GUILayout.Button("Rotate Gun"))
        {
            Debug.Log("Rotating Gun");
            uiScriptableObject.rotateGun();
        }
        GUILayout.EndArea();
        */
        stateMachine.Update();
    }

    public void rotateGun()
    {
        uiScriptableObject.OnRotateGun();
    }

    public void createCoin()
    {
        //Debug.Log("Flipping a coin!");
        //Coin coin = new Coin();
        //coin.transform.position = new Vector3(-7.57f, 4.88f, -1.34f);
        //Instantiate(new Coin());
        Instantiate(coin, new Vector3(-0.28f, 1.59f, -6.42f), Quaternion.identity);
    }

    public void increaseBulletCount()
    {
        uiScriptableObject.OnIncreaseBulletCount();
    }
}
