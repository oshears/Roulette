using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GUIController : MonoBehaviour
{
    //UnityEvent rotateGunEvent;
    [SerializeField]
    public MenuScriptableObject menuSO = null;

    public MenuStateMachine menuStateMachine;

    public Coin coin;

    // Start is called before the first frame update
    void Start()
    {
        menuStateMachine = new MenuStateMachine(this, menuSO);
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
            menuSO.rotateGun();
        }
        GUILayout.EndArea();
        */
        menuStateMachine.Update();
    }

    public void rotateGun()
    {
        menuSO.rotateGun();
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
        menuSO.increaseBulletCount();
    }
}
