using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static Target S;
    public Vector2 top_right_corner;
    public Vector2 bottom_left_corner;
    public GameObject currentTarget;
    LayerMask layerMask;

    private void Start()
    {
         layerMask = LayerMask.GetMask("Enemy");
  
        S = this;
    }



    private void FixedUpdate()
    {
      
       
    }
    public void OnDistance()
    {
        var _collider = Physics2D.OverlapAreaAll(top_right_corner, bottom_left_corner, layerMask);

        float dist = Mathf.Infinity;

        Collider2D currentCollider = _collider[0];
        if (currentCollider == null)
        {
            Debug.Log("Collider Null");
        }
        else
        {
            foreach (Collider2D col in _collider)
            {
                float currentDist = Vector2.Distance(transform.position, col.transform.position);
                if (currentDist < dist)
                {
                    currentCollider = col;
                    dist = currentDist;
                }
            }
            currentTarget = currentCollider.gameObject;
        }
    }


    private void OnDrawGizmos()
    {

        CustomDebug.DrawRectange(top_right_corner, bottom_left_corner);

    }
}
