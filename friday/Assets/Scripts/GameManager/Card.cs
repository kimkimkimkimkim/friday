using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType {
    Drift,
}

public class Card
{
    public CardType type;
    public string name;
    public int power;

    public Card(int power){
        this.power = power;
    }
}
