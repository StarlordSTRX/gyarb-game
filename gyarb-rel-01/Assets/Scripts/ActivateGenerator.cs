using UnityEngine;
using System.Collections;

public class ActivateGenerator : MonoBehaviour {

    public GameObject target;
    public float maxRange = 1;

	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, target.transform.position);
	    if(distance < maxRange && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("PRESSED E, GENERATOR ACTIVE");             
        }
	}
}
