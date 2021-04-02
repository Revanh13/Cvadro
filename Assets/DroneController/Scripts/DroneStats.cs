using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Drone
{
    public class DroneStats : MonoBehaviour
    {
        public int hp;
        public int maxHP;

        public Slider healthbar;

        public GameObject timeIsOverText;
        public GameObject CrashText;
        public GameObject WinText;

        public AudioManager am;

        private bool isAlive;

        void Start()
        {
            isAlive = true;
        }


        void Update()
        {

        }

        void OnCollisionEnter(Collision collision)
        {
            float power = collision.relativeVelocity.magnitude * 5;

            if (collision.relativeVelocity.magnitude > 2.5f && hp - power <= 0 && isAlive)
            {
                isAlive = false;
                hp = 0;
                if (!CrashText.activeSelf && !WinText.activeSelf && !timeIsOverText.activeSelf)
                    StartCoroutine(DroneCrash());
                am.Play("Destroy");
            }
            else if (collision.relativeVelocity.magnitude > 2.5f)
            {
                hp -= (int)power;
                healthbar.value = hp;
                am.Play("Crash");
            }
        }

        IEnumerator DroneCrash()
        {
            this.gameObject.GetComponent<DroneController>().enabled = false;
            CrashText.SetActive(true);

            yield return new WaitForSeconds(5f);

            SceneManager.LoadScene(0);
        }
    }
}
