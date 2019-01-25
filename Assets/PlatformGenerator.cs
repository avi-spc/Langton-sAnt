using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    Vector3[] vertices;

    public int xSize;
    public int zSize;

    public GameObject platformUnit;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePlatform() {
        vertices = new Vector3[xSize * zSize];
        for (int i=0, z = 0; z < zSize; z++) {
            for (int x = 0; x < xSize; x++) {
                vertices[i] = new Vector3(x, 0, z);
                GameObject platUnit = Instantiate(platformUnit, vertices[i], Quaternion.Euler(90, 0, 0));
                i++;
            }
        }

        

    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < vertices.Length; i++) {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
