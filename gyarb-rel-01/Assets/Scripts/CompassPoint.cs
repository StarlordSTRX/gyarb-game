using UnityEngine;
using System.Collections;

public class CompassPoint : MonoBehaviour {

    public float angleBetween = 0.0F;
    public Transform target;

    void Update() {

        Vector3 targetDir = target.position - GameObject.Find("FirstPersonCharacter").transform.position;
        angleBetween = Vector3.Angle(Vector3.Normalize(GameObject.Find("FirstPersonCharacter").transform.forward), Vector3.Normalize(targetDir));


        Vector3 res = Vector3.Cross(Vector3.Normalize(GameObject.Find("FirstPersonCharacter").transform.forward), Vector3.Normalize(targetDir));

        if(res.y < 0 && angleBetween < 0){
            angleBetween = angleBetween * -1;
        }
        if (res.y > 0 && angleBetween > 0)
        {
            angleBetween = angleBetween * -1;
        }

        transform.localRotation = Quaternion.Euler(0, 0, angleBetween);
	}
}
