using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float roundTime;
    public GameObject Player;

    Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamepad.startButton.wasPressedThisFrame)
        {
            Destroy(Player);
            SceneManager.LoadScene(0);
        }
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
 