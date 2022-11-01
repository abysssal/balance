using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGold : MonoBehaviour
{

    public int Health;
    
    public Player plrScr;
    public ParticleSystem bullletDeath;
    public AudioSource goldMine;

    private void Awake()
    {
        plrScr = GameObject.Find("Player").GetComponent<Player>();
        goldMine = GameObject.Find("getGold").GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Health <= 0)
        {
            StartCoroutine(destroymyself());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bulllet")
        {
            Health -= 1;
            plrScr.gold += Random.Range(1, 6);
            goldMine.Play();
            Instantiate(bullletDeath, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }

    IEnumerator destroymyself()
    {
        Destroy(gameObject);
        yield return null;
    }
}
