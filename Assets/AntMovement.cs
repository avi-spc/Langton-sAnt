using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{
    Color unitColor;
    public Color[] colors;
    public string[] directions;

    int colorState = 0;
    // Start is called before the first frame update
    void Awake()
    {
        colors = new Color[] { Color.white, Color.red };
        directions = new string[] { "Left", "Right" };
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.RightArrow)) {
        //    transform.Rotate(new Vector3(0, 90, 0));
        //    transform.Translate(0, 0, 1);
        //}
    }

    private void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag.Equals("Square")) {
            float r = col.gameObject.GetComponentInParent<Renderer>().material.color.r;
            float g = col.gameObject.GetComponentInParent<Renderer>().material.color.g;
            float b = col.gameObject.GetComponentInParent<Renderer>().material.color.b;
            float a = col.gameObject.GetComponentInParent<Renderer>().material.color.a;

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i].r == r && colors[i].g == g && colors[i].b == b && colors[i].a == a)
                {
                    colorState = i;
                    break;
                }
            }

            if (r == colors[colorState].r && g == colors[colorState].g && b == colors[colorState].b && a == colors[colorState].a)
            {
                // transform.Translate(new Vector3(1, 0, 1) * Time.deltaTime * 3f);
                int nextState = (colorState + 1) % colors.Length;
                col.gameObject.GetComponentInParent<Renderer>().material.color = colors[nextState];
                if (directions[nextState].Equals("Left"))
                    transform.Rotate(new Vector3(0, -90, 0));
                else if (directions[nextState].Equals("Right"))
                    transform.Rotate(new Vector3(0, 90, 0));
                transform.Translate(0, 0, 1);
                Debug.Log(nextState);
            }

            



            //if (r == colors[colorState].r && g == colors[colorState].g && b == colors[colorState].b && a == colors[colorState].a)
            //{
            //    // transform.Translate(new Vector3(1, 0, 1) * Time.deltaTime * 3f);
            //    col.gameObject.GetComponentInParent<Renderer>().material.color = colors[colorState];
            //    transform.Rotate(new Vector3(0, 90, 0));
            //    transform.Translate(0, 0, 1);
            //    colorState = 0;
            //}

            //if (r == 1f && g == 0f && b == 0f && a == 1f)
            //{
            //    //transform.Translate(new Vector3(0, 0, 1));
            //    col.gameObject.GetComponentInParent<Renderer>().material.color = Color.white;
            //    transform.Rotate(new Vector3(0, 90, 0));
            //    transform.Translate(0, 0, 1);
            //}
            //Debug.Log(unitColor);
        }
    }
}
