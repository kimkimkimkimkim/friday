using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//山札クラス
public class Deck
{
    public List<Card> cardList;

    public Deck(){
        cardList = new List<Card>();
    }

    public Deck(List<Card> cardList){
        this.cardList = cardList;
    }

    public void Shuffle(){
        cardList = cardList.OrderBy ( a => Guid.NewGuid () ).ToList ();
    }

    public void Show(){
        string result = "[";
        cardList.ForEach(card => {
            result += card.power.ToString() +", ";
        });
        result.Remove(result.Length-2,2);
        result += "]";
        Debug.Log(result);
    }

}
