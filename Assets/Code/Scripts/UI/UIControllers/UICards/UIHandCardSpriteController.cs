using System.Collections;
using System.Collections.Generic;
using TMPro;
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
	
	
	[SerializeField]
	GameObject _cardNameGameObject;
	
	[SerializeField]
	GameObject _cardDescriptionGameObject;
	
	[SerializeField]
	GameObject _cardInfo;
	
	CardSO _cardSO;
	
	// Start is called before the first frame update
	void Awake()
	{
		uiScriptableObject.enableHandCardSelection.AddListener(EnableHandCardSelectionEventHandler);
		uiScriptableObject.playCardEvent.AddListener(PlayCardEventHandler);
		_cardInfo.SetActive(false);
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
		_cardInfo.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isOver = false;
		_cardInfo.SetActive(false);
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
		_cardSO = playerScriptableObject.GetCard(index);
		GetComponent<Image>().sprite = _cardSO.GetFrontOfCard();
		_cardNameGameObject.GetComponent<TextMeshProUGUI>().text = _cardSO.GetCardName();
		_cardDescriptionGameObject.GetComponent<TextMeshProUGUI>().text = _cardSO.GetCardDescription();
	}


}
