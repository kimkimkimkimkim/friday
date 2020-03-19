using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObjectを継承したクラス
//ファイル名、メニュー表示名、表示順を指定
[CreateAssetMenu(
  fileName = "CardData",
  menuName = "ScriptableObject/CardData",
  order    = 0)
]
public class CardData : ScriptableObject {

  //ListステータスのList
  public List<Card> CardList = new List<Card>();

}
