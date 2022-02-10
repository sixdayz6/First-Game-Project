using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    public Healthbar healthbar;
    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        StartCoroutine(NextWave());
        // animator = GetComponent<Animator>();

    }
    private void Update()
    {
        if(currentHealth == 0)
        {
            Destroy(gameObject);
            GameManager.Instance.gold += 10;
            Debug.Log("Enemey Killed!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20);
            // animator.SetTrigger("OnHit");
            Destroy(other.gameObject);
            Debug.Log("Bullet Destoried");
        }
    }
    IEnumerator NextWave()
    {
        for(int i = 0; i <= 10; i++)
        {
            transform.Translate(Vector3.forward * 2);
            yield return new WaitForSeconds(2.0f);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }
}
