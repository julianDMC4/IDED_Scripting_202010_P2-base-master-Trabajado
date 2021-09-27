using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamager
{
      public  int Damage { get; }
      public bool IsEnemy { get; }
}

public interface IDamageable
{
      public void TakeDamage(IDamager instigator);
   
} 
    

