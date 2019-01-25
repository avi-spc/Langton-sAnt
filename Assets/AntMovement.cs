using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{
    Color unitColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.RightArrow)) {
        //    transform.Rotate(new Vector3(0, 90, 0));
        //    transform.Translate(0, 0, 1);
        //}
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Square")) {
            float r = col.gameObject.GetComponentInParent<Renderer>().material.color.r;
            float g = col.gameObject.GetComponentInParent<Renderer>().material.color.g;
            float b = col.gameObject.GetComponentInParent<Renderer>().material.color.b;
            float a = col.gameObject.GetComponentInParent<Renderer>().material.color.a;

            if (r == 1f && g == 1f && b == 1f && a == 1f) {
                // transform.Translate(new Vector3(1, 0, 1) * Time.deltaTime * 3f);
                transform.Rotate(new Vector3(0, 90, 0));
                transform.Translate(0, 0, 1);
                col.gameObject.GetComponentInParent<Renderer>().material.color = Color.red;
            }

            if (r == 1f && g == 0f && b == 0f && a == 1f) {
                //transform.Translate(new Vector3(0, 0, 1));
                transform.Rotate(new Vector3(0, -90, 0));
                transform.Translate(0, 0, 1);
                col.gameObject.GetComponentInParent<Renderer>().material.color = Color.white;
            }
            Debug.Log(unitColor);
        }
    }
}
