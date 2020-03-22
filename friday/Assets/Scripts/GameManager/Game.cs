/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public Deck robinsonDeck;
    public Deck calamityDeck;
    public int warnValue;
    public Phase phase;

    public Game(){
      SetGame();
    }

    public void SetGame(){
      robinsonDeck = new Deck(DeckType.robinson);
      robinsonDeck.Shuffle();
      calamityDeck = new Deck(DeckType.calamity);
      calamityDeck.Shuffle();
      warnValue = 0;
      phase = (Phase)Enum.ToObject(typeof(Phase), 0);
    }

    //次のphaseに移行する
    public void NextPhase(){
      int phaseNum = Enum.GetNames(typeof(Phase)).Length;
      if((int)phase == phaseNum-1){
        phase = (Phase)Enum.ToObject(typeof(Phase), 0);
      }else{
        phase = (Phase)Enum.ToObject(typeof(Phase), (int)phase + 1);
      }
    }

    //phaseに則した行動を行う
    private void Action(){
      switch(phase){
      case Phase.checkCalamityDeck:
        CheckCalamityDeck();
        return;
      default:
        return;
      }
    }

    //災厄デッキが2枚以上あるかの確認
    void CheckCalamityDeck(){
      int calamityDeckNum = calamityDeck.Length;
      if(calamityDeckNum >= 2){
        //ドローをしてどちらの災厄カードと戦闘するか選ばせる

      }else{
        //災厄デッキが一周したので勝利

      }
    }


}
*/
