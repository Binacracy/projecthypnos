using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float startingHealth = 100;
    public float currentHealth;
    public float changeSpeed = 0.01f;


    public GameObject cam;
    Camera camHolder;
    Color color1;
    Color color2;
    bool damaged;

    private void Awake()
    {
        currentHealth = startingHealth;
        color1 = Color.white;
        color2 = new Color(1, color1.g - changeSpeed, color1.b - changeSpeed);
        camHolder = cam.GetComponent<Camera>();
        camHolder.clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            camHolder.backgroundColor = Color.Lerp(color1, color2, 1);
        }
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        changeSpeed *= amount;
        color1 = color2;
        color2 = new Color(1, color2.g - changeSpeed, color2.b - changeSpeed);
    }
}
