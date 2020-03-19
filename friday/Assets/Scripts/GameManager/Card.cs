using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType {
    Drift,
    CalamityAndSkill,
}

//System.Serializableを設定しないと、データを保持できない(シリアライズできない)ので注意
[System.Serializable]
public class Card
{
    public CardType type;
    public string name;
    public string anotherName; //技能カードの名前
    public int power;
    public int freeDrawNum; //無償で引ける回数
    public int[] calamityValueList = new int[3];
    public SkillType skillType = SkillType.no;

    public string GetSkillName(){
      string[] skillNameList = new string[]{
        "...",
        "体力+ 1",
        "体力+ 2",
        "+ 1枚",
        "+ 2枚",
        "破壊 1枚",
        "1枚2倍",
        "複写1枚",
        "警戒- 1",
        "並べ替え3枚",
        "更新1枚",
        "更新2枚",
        "山の底に1枚",
      };
      return skillNameList[(int)skillType];
    }
}
