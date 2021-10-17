using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawnerManager : MonoBehaviour
{
    [SerializeField] GameObject rocketToRecycle;
    [SerializeField] GameObject healToRecycle;
    [SerializeField] GameObject multiToRecycle;
    private int maxItemsInGame = 15;
    [SerializeField] int numberOfLuck;

    private GameObject[] objectsToRecyle = new GameObject[15];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxItemsInGame; i++)
        {
            int chooseObject = Random.Range(1, 4);
            if(chooseObject == 1)
            {
                objectsToRecyle[i] = Instantiate(healToRecycle, new Vector3(this.transform.position.x, this.transform.position.y - 5, this.transform.position.z), Quaternion.identity);
            }
            else if(chooseObject == 2)
            {
                objectsToRecyle[i] = Instantiate(multiToRecycle, new Vector3(this.transform.position.x, this.transform.position.y - 5, this.transform.position.z), Quaternion.identity);
            }
            else if (chooseObject == 3)
            {
                objectsToRecyle[i] = Instantiate(rocketToRecycle, new Vector3(this.transform.position.x, this.transform.position.y - 5, this.transform.position.z), Quaternion.identity);
            }
            objectsToRecyle[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItemInGame(Vector3 position)
    {
        int randNumber = Random.Range(1, 100);
        if (randNumber < numberOfLuck)
        {
            for (int i = 0; i < maxItemsInGame; i++)
            {
                if (!objectsToRecyle[i].activeSelf)
                {
                    objectsToRecyle[i].transform.position = new Vector3(position.x, position.y + 2, position.z);
                    objectsToRecyle[i].SetActive(true);
                    objectsToRecyle[i].GetComponent<AudioSource>().Play();
                    break;
                }
            }
        }
    }
}
