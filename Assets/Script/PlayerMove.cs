using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk, attack, interact, idle, stagger
}

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;
    private Vector3 change;
    public PlayerState State;
    //public FloatValue PlayerHP;

    void Start()
    {
        State = PlayerState.walk;
        myAnimator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator.SetFloat("MoveX", 0);
        myAnimator.SetFloat("MoveY", -1);

    }


    void FixedUpdate()
    {
        //if (State == PlayerState.interact)
        //{
        //    return;
        //}
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && State != PlayerState.attack && State != PlayerState.stagger)
        {
            StartCoroutine(Attacking());
        }
        else if (State == PlayerState.walk || State == PlayerState.idle)
        {
            AnimeAndMove();
        }
    }
    private IEnumerator Attacking()
    {
        myAnimator.SetBool("attacking", true);
        State = PlayerState.attack;
        yield return null;
        myAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (State != PlayerState.interact)
        {
            State = PlayerState.idle;
        }
    }

    void MovePlayer()
    {
        change.Normalize();
        myRigidbody2D.MovePosition(transform.position + change * MoveSpeed * Time.deltaTime);
    }
    void AnimeAndMove()
    {
        if (change != Vector3.zero)
        {
            MovePlayer();
            myAnimator.SetFloat("MoveX", change.x);
            myAnimator.SetFloat("MoveY", change.y);
            myAnimator.SetBool("moving", true);
        }
        else
        {
            myAnimator.SetBool("moving", false);
        }
    }
}
