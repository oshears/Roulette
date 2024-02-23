using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GunController : MonoBehaviour
{

	enum GunState
	{
		NPC_1,
		NPC_2,
		NPC_3,
		Player
	}

	int[] revolverRotations = {315, 0, 45, 180};

	GunState state = GunState.NPC_1;

	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	[SerializeField]
	GunScriptableObject gunScriptableObject;
	
	[SerializeField]
	GameObject revolverModel;
	
	void Awake()
	{
		gunScriptableObject.fireGunEvent.AddListener(FireGunEventHandler);
		gunScriptableObject.updateGunRotationEvent.AddListener(UpdateGunRotationEventHandler);
		gunScriptableObject.setGunActiveEvent.AddListener(SetGunActiveEventHandler);
		
	}

	// Start is called before the first frame update
	void Start()
	{
		// transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, revolverRotations[0], 0));
		
		

		// uiScriptableObject?.rotateGunEvent.AddListener(rotateGunRight);
		// uiScriptableObject?.shootGunEvent.AddListener(shootGun);
		
		// Gun Positions
		// -1.604 0.557 -3.31
		// 0 320.18 0
		
		
		// -0.977 0.557 -3.31
		// 702.059
		
		// 0.45 0.557 -3.31
		// 0
		
		// 1.697
		// 31.601
		
		// xPos = 2.904
		// yRot = 42.286
		
		// player
		// 0.45 0.557 -3.31
		// 180
		
		// idle
		// pos: 1.43 -0.256 -3.31
		// rot: -17 0 90
		
		// TODO: Add animation to gun between these locations
	}

	// Update is called once per frame
	void Update()
	{
		
		
	}

   void rotateGunRight()
	{
		if (state == GunState.NPC_1)
		{
			state = GunState.NPC_2;
		}
		else if (state == GunState.NPC_2)
		{
			state = GunState.NPC_3;
		}
		else if (state == GunState.NPC_3)
		{
			state = GunState.Player;
		}
		else if (state == GunState.Player)
		{
			state = GunState.NPC_1;
		}
		
		// transform.rotation = Quaternion.Euler(0, revolverRotations[(int) state], 0);
	}
	
	void UpdateGunRotationEventHandler(int targetId)
	{
		// transform.rotation = Quaternion.Euler(gunRotation);
		revolverModel.GetComponent<Animator>().SetInteger("playerTurn", targetId);
	}
	
	
	
	void FireGunEventHandler(bool wasBullet)
	{
		shootGun();
	}
	
	void shootGun()
	{
		// revolverModel.GetComponent<Animator>()?.SetBool("makeShot", true);
	}
	
	void SetGunActiveEventHandler(bool active)
	{
		if (active)
		{
			revolverModel.GetComponent<Animator>()?.SetInteger("playerTurn", 0);
			revolverModel.GetComponent<Animator>()?.SetBool("gunActive", true);
		}
		else
		{
			revolverModel.GetComponent<Animator>()?.SetInteger("playerTurn", 0);
			revolverModel.GetComponent<Animator>()?.SetBool("gunActive", false);
		}
	}
}
