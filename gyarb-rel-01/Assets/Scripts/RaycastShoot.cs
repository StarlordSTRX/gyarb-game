using UnityEngine;
using System.Collections;

public class RaycastShoot : MonoBehaviour {


    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hiForce = 100f;
    public Transform gunEnd;


    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    //https://youtu.be/AGd16aspnPA?t=536


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
