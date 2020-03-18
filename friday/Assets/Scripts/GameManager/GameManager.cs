using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Deck robinsonDeck;

    // Start is called before the first frame update
    void Start()
    {
        SetDeck();

        robinsonDeck.Shuffle();
        robinsonDeck.Show();
    }

    void SetDeck(){
        robinsonDeck = new Deck(CreateCardList());
    }

    //デッキのcardListを作成
    List<Card> CreateCardList(){
        List<Card> cardList = new List<Card>();
        for(int i=0;i<10;i++){
            cardList.Add(new Card(i/3));
        }
        return cardList;
    }
}
