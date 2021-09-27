using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Player : MonoBehaviour,IDamageable
{
    public const int PLAYER_LIVES = 3;

    private const float PLAYER_RADIUS = 0.4F;

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 1F;

    private float hVal;

    #region Bullet

    [Header("Bullet")]
    [SerializeField]
    private PoolCreator bullet;

    [SerializeField]
    private Transform bulletSpawnPoint;

   

    #endregion Bullet

    #region BoundsReferences

    private float referencePointComponent;
    private float leftCameraBound;
    private float rightCameraBound;

    #endregion BoundsReferences

    #region StatsProperties

    public int Score { get; set; }
    public int Lives { get; set; }

    #endregion StatsProperties

    #region MovementProperties

    public bool ShouldMove
    {
        get =>
            (hVal != 0F && InsideCamera) ||
            (hVal > 0F && ReachedLeftBound) ||
            (hVal < 0F && ReachedRightBound);
    }

    private bool InsideCamera
    {
        get => !ReachedRightBound && !ReachedLeftBound;
    }

    private bool ReachedRightBound { get => referencePointComponent >= rightCameraBound; }
    private bool ReachedLeftBound { get => referencePointComponent <= leftCameraBound; }

    private bool CanShoot { get => bulletSpawnPoint != null && bullet != null; }

    public bool IsEnemy => throw new NotImplementedException();

    #endregion MovementProperties

    public Action OnPlayerDied;
    public Action<int> OnPlayerHit;


    // Start is called before the first frame update
    private void Start()
    {
        leftCameraBound = Camera.main.ViewportToWorldPoint(new Vector3(
            0F, 0F, 0F)).x + PLAYER_RADIUS;

        rightCameraBound = Camera.main.ViewportToWorldPoint(new Vector3(
            1F, 0F, 0F)).x - PLAYER_RADIUS;

        Lives = PLAYER_LIVES;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Lives <= 0)
        {
            this.enabled = false;
            gameObject.SetActive(false);
        }
        else
        {
            hVal = Input.GetAxis("Horizontal");

            if (ShouldMove)
            {
                transform.Translate(transform.right * hVal * moveSpeed * Time.deltaTime);
                referencePointComponent = transform.position.x;
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                && CanShoot)
            {

                GameObject spawnGO = bullet.GetObject();

                if (spawnGO != null)
                {
                    spawnGO.transform.position = bulletSpawnPoint.position;
                    spawnGO.SetActive(true);
                    
                }
            }
        }
    }

    public void TakeDamage(IDamager instigator)
    {
        Lives -= instigator.Damage;
        if (Lives <= 0)
        {
            Lives = 0;
            Die();
        }
    }
    private void Die()
    {
        //LLAMAR EVENTO DE PLAYER DIE
        this.enabled = false;
        gameObject.SetActive(false);
    }
}