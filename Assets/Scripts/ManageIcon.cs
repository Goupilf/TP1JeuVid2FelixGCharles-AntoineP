using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageIcon : MonoBehaviour
{
    private float speed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            /* https://www.youtube.com/watch?v=foM06C52Kd8 */
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
