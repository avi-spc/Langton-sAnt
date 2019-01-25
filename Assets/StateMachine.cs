using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public int numberOfColors;

    public string[] directions = new string[] { "Left", "Right" };
    public string[] colors = new string[] { "White", "Red" };

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColorAndMove(Collider col) {
        float r = col.gameObject.GetComponentInParent<Renderer>().material.color.r;
        float g = col.gameObject.GetComponentInParent<Renderer>().material.color.g;
        float b = col.gameObject.GetComponentInParent<Renderer>().material.color.b;
        float a = col.gameObject.GetComponentInParent<Renderer>().material.color.a;

        if (colors[0].Equals("White")) {
            col.gameObject.GetComponentInParent<Renderer>().material.color = Color.red;
            transform.Rotate(new Vector3(0, -90, 0));
            transform.Translate(0, 0, 1);
        }

        if (colors[1].Equals("Red")) {
            col.gameObject.GetComponentInParent<Renderer>().material.color = Color.white;
            transform.Rotate(new Vector3(0, 90, 0));
            transform.Translate(0, 0, 1);
        }

        if (r == 1f && g == 1f && b == 1f && a == 1f)
        {
            // transform.Translate(new Vector3(1, 0, 1) * Time.deltaTime * 3f);
            
        }

        if (r == 1f && g == 0f && b == 0f && a == 1f)
        {
            //transform.Translate(new Vector3(0, 0, 1));
           
        }
    }
}
