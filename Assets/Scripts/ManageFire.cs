using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageFire : MonoBehaviour
{
    [SerializeField] GameObject objectToRecycle;
    private static int objNumber = 10;
    private GameObject[] objectsToRecyle = new GameObject[objNumber];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objNumber; i++)
        {
            objectsToRecyle[i] = Instantiate(objectToRecycle);
            objectsToRecyle[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
