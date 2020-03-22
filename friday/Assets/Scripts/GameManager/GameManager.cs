using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phase {
  checkCalamityDeck,
  drawCalamityDeck,
}

public class GameManager : MonoBehaviour
{
  //GameData
  private Deck robinsonDeck;
  private Deck robinsonDeckGrave;
  private Deck calamityDeck;
  private Deck calamityDeckGrave;
  private int warnValue;
  private Phase phase;
  private List<GameObject> drawedCardListFromCalamityDeck = new List<GameObject>(); //災厄デッキからドローした二枚のカードの入った配列

  //オブジェクト参照
  public GameObject buttonStart;
  public GameObject field;
  public GameObject dialogBackGround;
  public GameObject cardPrefab;

  void Start(){

  }

  //ゲームデータの初期設定
  void SetGame(){
    robinsonDeck = new Deck(DeckType.robinson);
    robinsonDeck.Shuffle();
    robinsonDeckGrave = new Deck();
    calamityDeck = new Deck(DeckType.calamity);
    calamityDeck.Shuffle();
    calamityDeckGrave = new Deck();
    warnValue = 0;
    phase = (Phase)Enum.ToObject(typeof(Phase), 0);
  }


  public void StartGame(){
    buttonStart.SetActive(false);

    SetGame();

    Action();
  }

  //次のphaseに移行しそのphaseの行動を行う
  public void NextPhase(){
    int phaseNum = Enum.GetNames(typeof(Phase)).Length;
    if((int)phase == phaseNum-1){
      phase = (Phase)Enum.ToObject(typeof(Phase), 0);
    }else{
      phase = (Phase)Enum.ToObject(typeof(Phase), (int)phase + 1);
    }

    Action();
  }

  //phaseに則した行動を行う
  private void Action(){
    switch(phase){
    case Phase.checkCalamityDeck:
      CheckCalamityDeck();
      return;
    case Phase.drawCalamityDeck:
      DrawCalamityDeck();
      return;
    default:
      return;
    }
  }

  //災厄デッキが2枚以上あるかの確認
  private void CheckCalamityDeck(){
    int calamityDeckNum = calamityDeck.Count();
    if(calamityDeckNum >= 2){
      //災厄デッキが2枚以上あるなら次のフェーズへ
      NextPhase();
    }else{
      //災厄デッキが一周したので勝利

    }
  }

  //災厄デッキからドローする
  private void DrawCalamityDeck(){
    Card card1 = calamityDeck.Draw();
    Card card2 = calamityDeck.Draw();

    Debug.Log("ドローしたカード");
    Debug.Log(card1.name);
    Debug.Log(card2.name);
    dialogBackGround.SetActive(true);

    GameObject oCard1 = (GameObject)Instantiate(cardPrefab);
    oCard1.GetComponent<CardPrefabManager>().SetCardUI(card1);
    oCard1.GetComponent<CardPrefabManager>().index = 0;
    oCard1.transform.SetParent(dialogBackGround.transform,false);
    oCard1.transform.localScale = new Vector3(1,1,1);
    oCard1.transform.localPosition = new Vector3(-244,100,0);

    GameObject oCard2 = (GameObject)Instantiate(cardPrefab);
    oCard2.GetComponent<CardPrefabManager>().SetCardUI(card2);
    oCard2.GetComponent<CardPrefabManager>().index = 1;
    oCard2.transform.SetParent(dialogBackGround.transform,false);
    oCard2.transform.localScale = new Vector3(1,1,1);
    oCard2.transform.localPosition = new Vector3(244,100,0);

    drawedCardListFromCalamityDeck.Add(oCard1);
    drawedCardListFromCalamityDeck.Add(oCard2);
  }

  //どちらと戦うか決める
  public void DecideWhichToFight(int index){
    int otherIndex = (index * -1) + 1;

    //選んでない方を捨て山に追加
    calamityDeckGrave.Add(drawedCardListFromCalamityDeck[otherIndex].GetComponent<CardPrefabManager>().cardData);

    //選んだ方を真ん中に配置
    

    //初期化
    dialogBackGround.SetActive(false);
    Destroy(drawedCardListFromCalamityDeck[0]);
    Destroy(drawedCardListFromCalamityDeck[1]);
    drawedCardListFromCalamityDeck = new List<GameObject>();
  }

}
