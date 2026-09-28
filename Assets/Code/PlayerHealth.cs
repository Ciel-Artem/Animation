using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    Animator anim;

    public int MaxHealth = 3;
    public int Health;


    void Start()
    {
        Health = MaxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Dano");
        Health -= damage;
        if(Health <= 0)
        {
            anim.SetTrigger("Morte");
        }
    }


}
