using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
        public Slider progressBar;
        public Text progressText;
        

        // Start is called before the first frame update
        void Start()
        {
            currentIndex = 0;

            transform.GetChild(0).gameObject.SetActive(true);

            for (int i = 1; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(false);

            if (progressBar && progressText)
            {
                progressBar.maxValue = transform.childCount;
                progressBar.value = 0;
                progressText.text = "ПРОГРЕСС: 0/" + transform.childCount;
            }
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
                StartCoroutine(Victory());

                if (progressBar && progressText)
                {
                    progressBar.value = currentIndex + 1;
                    progressText.text = "ПРОГРЕСС: " + (currentIndex + 1) + "/" + transform.childCount;
                }
            }
            else
            {
                currentIndex++;
                transform.GetChild(currentIndex - 1).gameObject.SetActive(false);
                transform.GetChild(currentIndex).gameObject.SetActive(true);
                gc.stopTime += 3;
                if (gc.timer)
                    gc.timer.text = "ТАЙМЕР: " + (int)(gc.stopTime - Time.time);
                if (progressBar && progressText)
                {
                    progressBar.value = currentIndex;
                    progressText.text = "ПРОГРЕСС: " + currentIndex + "/" + transform.childCount;
                }
            }
        }

        IEnumerator Victory()
        {
            WinText.SetActive(true);
            gc.StopTimer();

            yield return new WaitForSeconds(5f);

            SceneManager.LoadScene(0);
        }
    }
}
