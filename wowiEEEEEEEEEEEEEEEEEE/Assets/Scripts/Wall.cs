using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int hp;

    public ParticleSystem destroyEffect;
    public AudioSource wallGoBoom;

    private void Start()
    {
        wallGoBoom = GameObject.Find("buildGoBoom").GetComponent<AudioSource>(); 
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            wallGoBoom.Play();
            Destroy(gameObject);
        }
    }

}
