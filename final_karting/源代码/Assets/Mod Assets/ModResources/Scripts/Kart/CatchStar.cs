using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatchStar : TargetObject
{
    [Header("PickupObject")]
    public GameObject spawnPrefabOnPickup;
    public float destroySpawnPrefabDelay = 10;
    public float collectDuration = 0f;
    public GameObject GameManager;
    public GameObject Text;
    public int totalstar;

    void Start()
    {

    }

    void OnCollect()
    {
        if (CollectSound)
        {
            AudioUtility.CreateSFX(CollectSound, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
        }

        GameManager.GetComponent<GameFlowManager>().starcount += 1;
        Text.GetComponent<TMP_Text>().text = ""+GameManager.GetComponent<GameFlowManager>().starcount+" / "+totalstar;


        if (spawnPrefabOnPickup)
        {
            var vfx = Instantiate(spawnPrefabOnPickup, CollectVFXSpawnPoint.position, Quaternion.identity);
            Destroy(vfx, destroySpawnPrefabDelay);
        }

      

        Destroy(gameObject, collectDuration);
    }

    void OnTriggerEnter(Collider other)
    {
        if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player"))
        {
            OnCollect();
        }
    }
}
