using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class ClickerZone : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bulletPrafab;
     private float _shootDelay = 0.7f; 
     bool _shootStatus = true;

   

    private FireController _inputs;

    private void OnEnable()
    {
        _inputs.Enable();
    }
    private void OnDisable()
    {
        _inputs.Disable();
    }

    private void Awake()
    {
        _inputs = new FireController();
    }
    private void Start()
    {
        _inputs.FireOnClick.FireOnMouse.performed += FireMouse;
    }

    private void FixedUpdate()
    {
        Fire();
    }

    private void FireMouse(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            if (_shootStatus)
            {
                Debug.Log("CLICK mouse!!");
                StartCoroutine(Reload());
                Instantiate(_bulletPrafab, _player.transform.position, Quaternion.identity);
            }
            
        }
    }
    IEnumerator Reload()
    {
        _shootStatus = false;
        yield return new WaitForSeconds(_shootDelay);
        _shootStatus = true;
        StopCoroutine(Reload());
    }
    private void Fire()
    {
        if (_shootStatus)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case UnityEngine.TouchPhase.Began:
                        Debug.Log("Touch click");
                        StartCoroutine(Reload());
                        Instantiate(_bulletPrafab, _player.transform.position, Quaternion.identity);
                        break;
                }
            }
        }
    }
}


  
