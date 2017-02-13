using UnityEngine;
using System.Collections;
using System.Threading;

public class RaycastShoot : MonoBehaviour
{

    public GameObject[] bullets;
    public int amountOfBullets;

    public bool isReloading = false;
    public GameObject GunRotation;

    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 600f;
    public Transform gunEnd;


    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;

    //https://youtu.be/AGd16aspnPA?t=536


    // Use this for initialization
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
        GunRotation = GameObject.FindGameObjectWithTag("GunRotation");
        BulletCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isReloading != true) {
            Reloader();
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && amountOfBullets > -1 && isReloading != true)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

                //Send damage
                ShootableEntity health = hit.collider.GetComponent<ShootableEntity>();
                if (health != null) {
                    health.Damage(gunDamage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }

            //BULLET CODE
            bullets[amountOfBullets].SetActive(false);
            BulletCounter();

        }
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

    IEnumerator ReloadDelay(float reloadTime, int pos)
    {
        foreach (GameObject bullet in bullets)
        {
            if (bullet.activeSelf == true)
            { pos++; }
        }
        while (true)
        {
            if (pos != bullets.Length)
            {
                bullets[pos].SetActive(true);
                pos++;
                yield return new WaitForSeconds(reloadTime);
            }
            else
            {
                isReloading = false;
                Debug.Log("Reaload Complete!");
                StartCoroutine(ReloadAnimation(0.001f, false));
                break;
            }
        }
    }

    IEnumerator ReloadAnimation(float reloadTime, bool up) {
        
        if (up)
        {
            for (int i = 0; i < 10; i++)
            {
                GunRotation.transform.rotation *= Quaternion.Euler(-4.5f, 0, 0);
                yield return new WaitForSeconds(reloadTime);
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                GunRotation.transform.rotation *= Quaternion.Euler(4.5f, 0, 0);
                yield return new WaitForSeconds(reloadTime);
            }
        }
    }

    public void BulletCounter() {
       amountOfBullets = -1;
        foreach (GameObject bullet in bullets) {
            if (bullet.activeSelf)
            {
                amountOfBullets++;
            }
        }
        Debug.Log("Current: " + amountOfBullets);
        if (amountOfBullets < 0)
        {
            Debug.Log("Out of bullets");
        }
    }

    public void Reloader()
    {
        //GunRotation.transform.rotation *= Quaternion.Euler(-45, 0, 0);
        StartCoroutine(ReloadAnimation(0.001f, true));
        isReloading = true;
        StartCoroutine(ReloadDelay(0.5f, 0));
        amountOfBullets = bullets.Length - 1;
    }
}
