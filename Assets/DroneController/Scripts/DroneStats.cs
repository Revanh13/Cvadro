using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneStats : MonoBehaviour
{
    public int hp;
    public int maxHP;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        float power = collision.relativeVelocity.magnitude * 5;
        hp -= (int)power;
        print(hp);
    }
}
