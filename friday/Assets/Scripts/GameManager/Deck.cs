using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum DeckType{
  robinson,
  calamity,
}

//山札クラス
public class Deck
{
    public List<Card> cardList;

    public Deck(DeckType deckType){
      CardData cardData = Resources.Load<CardData>("ScriptableObjects/CardData"); //cardDataのScriptableObject
      this.cardList = new List<Card>();
      //deckTypeによってそのカードのデッキを作成
      InitialDeck.GetInitialCardNumList(deckType).ForEach(cardNum => Add(cardData.CardList[cardNum]));
    }

    public Deck(List<Card> cardList){
        this.cardList = cardList;
    }

    public void Shuffle(){
        cardList = cardList.OrderBy ( a => Guid.NewGuid () ).ToList ();
    }

    public Card Draw(){
        if(cardList.Count==0)return null; //デッキにカードがないときはドローできない

        Card result = cardList[0]; //ドローしたカード
        cardList.RemoveAt(0);
        return result;
    }

    public void Add(Card card){
        cardList.Add(card);
    }

    public void Show(){
        string result = "[";
        cardList.ForEach(card => {
            result += card.GetSkillName() +", ";
        });
        result.Remove(result.Length-2,2);
        result += "]";
        Debug.Log(result);
    }

}
