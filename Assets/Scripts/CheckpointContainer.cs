using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Drone
{
    public class CheckpointContainer : MonoBehaviour
    {
        public int currentIndex;
        public GameObject timeIsOverText;
        public GameObject CrashText;
        public GameObject WinText;
        public GameObject Player;
        public GameController gc;

        // Start is called before the first frame update
        void Start()
        {
            currentIndex = 0;

            transform.GetChild(0).gameObject.SetActive(true);

            for (int i = 1; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void CheckpointAchieved()
        {
            if (currentIndex >= transform.childCount - 1)
            {
                //все точки пройдены

                transform.GetChild(currentIndex).gameObject.SetActive(false);
                if (!CrashText.activeSelf && !WinText.activeSelf && !timeIsOverText.activeSelf)
                    StartCoroutine(Victory());
            }
            else
            {
                currentIndex++;
                transform.GetChild(currentIndex - 1).gameObject.SetActive(false);
                transform.GetChild(currentIndex).gameObject.SetActive(true);
                gc.stopTime += 3;
                gc.timer.text = "ТАЙМЕР: " + (int)(gc.stopTime - Time.time);
            }

        }

        IEnumerator Victory()
        {
            WinText.SetActive(true);

            yield return new WaitForSeconds(5f);

            SceneManager.LoadScene(0);
        }
    }
}
