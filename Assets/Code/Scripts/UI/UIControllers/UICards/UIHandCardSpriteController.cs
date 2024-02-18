using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// using UnityEngine.UIElements;

public class UIHandCardSpriteController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	bool isOver = false;
	
	int _shiftUpAmount = 25;
	
	Vector3 _startPosition;

	// Card _card;
	
	int _cardIndex;

	bool _selectable = false;

	[SerializeField]
	UIScriptableObject uiScriptableObject;
	[SerializeField]
	PlayerScriptableObject playerScriptableObject;
	
	// Start is called before the first frame update
	void Awake()
	{
		uiScriptableObject.enableHandCardSelection.AddListener(EnableHandCardSelectionEventHandler);
		uiScriptableObject.playCardEvent.AddListener(PlayCardEventHandler);
	}
	
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
		isOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isOver = false;
	}

	public void OnPointerClick(PointerEventData eventData){
		if (_selectable)
		{
			uiScriptableObject.OnPlayCard(_cardIndex);
		}
	}

	public void PlayCardEventHandler(int cardIndex){
		_selectable = false;
	}
	
	public void EnableHandCardSelectionEventHandler()
	{
		_selectable = true;
	}
	
	public void SetCardIndex(int index)
	{
		_cardIndex = index;
		GetComponent<Image>().sprite = playerScriptableObject.GetCard(index).GetFrontOfCard();
	}


}
