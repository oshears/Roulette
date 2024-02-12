using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandCardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	bool isOver = false;
	
	int _shiftUpAmount = 25;
	
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
			transform.position = Vector3.Lerp(_startPosition, _startPosition + Vector3.up * _shiftUpAmount, 1);
		}
		else
		{
			transform.position = Vector3.Lerp(_startPosition  + Vector3.up * _shiftUpAmount, _startPosition, 1);
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
