using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float roundTime;

    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartTimer()
    {
        StartCoroutine(TimerTick());

    }

    IEnumerator TimerTick()
    {
        float stopTime = Time.time + roundTime;

        while (Time.time < stopTime)
        {
            //uiTimer--
            //print("time left - " + (int)(stopTime - Time.time));

            yield return new WaitForSeconds(1f);
        }

    }
}
 