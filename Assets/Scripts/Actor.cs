using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Actor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject goal;
    private NavMeshAgent navMeshAgent;
    private int lifepoints = 2;
    [SerializeField] GameObject itemSpawner;
    [SerializeField] GameObject deathSoundObject;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent != null)
            navMeshAgent.destination = goal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        navMeshAgent.destination = goal.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test collision");
        if (other.gameObject.tag == "bullet")
        {
            lifepoints = lifepoints - 1;
            if (lifepoints == 0)
            {
                itemSpawner.GetComponent<CollectibleSpawnerManager>().SpawnItemInGame(this.gameObject.transform.position);
                deathSoundObject.transform.position = this.gameObject.transform.position;
                deathSoundObject.GetComponent<AudioSource>().Play();
                this.gameObject.SetActive(false);
                lifepoints = 2;
            }
            other.gameObject.SetActive(false);
        }
        }
    }
