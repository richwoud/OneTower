using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
     private Rigidbody2D _bulletRb;
     private GameObject _target;
     private BulletProperty _bulletProperty;
   


    public void Awake()
    {
        _bulletRb = this.GetComponent<Rigidbody2D>();
        _bulletProperty = GetComponent<BulletProperty>();
        _target = GameObject.FindGameObjectWithTag("Enemy");
        
        if (_target == null)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, _bulletProperty.AliveTime);
    }
    

    private void FixedUpdate()
    {
        //попробовать сделать интерфейс
       
        Vector2 moveDirection = (_target.transform.position - transform.position).normalized;
        _bulletRb.AddForce(_bulletProperty.SpeedBullet * moveDirection);
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyController>() !=null)
        {
            other.GetComponent<EnemyProperty>().TakeDamage(_bulletProperty.DamageBullet);
            this.gameObject.SetActive(false);
        }
    }

    

}
