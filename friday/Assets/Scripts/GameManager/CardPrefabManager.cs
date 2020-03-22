using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPrefabManager : MonoBehaviour
{
  [System.NonSerialized]
  public Card cardData;
  public int index;

  public void SelectCard(){
    GameObject.Find("GameManager").GetComponent<GameManager>().DecideWhichToFight(index);
  }

  public void SetCardUI(Card c){
    cardData = c;
    //災害/技能カードなら180度回転
    if(cardData.type == CardType.CalamityAndSkill)this.transform.GetChild(0).rotation = Quaternion.Euler(0.0f, 0.0f, 180);
    //UIをセット
    GameObject nameText = this.transform.GetChild(0).GetChild(0).gameObject;
    GameObject powerText = this.transform.GetChild(0).GetChild(1).gameObject;
    GameObject skillNameText = this.transform.GetChild(0).GetChild(2).gameObject;
    GameObject anotherNameText = this.transform.GetChild(0).GetChild(3).gameObject;
    GameObject freeDrawNumText = this.transform.GetChild(0).GetChild(4).gameObject;
    GameObject calamityValueTextContainer = this.transform.GetChild(0).GetChild(5).gameObject;

    switch(cardData.type){
    case CardType.Drift:
      return;
    case CardType.CalamityAndSkill:
      nameText.transform.GetChild(0).GetComponent<Text>().text = cardData.anotherName;
      powerText.transform.GetChild(0).GetComponent<Text>().text = cardData.power.ToString();
      skillNameText.transform.GetChild(0).GetComponent<Text>().text = cardData.GetSkillName();
      anotherNameText.transform.GetChild(0).GetComponent<Text>().text = cardData.name;
      freeDrawNumText.transform.GetChild(0).GetComponent<Text>().text = cardData.freeDrawNum.ToString();
      for(int i=0;i<3;i++){
        calamityValueTextContainer.transform.GetChild(i).GetChild(0).GetComponent<Text>().text =
          cardData.calamityValueList[2-i].ToString();
      }
      return;
    default:
      return;
    }
  }

}
