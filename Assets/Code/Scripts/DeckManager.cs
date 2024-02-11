using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField, Tooltip("Contains all cards of the deck")]
    private List<CardSO> deck;
    private int deckIndex;

    void Awake()
    {
        Shuffle();
    }

    public CardSO DrawCard()
    {
        if(deckIndex == deck.Count)
        {
            Shuffle();
        }
        return deck[deckIndex++];
    }

    public void NewGame()
    {
        Shuffle();
    }

    private void Shuffle()
    {
        deckIndex = 0;
        // Fisher-Yates shuffle
        for (int i = deck.Count - 1; i > 0; i--)
        {
            int index = Random.Range(0, i + 1);
            CardSO tempValue = deck[index];
            deck[index] = deck[i];
            deck[i] = tempValue;
        }
    }
}
