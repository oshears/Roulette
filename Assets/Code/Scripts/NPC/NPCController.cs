using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    Animation animation = null;
    Animator animator = null;

    bool playingDeathAnimation = false;

    // Start is called before the first frame update
    void Start()
    {
        animation = this.GetComponent<Animation>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            playingDeathAnimation = !playingDeathAnimation;

            animator.SetBool("npcIsDead", playingDeathAnimation);
            
            print("npcIsDead: " +  playingDeathAnimation);
        }
        
    }
}
