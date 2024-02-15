using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// public class UIHandCardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
public class UIHandCardController : MonoBehaviour
{
	bool isOver = false;
	
	int _shiftUpAmount = 25;
	
	int _cardIndex;
	
	Vector3 _startPosition;

	Card _card;

	bool _selectable = false;

	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	[SerializeField]
	GameObject handCardSpriteGameObject;
	
	// Start is called before the first frame update
	void Start()
	{
		// _startPosition = transform.position;
		// uiScriptableObject.enableHandCardSelection.AddListener(EnableHandCardSelectionEventHandler);
	}

	// Update is called once per frame
	void Update()
	{
		// if(isOver)
		// {
		// 	transform.position = Vector3.Lerp(_startPosition, _startPosition + Vector3.up * _shiftUpAmount, 1);
		// }
		// else
		// {
		// 	transform.position = Vector3.Lerp(_startPosition  + Vector3.up * _shiftUpAmount, _startPosition, 1);
		// }
		
		
	}
	// public void OnPointerEnter(PointerEventData eventData)
	// {
	// 	isOver = true;
	// }

	// public void OnPointerExit(PointerEventData eventData)
	// {
	// 	isOver = false;
	// }

	// public void OnPointerClick(PointerEventData eventData){
	// 	if (_selectable)
	// 	{
	// 		uiScriptableObject.OnPlayCard(_card);
	// 	}
	// }

	// public void OnPlayCardEventHandler(){
	// 	_selectable = false;
	// }
	
	// public void EnableHandCardSelectionEventHandler()
	// {
	// 	_selectable = true;
	// }
	
	public void SetCardIndex(int index)
	{
		_cardIndex = index;
		handCardSpriteGameObject.GetComponent<UIHandCardSpriteController>().SetCardIndex(index);
	}
	
	// public void SetImage(Sprite image)
	// {
	// 	handCardSpriteGameObject.GetComponent<Image>().sprite = image;
	// }


}
