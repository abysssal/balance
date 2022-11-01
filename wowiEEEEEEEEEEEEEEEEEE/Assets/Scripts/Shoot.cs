using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [Header("Buildings")]
    public GameObject woodWall;
    public GameObject stoneWall;
    public GameObject goldWall;
    public GameObject meleeHitman;
    public GameObject speedyHitman;
    public GameObject stronkHitman;

    [Header("Components")]
    public GameObject bulletPrefab;
    public Transform gunTip;
    public Transform gunTip1;
    public Transform gunTip2;
    public Transform gunTip3;
    public Transform gunTip4;
    public Canvas buildingMenu;
    public Text selectedText;
    public Text currentWeapon;
    public Text lastGun;
    public Image currentWeaponImg;
    public Player plrScr;
    public AudioSource shoot;
    public SpriteRenderer outLine;
    public Sprite pistolSprite;
    public Sprite revolverSprite;
    public Sprite uziSprite;
    public Sprite shotgunSprite;
    public Sprite arSprite;
    public Sprite sniperSprite;

    [Header("Integers and Floats")]
    public float bulletForce;
    public float dmg;
    public float range;
    public float fireRate;
    public int buildSelected;
    public int choice;
    public int weaponSelected;
    

    [Header("Boolean Values")]
    public bool building = false;
    public bool unlockedRevolver;
    public bool unlockedUzi;
    public bool unlockedShotgun;
    public bool unlockedAr;
    public bool unlockedSniper;
    public bool canShoot;

    private void Awake()
    {
        plrScr = gameObject.GetComponent<Player>();
        buildingMenu = GameObject.Find("BuildingMenu").GetComponent<Canvas>();
        selectedText = GameObject.Find("WhatIsSelected").GetComponent<Text>();
        dmg = 1;
        weaponSelected = 1;
        canShoot = true;
    }

    private void Update()
    {
        if (!building)
        {
            outLine.enabled = false;
        }

        if (building)
        {
            outLine.enabled = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (building)
            {
                if (buildSelected == 1)
                {
                    outLine.enabled = true;
                    if (plrScr.gold >= 75)
                    {
                        StartCoroutine(BuildWoodWall());
                    }
                }

                if (buildSelected == 2)
                {
                    outLine.enabled = true;
                    if (plrScr.gold >= 150)
                    {
                        StartCoroutine(BuildStoneWall());
                    }
                }

                if (buildSelected == 3)
                {
                    outLine.enabled = true;
                    if (plrScr.gold >= 225)
                    {
                        StartCoroutine(BuildGoldWall());
                    }
                }

                if (buildSelected == 4)
                {
                    outLine.enabled = false;
                    if (plrScr.gold >= 200)
                    {
                        StartCoroutine(HireMeleeHitman());
                    }
                }

                if (buildSelected == 5)
                {
                    outLine.enabled = false;
                    if (plrScr.gold >= 225)
                    {
                        StartCoroutine(HireSpeedyHitman());
                    }
                }

                if (buildSelected == 6)
                {
                    outLine.enabled = false;
                    if (plrScr.gold >= 250)
                    {
                        StartCoroutine(HireStronkHitman());
                    }
                }
            }

            if (weaponSelected == 1 && building == false && canShoot == true)
            {
                range = 3;
                dmg = 20;
                bulletForce = 20;
                fireRate = 0.2f;
                outLine.enabled = false;
                if (plrScr.gold >= 1)
                {
                    StartCoroutine(FireBullet());
                    shoot.pitch = Random.Range(0.5f, 1.3f);
                    shoot.Play();
                    StartCoroutine(FireRate());
                }
            }

            if (weaponSelected == 2 && building == false && canShoot == true && unlockedRevolver)
            {
                range = 5;
                dmg = 25;
                bulletForce = 25;
                fireRate = 0.5f;
                outLine.enabled = false;
                if (plrScr.gold >= 1)
                {
                    StartCoroutine(FireBullet());
                    shoot.pitch = Random.Range(0.4f, 1.1f);
                    shoot.Play();
                    StartCoroutine(FireRate());
                }
            }

            if (weaponSelected == 3 && building == false && canShoot == true && unlockedUzi)
            {
                range = 2.5f;
                dmg = 18;
                bulletForce = 45;
                fireRate = 0.05f;
                outLine.enabled = false;
                if (plrScr.gold >= 1)
                {
                    StartCoroutine(FireBullet());
                    shoot.pitch = Random.Range(0.8f, 1.4f);
                    shoot.Play();
                    StartCoroutine(FireRate());
                }
            }

            if (weaponSelected == 4 && building == false && canShoot == true && unlockedShotgun)
            {
                range = 2f;
                dmg = 20;
                bulletForce = 25;
                fireRate = 1f;
                outLine.enabled = false;
                if (plrScr.gold >= 1)
                {
                    StartCoroutine(FireShotgun());
                    shoot.pitch = Random.Range(0.8f, 1.4f);
                    shoot.Play();
                    StartCoroutine(FireRate());
                }
            }

            if (weaponSelected == 5 && building == false && canShoot == true && unlockedAr)
            {
                range = 5f;
                dmg = 25;
                bulletForce = 40;
                fireRate = 0.16f;
                outLine.enabled = false;
                if (plrScr.gold >= 1)
                {
                    StartCoroutine(FireBullet());
                    shoot.pitch = Random.Range(0.8f, 1.4f);
                    shoot.Play();
                    StartCoroutine(FireRate());
                }
            }

            if (weaponSelected == 6 && building == false && canShoot == true && unlockedSniper)
            {
                range = 10f;
                dmg = 50;
                bulletForce = 80;
                fireRate = 1.25f;
                outLine.enabled = false;
                if (plrScr.gold >= 1)
                {
                    StartCoroutine(FireBullet());
                    shoot.pitch = Random.Range(0.8f, 1.4f);
                    shoot.Play();
                    StartCoroutine(FireRate());
                }
            }
        }
        
        if (plrScr.totalKills >= 50)
        {
            unlockedRevolver = true;
            lastGun.text = "Last Gun Unlock: Revolver";
        }

        if (plrScr.totalKills >= 75)
        {
            unlockedUzi = true;
            lastGun.text = "Last Gun Unlock: UZI";
        }

        if (plrScr.totalKills >= 125)
        {
            unlockedShotgun = true;
            lastGun.text = "Last Gun Unlock: Shotgun";
        }

        if (plrScr.totalKills >= 180)
        {
            unlockedAr = true;
            lastGun.text = "Last Gun Unlock: Assault Rifle";
        }

        if (plrScr.totalKills >= 225)
        {
            unlockedSniper = true;
            lastGun.text = "Last Gun Unlock: Sniper";
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!building)
            {
                building = true;
                buildingMenu.enabled = true;
            } else if (building)
            {
                building = false;
                buildingMenu.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && building == true)
        {
            buildSelected = 1;
            selectedText.text = "Wood wall selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && building == true)
        {
            buildSelected = 2;
            selectedText.text = "Stone wall selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && building == true)
        {
            buildSelected = 3;
            selectedText.text = "Gold wall selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && building == true)
        {
            buildSelected = 4;
            selectedText.text = "Melee hitman selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && building == true)
        {
            buildSelected = 5;
            selectedText.text = "Speedy hitman selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && building == true)
        {
            buildSelected = 6;
            selectedText.text = "Stronk hitman selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && building == false)
        {
            weaponSelected = 1;
            currentWeaponImg.sprite = pistolSprite;
            currentWeapon.text = "Pistol";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && building == false && unlockedRevolver)
        {
            weaponSelected = 2;
            currentWeaponImg.sprite = revolverSprite;
            currentWeapon.text = "Revolver";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && building == false && unlockedUzi)
        {
            buildSelected = 3;
            currentWeaponImg.sprite = uziSprite;
            currentWeapon.text = "UZI";
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && building == false && unlockedShotgun)
        {
            weaponSelected = 4;
            currentWeaponImg.sprite = shotgunSprite;
            currentWeapon.text = "Shotgun";
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && building == false && unlockedAr)
        {
            weaponSelected = 5;
            currentWeaponImg.sprite = arSprite;
            currentWeapon.text = "Assault Rifle";
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && building == false && unlockedSniper)
        {
            weaponSelected = 6;
            currentWeaponImg.sprite = sniperSprite;
            currentWeapon.text = "Sniper";
        }
    }

    public IEnumerator FireRate()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public IEnumerator FireBullet()
    {
        plrScr.gold--;
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
        Rigidbody2D bRB = bullet.GetComponent<Rigidbody2D>();
        bRB.AddForce(gunTip.up * bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator FireShotgun()
    {
        plrScr.gold--;
        plrScr.gold--;
        plrScr.gold--;
        plrScr.gold--;
        plrScr.gold--;
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
        GameObject bullet1 = Instantiate(bulletPrefab, gunTip1.position, gunTip1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, gunTip2.position, gunTip2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, gunTip3.position, gunTip3.rotation);
        GameObject bullet4 = Instantiate(bulletPrefab, gunTip4.position, gunTip4.rotation);
        Rigidbody2D bRB = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D bRB1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D bRB2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D bRB3 = bullet3.GetComponent<Rigidbody2D>();
        Rigidbody2D bRB4 = bullet4.GetComponent<Rigidbody2D>();
        bRB.AddForce(gunTip.up * bulletForce, ForceMode2D.Impulse);
        bRB1.AddForce(gunTip1.up * bulletForce, ForceMode2D.Impulse);
        bRB2.AddForce(gunTip2.up * bulletForce, ForceMode2D.Impulse);
        bRB3.AddForce(gunTip3.up * bulletForce, ForceMode2D.Impulse);
        bRB4.AddForce(gunTip4.up * bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator BuildWoodWall()
    {
        plrScr.gold -= 75;
        GameObject wall = Instantiate(woodWall, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator BuildStoneWall()
    {
        plrScr.gold -= 150;
        GameObject wall = Instantiate(stoneWall, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator BuildGoldWall()
    {
        plrScr.gold -= 225;
        GameObject wall = Instantiate(goldWall, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator HireMeleeHitman()
    {
        plrScr.gold -= 200;
        GameObject hitman = Instantiate(meleeHitman, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator HireSpeedyHitman()
    {
        plrScr.gold -= 225;
        GameObject hitman = Instantiate(speedyHitman, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator HireStronkHitman()
    {
        plrScr.gold -= 250;
        GameObject hitman = Instantiate(stronkHitman, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }
}