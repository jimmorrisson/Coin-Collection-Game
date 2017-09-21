using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float _timer;

    public GameObject coin;
    public Text timeText;

    private void Start()
    {
        _timer = 10.0f;
        Spawn(coin);
    }

    private void Update()
    {
        timeText.text = "Time: " + Mathf.RoundToInt(_timer).ToString();

        if (_timer <= 0.0f)
        {
            SceneManager.LoadScene(0);
        }
        if(_timer >= 20)
        {
            Destroy(this.gameObject);
        }
        _timer -= Time.deltaTime;
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
}
