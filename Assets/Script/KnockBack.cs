using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [Header("")]
    public float thrust; //толчок
    public float knockTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy") && other.isTrigger && !this.CompareTag("Enemy"))
                {
                    hit.GetComponent<Enemy>().State = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if (other.gameObject.CompareTag("Player") && other.isTrigger)
                {
                    if (other.GetComponent<PlayerMove>().State != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMove>().State = PlayerState.stagger;
                        other.GetComponent<PlayerMove>().Knock(knockTime, damage);
                    }
                }

            }
        }
        if (other.CompareTag("Breakable") && this.gameObject.CompareTag("hit"))
        {
            //other.GetComponent<OBJ1>().Smash();
        }

    }

    //private IEnumerator Kcnock(Rigidbody2D enemy)
    //{
    //    if (enemy != null)
    //    {
    //        yield return new WaitForSeconds(knockTime);
    //        enemy.velocity = Vector2.zero;
    //        enemy.GetComponent<Enemy>().State = EnemyState.idle;
    //    }
    //}
}
