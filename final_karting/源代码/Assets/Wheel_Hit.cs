using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_Hit : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col) {
        if (col.isTrigger == true && col.gameObject.layer==11)
        {
            GameObject.Find("wheel_strike").GetComponent<ParticleSystem>().Play();
        }
     }

    void OnTriggerExit(Collider col)
    {
        if (col.isTrigger == true)
        {
            GameObject.Find("wheel_strike").GetComponent<ParticleSystem>().Stop();
        }
    }
}
