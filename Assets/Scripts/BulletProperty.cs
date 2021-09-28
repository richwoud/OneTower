using UnityEngine;

public class BulletProperty : MonoBehaviour
{
    [SerializeField] private float _speedBullet = 10.0f;
    private float _aliveTime = 3.0f;
    private float _damage = 1f;
    public float DamageBullet { get { return _damage; } set { _damage = value; } }
    public float SpeedBullet { get { return _speedBullet; } set { _speedBullet = value; } }
    public float AliveTime { get { return _aliveTime; }}

}
