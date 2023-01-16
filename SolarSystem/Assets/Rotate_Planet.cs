using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Planet : MonoBehaviour
{
    public GameObject Sun;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void PlanetAround()
    {
        transform.RotateAround(Sun.transform.position, Vector3.up, speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        PlanetAround();
    }
}
