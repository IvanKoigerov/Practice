using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogEnemy : Enemy
{
    public Rigidbody2D enemyBody;

    [Header("Follow")]
    public Transform target;
    public float chaceRadius;
    public float attackRadius;
    //public Transform homePosition;
    //[Header("Anime")]
    private Animator enemyAnim;

    void Start()
    {
        State = EnemyState.idle;
        enemyBody = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        enemyAnim.SetBool("wakeUp", true);
    }

    void FixedUpdate()
    {
        ChackedDis();
    }

    public virtual void ChackedDis()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaceRadius && Vector2.Distance(target.position, transform.position) > attackRadius)
        {
            if (State == EnemyState.idle || State == EnemyState.walk && State != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                enemyBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                enemyAnim.SetBool("wakeUp", true);
            }

        }
        else if (Vector3.Distance(target.position, transform.position) > chaceRadius)
        {
            ChangeState(EnemyState.idle);
            enemyAnim.SetBool("wakeUp", false);
        }
    }

    public void changeAnim(Vector2 walk)
    {
        if (Mathf.Abs(walk.x) > Mathf.Abs(walk.y))
        {
            if (walk.x > 0)
            {
                //enemyAnim.SetFloat("MoveX", 1);
                SetAnimFloat(Vector2.right);
            }
            else
            {
                //enemyAnim.SetFloat("MoveX", -1);
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(walk.x) < Mathf.Abs(walk.y))
        {
            if (walk.y > 0)
            {
                SetAnimFloat(Vector2.up);
                //enemyAnim.SetFloat("MoveY", 1);
            }
            else
            {
                SetAnimFloat(Vector2.down);
                //enemyAnim.SetFloat("MoveY", -1);
            }
        }
    }

    public void SetAnimFloat(Vector2 setVector)
    {
        enemyAnim.SetFloat("MoveX", setVector.x);
        enemyAnim.SetFloat("MoveY", setVector.y);
    }


    public void ChangeState(EnemyState newState)
    {
        if (State != newState)
        {
            State = newState;
        }
    }
}
