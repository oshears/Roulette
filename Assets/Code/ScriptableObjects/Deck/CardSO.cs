using UnityEngine;

[CreateAssetMenu(fileName = "MainCardSO", menuName = "ScriptableObjects/MainCardSO")]
public class CardSO : ScriptableObject
{
	[SerializeField]
	private CardActionType actionType;
	[SerializeField, Range(1, 6)]
	private int value;
	[SerializeField]
	private Sprite frontOfCard;

	public CardActionType GetActionType()
	{
		return actionType;
	}

	public int GetValue()
	{
		return value;
	}

	public Sprite GetFrontOfCard()
	{
		return frontOfCard;
	}
	
	public string GetCardName()
	{
		switch(actionType)
		{
			case CardActionType.Bullet:
				return "Bullet Card";
			case CardActionType.DrawTwo:
				return "Draw Two Card";
			case CardActionType.Joker:
				return "Joker Card";
			case CardActionType.EmptyShell:
				return "Empty Shell Card";
			case CardActionType.TargetNextPlayer:
				return "Target Next Player Card";
			default:
				return "No Name Found.";
		}
	}
	
	public string GetCardDescription()
	{
		switch(actionType)
		{
			case CardActionType.Bullet:
				return "Add another bullet to the revolver (Can only be played after you pull the trigger).";
			case CardActionType.DrawTwo:
				return "Draw two cards from the deck (Can only be played after you pull the trigger).";
			case CardActionType.Joker:
				return "Skip your turn and make the next player pull the trigger twice.";
			case CardActionType.EmptyShell:
				return "Skip your turn. (Can only be played before you pull the trigger).";
			case CardActionType.TargetNextPlayer:
				return "Make the next player pull the trigger twice (Can only be played after you pull the trigger).";
			default:
				return "No Name Found.";
		}
	}

}