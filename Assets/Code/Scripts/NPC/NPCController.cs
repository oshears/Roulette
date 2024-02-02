using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    Animation anim = null;
    Animator animator = null;

    bool playingDeathAnimation = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            playingDeathAnimation = !playingDeathAnimation;

            animator.SetBool("npcIsDead", playingDeathAnimation);
        }
        
    }
}
