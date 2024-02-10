using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandCardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	bool isOver = false;
	
	Vector3 _startPosition;
	
	// Start is called before the first frame update
	void Start()
	{
		_startPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if(isOver)
		{
			transform.position = Vector3.Lerp(_startPosition, _startPosition + Vector3.up * 50, 1);
		}
		else
		{
			transform.position = Vector3.Lerp(_startPosition  + Vector3.up * 50, _startPosition, 1);
		}
		
		
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("Mouse enter");
		isOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("Mouse exit");
		isOver = false;
	}
}
