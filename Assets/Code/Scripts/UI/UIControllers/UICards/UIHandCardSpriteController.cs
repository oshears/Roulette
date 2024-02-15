using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandCardSpriteController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	bool isOver = false;
	
	int _shiftUpAmount = 25;
	
	Vector3 _startPosition;

	Card _card;

	bool _selectable = false;

	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	// Start is called before the first frame update
	void Start()
	{
		_startPosition = transform.position;
		uiScriptableObject.enableHandCardSelection.AddListener(EnableHandCardSelectionEventHandler);
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
		isOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isOver = false;
	}

	public void OnPointerClick(PointerEventData eventData){
		if (_selectable)
		{
			uiScriptableObject.OnPlayCard(_card);
		}
	}

	public void OnPlayCardEventHandler(){
		_selectable = false;
	}
	
	public void EnableHandCardSelectionEventHandler()
	{
		_selectable = true;
	}


}
