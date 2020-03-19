using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//デッキの最初のカードのカード番号配列を持っている
public static class InitialDeck
{
    public static List<int> robinson = new List<int>{
      0,0,0,0,0,1,1,1,1,1,1,1,1,2,3,3,3,4
    };
    public static List<int> calamity = new List<int>{
      5,5,6,6,7,8,9,10,10,11,12,12,13,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,28
    };

    public static List<int> GetInitialCardNumList(DeckType deckType){
      switch(deckType){
      case DeckType.robinson:
        return robinson;
      case DeckType.calamity:
        return calamity;
      default:
        return new List<int>();
      }
    }
}
