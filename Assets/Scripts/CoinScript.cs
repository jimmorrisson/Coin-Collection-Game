using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //public GameManager gameMenager;
    private Animator _anim;

    private void Start()
    {
        //gameMenager = GameManager.
        _anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log(collision.collider.name);
            _anim.SetBool("IsPicked", true);
            gameObject.transform.position = new Vector3(Random.Range(-14f, 14f), 0.5f, Random.Range(-14f, 14f));
            Debug.Log(collision.collider.name);
            
        }
    }
}
