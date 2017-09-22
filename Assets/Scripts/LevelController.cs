using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int AmountOfCoins { get; private set; } 

    private void Start()
    {
        AmountOfCoins = 3;
    }
}
