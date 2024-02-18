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
		
	}

	// Start is called before the first frame update
	void Start()
	{
		transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, revolverRotations[0], 0));
		
		

		// uiScriptableObject?.rotateGunEvent.AddListener(rotateGunRight);
		// uiScriptableObject?.shootGunEvent.AddListener(shootGun);
		
		
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
		
		transform.rotation = Quaternion.Euler(0, revolverRotations[(int) state], 0);
	}
	
	void UpdateGunRotationEventHandler(Vector3 gunRotation)
	{
		transform.rotation = Quaternion.Euler(gunRotation);
	}
	
	
	
	void FireGunEventHandler(bool wasBullet)
	{
		shootGun();
	}
	
	void shootGun()
	{
		revolverModel.GetComponent<Animator>()?.SetBool("makeShot", true);
	}
}
