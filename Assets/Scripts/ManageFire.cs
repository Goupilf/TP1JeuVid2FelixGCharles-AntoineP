using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFire : MonoBehaviour
{ 
    
    [SerializeField] GameObject objectToRecycle;
    [SerializeField] GameObject playerShooting;
    [SerializeField] private Transform camera;

    private GameObject[] objectsToRecyle = new GameObject[50];
    private float period = 0.0f;
    private int nbBulletInstances = 50;
    private float timeBetweenSpawnsInSec = 0.1f;
    private int numActiveBullet = 0;
    private float bulletSpeed = 10000f;
    [SerializeField] GameObject gunEnd;
    // Start is called before the first frame update

    void Start()
    {
        // Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
        for (int i = 0; i < nbBulletInstances; i++)
        {
            objectsToRecyle[i] = Instantiate(objectToRecycle, new Vector3(0, 0, 0), Quaternion.identity);
            objectsToRecyle[i].SetActive(true);
            objectsToRecyle[i].transform.GetChild(0).gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        CountActive();
        if (Input.GetButtonDown("Fire1"))
        {
            
            if (period > timeBetweenSpawnsInSec && numActiveBullet < nbBulletInstances)
            {
                SpawnObjectToRecycle();
                period = 0;
            }
            
        }
        period += UnityEngine.Time.deltaTime;
    }

    private void SpawnObjectToRecycle()
    {
        for (int i = 0; i < nbBulletInstances; i++)
            if (!objectsToRecyle[i].transform.GetChild(0).gameObject.activeSelf)
            {
                objectsToRecyle[i].transform.GetChild(0).gameObject.SetActive(true);
                objectsToRecyle[i].transform.position = new Vector3(gunEnd.transform.position.x, gunEnd.transform.position.y, gunEnd.transform.position.z);
                objectsToRecyle[i].transform.GetChild(0).gameObject.transform.position = new Vector3(gunEnd.transform.position.x, gunEnd.transform.position.y, gunEnd.transform.position.z);
                // transposer le bullet vers le bout du canon et lui donné une vitesse et un angle
                // reste a acceder l'enfant du player pour trouvé le bout du canon
                // objectsToRecyle[i].transform.rotation = playerShooting.transform.rotation;
                objectsToRecyle[i].GetComponentInChildren<Rigidbody>().velocity = Vector3.zero;
                objectsToRecyle[i].GetComponentInChildren<Rigidbody>().AddForce(playerShooting.transform.forward * bulletSpeed);
                // reste a faire que la balle se dirige dans le meme sense que le player;
                return;
            }
    }
    private void CountActive()
    {
        int numActiveObj = 0;
        for (int i = 0; i < objectsToRecyle.Length; i++)
        {
            if (objectsToRecyle[i].transform.GetChild(0).gameObject.activeSelf == true)
            {
                numActiveObj++;
            }
        }
        this.numActiveBullet = numActiveObj;

    }
    
}
