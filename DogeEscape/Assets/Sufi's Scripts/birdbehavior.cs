using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdbehavior : MonoBehaviour
{
    public GameObject PointC;
    public GameObject PointD;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentpoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentpoint = PointC.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentpoint.position - transform.position;
        if (currentpoint == PointC.transform)
        {
            rb.velocity = new Vector2(0, -speed);
        }
        else
        {
            rb.velocity = new Vector2(0, speed);
        }

        if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == PointC.transform)
        {
            currentpoint = PointD.transform;
        }
        if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == PointD.transform)
        {
            currentpoint = PointC.transform;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointD.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointC.transform.position, 0.5f);
        Gizmos.DrawLine(PointD.transform.position, PointC.transform.position);
    }
}
