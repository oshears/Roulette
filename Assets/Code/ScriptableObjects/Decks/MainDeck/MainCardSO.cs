using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MainCardSO", menuName = "ScriptableObjects/MainCardSO")]
public class MainCardSO : ScriptableObject
{
    [SerializeField]
    private MainCardActionType actionType;
    [SerializeField, Range(1, 5)]
    private int value;
    [SerializeField]
    private Sprite frontOfCard;
    [SerializeField]
    private Sprite backOfCard;
    private UnityAction flipCardEvent;
    private UnityAction playValueEvent;
    private UnityAction playActionEvent;

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

    public Sprite GetBackOfCard()
    {
        return backOfCard;
    }

    public void FlipCard()
    {
        flipCardEvent?.Invoke();
    }

    public void PlayValue()
    {
        playValueEvent?.Invoke();
    }

    public void PlayAction()
    {
        playActionEvent?.Invoke();
    }

}
