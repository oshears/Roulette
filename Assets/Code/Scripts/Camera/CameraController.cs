using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{


	float _speed = 6f;
	
	[SerializeField]
	// float _cameraPanSpeed = 1.5f;
	float _cameraPanSpeed = 20f;
	
	bool lookingUp = false;
	
	[SerializeField] PlayerScriptableObject _playerScriptableObject;
	
	// [SerializeField] CameraFollow cameraFollow;
	Vector3 cameraFollowPosition = new Vector3();

	void Awake()
	{
		
		
	}
	
	void Start()
	{
		// cameraFollowPosition.Setup(() => cameraFollowPosition, () => 80f);
	}
	
	// Update is called once per frame
	void Update()
	{
		// if(_playerScriptableObject.GetHeartsRemaining() < 2)
		// {
		// 	if (lookingUp)
		// 	{
		// 		if (lookingUp && transform.rotation.eulerAngles.x > 7)
		// 		{
		// 			Debug.Log("Rotating Camera Up");
		// 			transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - _speed * Time.deltaTime, 0, 0);
						
		// 		}
		// 		else
		// 		{
		// 			lookingUp = false;
		// 		}
		// 	}
		// 	else
		// 	{
		// 		if (!lookingUp && transform.rotation.eulerAngles.x < 13)
		// 		{
		// 			Debug.Log("Rotating Camera Down");
		// 			transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + _speed * Time.deltaTime, 0, 0);
						
		// 		}
		// 		else
		// 		{
		// 			lookingUp = true;
		// 		}
		// 	}
			
		// }
		// else
		// {
		// 	transform.rotation = Quaternion.Euler(10,0,0);
		// }
		
		// float edgeSize = 30f;
		// if (Input.mousePosition.x > Screen.width - edgeSize)
		// {
		// 	// float newX = Math.Min(transform.position.x + _cameraPanSpeed * Time.deltaTime, 2.53f);
		// 	// transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		// 	float currAngle = (transform.rotation.eulerAngles.y > 180) ? transform.rotation.eulerAngles.y - 360 : transform.rotation.eulerAngles.y;
		// 	float newY = Math.Min(currAngle + _cameraPanSpeed * Time.deltaTime, 6f);
		// 	transform.rotation = Quaternion.Euler(0,newY,0);
			
		// }
		// if (Input.mousePosition.x < edgeSize)
		// {
		// 	// float newX = Math.Max(transform.position.x - _cameraPanSpeed * Time.deltaTime, -1.72f);
		// 	// transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		// 	float currAngle = (transform.rotation.eulerAngles.y > 180) ? transform.rotation.eulerAngles.y - 360 : transform.rotation.eulerAngles.y;
		// 	float newY = Math.Max(currAngle - _cameraPanSpeed * Time.deltaTime, -3.82f);
		// 	transform.rotation = Quaternion.Euler(0,newY,0);
		// }
		
		
	}
	
	// bool validCameraPosition(Vector3 position)
	// {
	// 	return position.x < 2.53 && position.x > -1.72;
	// }
	
	


	
}
