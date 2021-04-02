using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Drone
{
    public class GameController : MonoBehaviour
    {
        public float roundTime;
        public float stopTime;
        public GameObject Player;
        public AudioManager am;
        public Text timer;
        public GameObject timeIsOverText;
        public GameObject CrashText;
        public GameObject WinText;
        public DroneController dc;

        Gamepad gamepad = Gamepad.current;

        // Start is called before the first frame update
        void Start()
        {
            StartTimer();
            am.Play("Background");
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

        public void StopTimer()
        {
            StopCoroutine(TimerTick());
        }

        IEnumerator TimerTick()
        {
            stopTime = Time.time + roundTime;

            while (Time.time < stopTime)
            {
                timer.text = "ТАЙМЕР: " + (int)(stopTime - Time.time);

                yield return new WaitForSeconds(1f);
            }

            if (CrashText && WinText && timeIsOverText)
            {
                if (!CrashText.activeSelf && !WinText.activeSelf && !timeIsOverText.activeSelf)
                    StartCoroutine(TimeIsOver());
            }
            else if (CrashText && WinText)
            {
                if (!CrashText.activeSelf && !WinText.activeSelf)
                    StartCoroutine(TimeIsOver());
            }
            else if (CrashText)
            {
                if (!CrashText.activeSelf)
                    StartCoroutine(TimeIsOver());
            }
        }

        IEnumerator TimeIsOver()
        {
            timeIsOverText.SetActive(true);
            dc.enabled = false;

            yield return new WaitForSeconds(5f);

            SceneManager.LoadScene(0);
        }
    }
}
 