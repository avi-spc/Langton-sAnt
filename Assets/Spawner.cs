using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static PlatformGenerator platformGenerator;

    public int xPos;
    public int zPos;

    public GameObject ant, platform/*, lookTarget*/;

    // Start is called before the first frame update
    void Start()
    {
        
        platform = GameObject.Find("Platform");
        xPos = platform.GetComponent<PlatformGenerator>().xSize/2;
        zPos = platform.GetComponent<PlatformGenerator>().zSize/2;
        transform.position = new Vector3(8, xPos * 2, 9.5f);
        Instantiate(ant, new Vector3(xPos, 0, zPos), Quaternion.identity);
       //GameObject lT = Instantiate(lookTarget, new Vector3(xPos, 0, zPos), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
