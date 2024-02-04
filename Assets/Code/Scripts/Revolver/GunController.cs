using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField] private MenuScriptableObject menuSO;

    // Start is called before the first frame update
    void Start()
    {
        menuSO.shootGunEvent.AddListener(shootGun);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Animator>().SetBool("makeShot", true);
        }

    }

    void shootGun()
    {
        GetComponent<Animator>().SetBool("makeShot", true);
    }

}
