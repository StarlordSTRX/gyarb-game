using UnityEngine;
using System.Collections;

public class CompassPoint : MonoBehaviour {

    public float angleBetween = 0.0F;
    public Transform target;

    void Start() {
       
    }

    void Update() {

        Vector3 targetDir = target.position - transform.position;
        angleBetween = Vector3.Angle(transform.forward, targetDir);

        //gameObject.transform.Rotate(targetDir, angleBetween);
        gameObject.transform.localRotation = Quaternion.Euler(angleBetween, 0, 0);
	}
}
