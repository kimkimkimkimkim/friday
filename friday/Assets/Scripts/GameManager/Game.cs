using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public Deck robinsonDeck;
    public Deck calamityDeck;
    public int warnValue;

    public Game(){
      SetGame();
    }

    public void SetGame(){
      robinsonDeck = new Deck(DeckType.robinson);
      robinsonDeck.Shuffle();
      calamityDeck = new Deck(DeckType.calamity);
      calamityDeck.Shuffle();
    }
}
