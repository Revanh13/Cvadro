using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointContainer : MonoBehaviour
{
    public int currentIndex;


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
            Victory();
        }
        else
        {
            currentIndex++;
            transform.GetChild(currentIndex - 1).gameObject.SetActive(false);
            transform.GetChild(currentIndex).gameObject.SetActive(true);
        }

    }

    public void Victory()
    {

    }
}
