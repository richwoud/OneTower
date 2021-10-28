using UnityEngine;

public class BulletProperty : MonoBehaviour
{
    [SerializeField] private float _speedBullet;
    private float _aliveTime = 3.0f;
    private int _damage;

    private void Awake()
    {
        _speedBullet = PlayerPrefs.GetFloat("SpeedBullet");
        _damage = PlayerPrefs.GetInt("DamageBullet");
    }


    public int DamageBullet { get { return _damage; } set { _damage = value; } }
    public float SpeedBullet { get { return _speedBullet; } set { _speedBullet = value; } }
    public float AliveTime { get { return _aliveTime; }}
    


}
