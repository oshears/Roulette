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

}