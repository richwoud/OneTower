using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class ClickerZone : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bulletPrafab;
    [SerializeField] private float _shootDelay;
    bool _shootStatus = true;

    void Start()
    {
        _shootDelay =  PlayerPrefs.GetFloat("ReloadDelay");
    }

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

    /// <summary>����� ���������� �� �������� �������� </summary>
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


  
