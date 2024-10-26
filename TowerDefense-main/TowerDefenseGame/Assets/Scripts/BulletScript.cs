using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private float speed = 10f;

    private int damage = 10;

    private Transform target;

    public Transform Target 
    {
        set 
        { 
            target = value;
            TakeForce(target);
            transform.LookAt(target);
        }
    }

    private void Awake()
    {
    }

    private void Update()
    {
        
    }

    private void TakeForce(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        rb.AddForce(dir * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            //col.GetComponent<Enemy>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
