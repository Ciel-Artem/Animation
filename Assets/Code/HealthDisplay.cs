using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int healthMax;

    public Sprite emptyHearth;
    public Sprite FullHeart;
    public Image[] hearts;

    public PlayerHealth playerHealth;


    void Update()
    {
        health = playerHealth.Health;
        healthMax = playerHealth.MaxHealth;
        for (int i = 0; i < hearts.Length; i++)
        {

            if(i < health)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHearth;
            }

            if(i < healthMax)
            {
                 hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
