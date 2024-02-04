using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class UIBulletCounter : MonoBehaviour
{

    int num_rounds = 0;

    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    MenuScriptableObject menuSO;

    // Start is called before the first frame update
    void Start()
    {
        menuSO.increaseBulletCountEvent.AddListener(updateBulletCount);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Q))
        //{
        //    num_rounds = (num_rounds + 1) % 5;
        //}

        this.GetComponent<Image>().sprite = sprites[num_rounds];
    }

    void updateBulletCount()
    {
        num_rounds = (num_rounds + 1) % 6;
    }
}
