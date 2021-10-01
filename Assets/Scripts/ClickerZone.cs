using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class ClickerZone : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bulletPrafab;
     private float _shootDelay = 0.7f; 
     bool _shootStatus = true;

    IEnumerator Reload()
    {
        _shootStatus = false;
        yield return new WaitForSeconds(_shootDelay);
        _shootStatus = true;
        StopCoroutine(Reload());
    }

    private void Update()
    {
        Fire();
        
    }

    /// <summary>Метод отвечающий за стрельбу тачпадом </summary>
    private void Fire()
    {
        if (_shootStatus)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Debug.Log("Touch click");
                        StartCoroutine(Reload());
                        Instantiate(_bulletPrafab, _player.transform.position, Quaternion.identity);
                        break;
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_shootStatus)
        {
            Debug.Log("CLICK mouse!!");
            StartCoroutine(Reload());
            Instantiate(_bulletPrafab, _player.transform.position, Quaternion.identity);
        }
    }
}


  
