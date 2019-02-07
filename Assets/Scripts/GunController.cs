using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;

    public Transform gunBarrelTransform;

    public float timeBetweenAttacks = 1.0f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || Input.GetButtonDown("Fire1"))
        {
            //audioSource.Play();
            RaycastGun();

        }
        
    }

    private void RaycastGun()
    {
        timer = 0f;

        RaycastHit hit;

        if (Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Cube"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}