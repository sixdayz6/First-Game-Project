using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : player
{
    private Animator animator;

    private void Awake()
    {
        StartCoroutine(NextWave());
        // animator = GetComponent<Animator>();

    }
    private void Update()
    {
        if(currentHealth == 0)
        {
            Destroy(gameObject);
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
        while (true)
        {
            yield return new WaitForSeconds(GameManager.Instance.difficulty);
            transform.Translate(Vector3.forward * 2);
        }
    }
}
