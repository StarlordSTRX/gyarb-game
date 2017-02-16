using UnityEngine;
using System.Collections;

public class DamageScriptExample : MonoBehaviour {

    public int damageToTake = 5;

    void OnTriggerEnter(Collider other)
    {
        other.SendMessage("TakeDamage", damageToTake);
    }
}
