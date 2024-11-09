using UnityEngine;
using TMPro;

public class HealthScript : MonoBehaviour
{

    public int MaxHealth = 10;
    public int CurrentHealth;
    public TMP_Text HealthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

      CurrentHealth = MaxHealth;
      HealthText.text = CurrentHealth.ToString();

    }   


    public void TakeDamage(int AmountDamage){

        CurrentHealth -= AmountDamage;
        CurrentHealth = Mathf.Max(CurrentHealth, 0);
        HealthText.text = GetCurrentHealth().ToString();
    
            if(CurrentHealth <= 0){

               Die();

            }
    }

    public void Heal(int AmountHeal){
        CurrentHealth += AmountHeal;
        CurrentHealth = Mathf.Min(CurrentHealth,MaxHealth);
        HealthText.text = GetCurrentHealth().ToString();
    }

    void Die(){

        Debug.Log("Character Has Died");

    }

    public int GetCurrentHealth(){

        return CurrentHealth;
    }
}
