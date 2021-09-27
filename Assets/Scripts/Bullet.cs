using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IDamager
{
    [SerializeField]
    private float bulletSpeed = 3F;
    private Rigidbody RGB;
    public int Damage => 1;
    public bool IsEnemy => false;
    private void Awake()
    {
        RGB = GetComponent<Rigidbody>();
        
    }
   
    private void OnEnable()
    {
        Spawn();
    }
    public void Spawn() 
    {
        RGB.AddForce(transform.up * bulletSpeed, ForceMode.Impulse);
    }


}
