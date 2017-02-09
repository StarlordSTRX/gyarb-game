using UnityEngine;
using System.Collections;
using System.Threading;

public class RaycastShoot : MonoBehaviour
{

    public GameObject[] bullets;
    public int amountOfBullets;

    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 600f;
    public Transform gunEnd;


    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f); //decleared here to optimize memory preformance
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

        BulletCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Reloader();
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && amountOfBullets > 0)
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

    IEnumerator ReloadDelay(int reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
    }

    public void BulletCounter() {
       amountOfBullets = -1;
        foreach (GameObject bullet in bullets) {
            if (bullet.activeSelf)
            {
                amountOfBullets++;
            }
        }
        if (amountOfBullets <= 0)
        {
            Debug.Log("Out of bullets");
        }
    }

    public void Reloader()
    {
        foreach (GameObject bullet in bullets)
        {
            bullet.SetActive(true);
            ReloadDelay(4);
        }
        amountOfBullets = bullets.Length - 1;
    }
}
