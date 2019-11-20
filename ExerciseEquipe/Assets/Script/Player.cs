using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D m_rigid;
    Vector2 velocity = new Vector2();
    Vector2 jump = new Vector2();

    public float velo = 0f;
    public float movespeed = 0f;
    //Rigidbody2D rb2d;
    private bool canjump;
    // Start is called before the first frame update
    void Start()
    {
        canjump = true;
        //rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        velocity = m_rigid.velocity;

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = movespeed;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -movespeed;
        }
        else
        {
            velocity.x = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canjump)
            {
                jump.y = velo;
                m_rigid.AddForce(jump);
                //canjump = false;
            }
        }

        Debug.DrawRay(transform.position - new Vector3(0f, 0.5f, 0f), new Vector2(0f, -0.01f), Color.black);

        //RaycastHit2D hit
        bool rayCastMid = Physics2D.Raycast(transform.position - new Vector3(0f, 0.5f, 0f), new Vector2(0f, -0.01f), .5f, LayerMask.GetMask("Floor" , "Platforme"));//  1 << 8);// LayerMask.NameToLayer("Floor"));
        bool rayCastleft = Physics2D.Raycast(transform.position - new Vector3(-0.25f, 0.5f, 0f), new Vector2(0f, -0.01f), .5f, LayerMask.GetMask("Floor", "Platforme"));
        bool rayCastright = Physics2D.Raycast(transform.position - new Vector3(0.25f, 0.5f, 0f), new Vector2(0f, -0.01f), .5f, LayerMask.GetMask("Floor", "Platforme"));
      //  if (hit.collider != null)
        if(rayCastleft || rayCastMid || rayCastright)
        {
           // Debug.Log(hit.collider);
            canjump = true;
        }
        else
        {
           // Debug.Log("Nope");
            canjump = false;
        }
    }
    private void FixedUpdate()
    {
        
        m_rigid.velocity = velocity;
    }
    //  void OnCollisionEnter2D(Collision2D collision)
    // {
    //    canjump = true;
    // }
}
