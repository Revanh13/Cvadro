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
        public GameObject CrashText;

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

            if (hp - power <= 0 && isAlive)
            {
                isAlive = false;
                hp = 0;
                StartCoroutine(DroneCrash());
            }
            else
            {
                hp -= (int)power;
                healthbar.value = hp;
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
