﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Game game;

    // Start is called before the first frame update
    void Start()
    {
      game = new Game();

      game.robinsonDeck.Show();
      game.calamityDeck.Show();
    }
}
