using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{


	float _speed = 6f;
	
	bool lookingUp = false;
	
	[SerializeField] PlayerScriptableObject _playerScriptableObject;

	void Awake()
	{
		
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if(_playerScriptableObject.GetHeartsRemaining() < 2)
		{
			if (lookingUp)
			{
				if (lookingUp && transform.rotation.eulerAngles.x > 7)
				{
					Debug.Log("Rotating Camera Up");
					transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - _speed * Time.deltaTime, 0, 0);
						
				}
				else
				{
					lookingUp = false;
				}
			}
			else
			{
				if (!lookingUp && transform.rotation.eulerAngles.x < 13)
				{
					Debug.Log("Rotating Camera Down");
					transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + _speed * Time.deltaTime, 0, 0);
						
				}
				else
				{
					lookingUp = true;
				}
			}
			
		}
		else
		{
			transform.rotation = Quaternion.Euler(10,0,0);
		}
	}
	
	


	
}
