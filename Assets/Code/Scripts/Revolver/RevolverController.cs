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

	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	[SerializeField]
	GameObject revolverModel;

	// Start is called before the first frame update
	void Start()
	{
		transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, revolverRotations[0], 0));

		uiScriptableObject?.rotateGunEvent.AddListener(rotateGunRight);
		uiScriptableObject?.shootGunEvent.AddListener(shootGun);
	}

	// Update is called once per frame
	void Update()
	{
		
		
	}

   void rotateGunRight()
	{
		if (state == RevolverState.NPC_1)
		{
			state = RevolverState.NPC_2;
		}
		else if (state == RevolverState.NPC_2)
		{
			state = RevolverState.NPC_3;
		}
		else if (state == RevolverState.NPC_3)
		{
			state = RevolverState.Player;
		}
		else if (state == RevolverState.Player)
		{
			state = RevolverState.NPC_1;
		}
		
		transform.rotation = Quaternion.Euler(0, revolverRotations[(int) state], 0);
	}
	
	void shootGun()
	{
		revolverModel.GetComponent<Animator>()?.SetBool("makeShot", true);
	}
}
