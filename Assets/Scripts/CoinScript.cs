using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject menager;

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        menager = GameObject.FindGameObjectWithTag("GameMenager");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _anim.SetBool("IsPicked", true);
            gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-14f, 14f), 0.5f, UnityEngine.Random.Range(-14f, 14f));
            var gameMenager = menager.GetComponent<GameManager>();
            gameMenager.PickCoin();
            gameMenager._timer.AddTime(10f);
        }
    }
}
