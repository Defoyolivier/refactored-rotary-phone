using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Vector2 m_Cam = new Vector2( 0f, 0.1f );

    private bool CamMove;
    public float Chrono = 2f;
    // Start is called before the first frame update
    void Start()
    {
        CamMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Chrono -= Time.deltaTime;

        if (Chrono <= 0f && CamMove == true)
        {
            transform.Translate(m_Cam);
        }
        if (transform.position.y >= 64f)
        {
            CamMove = false;
     
        }
    }
}
