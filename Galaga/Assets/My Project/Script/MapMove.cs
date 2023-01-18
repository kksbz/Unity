using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public Renderer render;
    public float mapSpeed = 0.5f;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = Time.time * mapSpeed;
        render.material.SetTextureOffset("_MainTex", new Vector3(0, offset));
    }
}
