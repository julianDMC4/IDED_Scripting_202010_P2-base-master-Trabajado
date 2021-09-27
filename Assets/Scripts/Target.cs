using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Target : MonoBehaviour,IDamager,IDamageable
{


    [SerializeField]
    private int maxHP = 1;

    private int currentHP;

    [SerializeField]
    private int scoreAdd = 10;

    public int Damage => 1;

    public bool IsEnemy => true;

    private void Start()
    {
        currentHP = maxHP;

    }

    private void OnCollisionEnter(Collision collision)
    {
      

        if (collision.gameObject.GetComponent<IDamager>()!= null)
        {
            collision.gameObject.SetActive(false);

            TakeDamage((IDamager)collision);

            if (currentHP <= 0)
            {
                Player player = FindObjectOfType<Player>();

                if (player != null)
                {
                    player.Score += scoreAdd;
                }

                gameObject.SetActive(false);
            }

        }
        else if (collision.gameObject.GetComponent<IDamageable>() != null) 
        {

            //(IDamageable)collision<IDamageable>.TakeDamage;

            gameObject.SetActive(false);
          
        }
    }

    public void TakeDamage(IDamager instigator)
    {
        if (!instigator.IsEnemy) 
        {
            currentHP -= instigator.Damage;
        }
        
       
    }
}
