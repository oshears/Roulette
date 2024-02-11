using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MainCardSO", menuName = "ScriptableObjects/MainCardSO")]
public class MainCardSO : ScriptableObject
{
    [SerializeField]
    private MainCardActionType actionType;
    [SerializeField, Range(1, 6)]
    private int value;
    [SerializeField]
    private Sprite frontOfCard;

    public MainCardActionType GetActionType()
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
