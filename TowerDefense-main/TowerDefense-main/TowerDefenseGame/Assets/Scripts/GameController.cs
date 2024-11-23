using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private int coinCount = 50;

    private void Awake()
    {
        Instance = this;
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
    }
}
