using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
    }
     public void SpawnAsteroid()
     {
        position = new Vector3(Random.Range(-8,8), transform.position.y);
        Instantiate(asteroid, position, Quaternion.identity);
    }
}   
