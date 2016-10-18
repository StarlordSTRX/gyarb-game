using UnityEngine;
using System.Collections;

public class ShootableEntity : MonoBehaviour {

    public int currentHealth = 3;

	
	// Update is called once per frame
	public void Damage(int damageAmount) {

        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
	}
}
