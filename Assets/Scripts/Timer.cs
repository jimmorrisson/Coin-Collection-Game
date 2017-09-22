using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time;

    private void Start()
    {
        _time = 10f;
    }

    private void Update()
    {
        _time -= Time.deltaTime;
    }

    public int GetTime()
    {
        return Mathf.RoundToInt(_time);
    }

    public void AddTime(float time)
    {
        _time += time;
    }
}
