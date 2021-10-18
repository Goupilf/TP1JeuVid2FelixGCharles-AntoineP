using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int spawnerLifePoints = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test collision spawn");
        if (other.gameObject.tag == "bullet")
        {
            spawnerLifePoints = spawnerLifePoints - 1;
            if (spawnerLifePoints == 0)
            {
                this.gameObject.SetActive(false);
            }
            other.gameObject.SetActive(false);
        }
    }
}
