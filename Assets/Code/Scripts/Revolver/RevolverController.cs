using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RevolverController : MonoBehaviour
{

    enum RevolverState
    {
        NPC_1,
        NPC_2,
        NPC_3,
        Player
    }

    int[] revolverRotations = {315, 0, 45, 180};

    RevolverState state = RevolverState.NPC_1;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetLocalPositionAndRotation(transform.position, Quaternion.Euler(0, revolverRotations[0], 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetLocalPositionAndRotation(transform.position, Quaternion.Euler(0, revolverRotations[(int) state], 0));
        if (state == RevolverState.NPC_1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                state = RevolverState.Player;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                state = RevolverState.NPC_2;
            }
        }
        else if (state == RevolverState.NPC_2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                state = RevolverState.NPC_1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                state = RevolverState.NPC_3;
            }
        }
        else if (state == RevolverState.NPC_3)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                state = RevolverState.NPC_2;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                state = RevolverState.Player;
            }
        }
        else if (state == RevolverState.Player)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                state = RevolverState.NPC_3;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                state = RevolverState.NPC_1;
            }
        }


        

    }
}
