using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnerManager : MonoBehaviour
{

    [SerializeField] GameObject objectToRecycle;
    [SerializeField] private float timeBetweenSpawnsInSec;
    [SerializeField] private int maxAlienInGame = 20;
    [SerializeField] private int numActiveAlien = 0;
    [SerializeField] GameManager gameManager;

    private float period = 0.0f;
    private GameObject[] objectsToRecyle = new GameObject[20];
    private List<GameObject> alienSpawners = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxAlienInGame; i++)
        {
            objectsToRecyle[i] = Instantiate(objectToRecycle, new Vector3(this.transform.position.x, this.transform.position.y-5, this.transform.position.z), Quaternion.identity);
            objectsToRecyle[i].SetActive(false);
        }


        for (int i = 0; i < 10; i++)
        {
            alienSpawners.Insert(i, this.transform.GetChild(i).gameObject);
            

        }
        // Instantiate(prefab, new Vector3(this.transform.position.x, this.transform.position.y-5, this.transform.position.z), Quaternion.identity);
        

    }

    // Update is called once per frame
    void Update()
    {
        CountActive();
        if (alienSpawners.Count == 0)
        {
            gameManager.setVictoryText();
            for (int i = 0; i < objectsToRecyle.Length; i++)
            {
                objectsToRecyle[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < alienSpawners.Count; i++)
            {
                if (alienSpawners[i].activeSelf == false)
                {
                    alienSpawners.RemoveAt(i);
                }
            }

            if (period > timeBetweenSpawnsInSec && numActiveAlien < maxAlienInGame)
            {
                SpawnObjectToRecycle();
                period = 0;
            }
        }
        
        period += UnityEngine.Time.deltaTime;
    }
    private void FixedUpdate()
    {
        
    }
    private void SpawnObjectToRecycle()
    {
        for (int i = 0; i < maxAlienInGame; i++)
            if (!objectsToRecyle[i].activeSelf)
            {
                objectsToRecyle[i].SetActive(true);
                GameObject randalienspawner = alienSpawners[Random.Range(0, alienSpawners.Count)];
                if (randalienspawner.activeSelf == true)
                {
                    objectsToRecyle[i].transform.position = new Vector3(randalienspawner.transform.position.x, randalienspawner.transform.position.y - 5, randalienspawner.transform.position.z);

                }

                return;
            }
    }
    private void CountActive()
    {
        int numActiveObj = 0;
        for (int i = 0; i < objectsToRecyle.Length; i++)
        {
            if (objectsToRecyle[i].activeSelf == true)
            {
                numActiveObj++;
            }
        }
        this.numActiveAlien = numActiveObj;
        
    }

    
}


