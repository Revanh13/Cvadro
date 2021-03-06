using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Drone
{
    public class Checkpoint : MonoBehaviour
    {
        private CheckpointContainer cc;

        // Start is called before the first frame update
        void Start()
        {
            cc = transform.parent.gameObject.GetComponent<CheckpointContainer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                cc.CheckpointAchieved();
            }
        }
    }
}
