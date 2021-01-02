using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SimpleTrigger : MonoBehaviour
{

    public Rigidbody triggerBody; 
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;
    public bool isgoal;
    ObjectiveManager m_ObjectiveManager;

    void OnTriggerEnter(Collider other){
        //do not trigger if there's no trigger target object
        if (triggerBody == null) return;
        if (isgoal)
        {
            m_ObjectiveManager = FindObjectOfType<ObjectiveManager>();
            if (!m_ObjectiveManager.AreAllObjectivesCompleted()) return;
        }
        //only trigger if the triggerBody matches
        var hitRb = other.attachedRigidbody;

        if (hitRb == triggerBody){
            onTriggerEnter.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        //do not trigger if there's no trigger target object
        if (triggerBody == null) return;
        //only trigger if the triggerBody matches
        var hitRb = other.attachedRigidbody;

        if (hitRb == triggerBody)
        {
            onTriggerExit.Invoke();
        }
    }

    public void Drop()
    {
        Rigidbody[] list = GetComponentsInChildren<Rigidbody>();
        foreach(var i in list)
        {
            i.useGravity=true;
        }
    }

}
