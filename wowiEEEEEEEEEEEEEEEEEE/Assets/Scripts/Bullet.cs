using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem destroyFX;
    public Shoot shootScr;
    public float damage;

    private void Awake()
    {
        shootScr = GameObject.Find("Player").GetComponent<Shoot>();
        damage = shootScr.dmg;
        StartCoroutine(selfDestruct());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(destroyFX, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(shootScr.range);
        Instantiate(destroyFX, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
