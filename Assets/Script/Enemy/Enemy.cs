using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    walk, idle, attack, stagger
}

public class Enemy : MonoBehaviour
{

    [Header("")]
    public EnemyState State;
    [Header("")]
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int enemyAttack;
    public float enemySpeed;
    [Header("")]
    public GameObject deathEffect;


    private void Awake()
    {
        health = maxHealth.initialValue;
        //transform.position = homePositions;
    }
    public void Knock(Rigidbody2D enemy, float knockTime, float damage)
    {
        StartCoroutine(Knocked(enemy, knockTime));
        TakeDamage(damage);
    }
    private IEnumerator Knocked(Rigidbody2D enemy, float knockTime)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            State = EnemyState.idle;
            enemy.velocity = Vector2.zero;
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //DeathEffect();
            //if (roomSignal != null)
            //{
            //    roomSignal.Raise();
            //}
            this.gameObject.SetActive(false);
        }
    }
    //private void DeathEffect()
    //{
    //    if (deathEffect != null)
    //    {
    //        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
    //        Destroy(effect, 1f);
    //    }
    //}
}
