using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image currentHealthbar;
    public Text ratioText;

    private float hitpoint = 150;
    private float maxHitpoint = 150;

    private void start()
    {
        UpdateHealthbar();

    }


    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

    private void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if (hitpoint <= 0)
        {
            gameOver();
            hitpoint = 0;
           


        }
        UpdateHealthbar();
    }

    private void HealDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
            hitpoint = maxHitpoint;

        UpdateHealthbar();
    }

    void gameOver()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        print("You're Dead!    Game Over");
    }


      
}