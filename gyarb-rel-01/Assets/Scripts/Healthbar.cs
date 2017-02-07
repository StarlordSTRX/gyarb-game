using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Healthbar : MonoBehaviour {

    //Reference: https://www.youtube.com/watch?v=9W0xLonwbLo

    public Image currentHPbar;
    public Text hpText;

    private float hitpoint = 100;
    private float maxHitpoint = 100;

    private void Start() {
        UpdateHealthbar();
    }

    private void UpdateHealthbar() {
        float ratio = hitpoint / maxHitpoint;
        currentHPbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        hpText.text = (ratio*100).ToString() + '%';
    }

    private void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if (hitpoint <= 0)
        {
            hitpoint = 0;
            Debug.Log("DIE DIE DIE (That means THE THE THE in German");
        }
        UpdateHealthbar();
    }

    private void HealDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint >= maxHitpoint)
        {
            hitpoint = maxHitpoint;
            Debug.Log("Healed Up!");
        }
        UpdateHealthbar();
    }
}
