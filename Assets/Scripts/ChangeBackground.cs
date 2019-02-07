using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public Camera cam;
    public float change = 0.005f;
    Color color1 = Color.white;
    Color color2 = new Color(1, 0.99f, 0.99f);

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            cam.backgroundColor = Color.Lerp(color1, color2, 1);
            changeColors();
        }
    }

    public void changeColors()
    {
        color1 = color2;
        color2 = new Color(1, color2.g - change, color2.b - change);
    }
}
