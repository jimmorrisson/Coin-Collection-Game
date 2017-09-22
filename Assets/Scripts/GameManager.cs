using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _coinsPicked;
    public Timer _timer;

    public GameObject coin;
    public Text timeText;
    public Text coinText;
    public LevelController lvlController;

    private void Start()
    {
        _timer = GetComponent<Timer>();
        Spawn(coin);
    }

    private void Update()
    {
        var time = _timer.GetTime();

        if (time <= 0)
        {
            time = 0;
        }

        coinText.text = "Coins: " + _coinsPicked.ToString();
        timeText.text = "Time: " + time.ToString();
    }

    public void Spawn(GameObject coin)
    {
        if (coin == null)
        {
            return;
        }
        Vector3 position = new Vector3(UnityEngine.Random.Range(-14f, 14f), 0.5f, UnityEngine.Random.Range(-14f, 14f));
        GameObject clone = Instantiate(coin, position, Quaternion.identity) as GameObject;
    }

    public void PickCoin()
    {
        _coinsPicked += 1;
    }
}
