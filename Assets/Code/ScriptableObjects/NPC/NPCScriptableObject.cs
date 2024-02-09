using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NPCScriptableObject", menuName = "ScriptableObjects/NPCScriptableObject")]
public class NPCScriptableObject : ScriptableObject
{

    List<Card> cardsInHand = new List<Card>();
    


    public void addCardToHand(Card card){
        cardsInHand.Add(card);
    }

    public List<Card> getCards(Card card){
        return cardsInHand;
    }

}