using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile
/// </summary>

public class WeaponScript : MonoBehaviour {

	//--------------------------------
	// 1 - Designer variables
	//--------------------------------
	
	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform shotPrefab;
	
	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float durationBetweenShots = 1f;
	
	//--------------------------------
	// 2 - Cooldown
	//--------------------------------
	
	private float shootTimer;


    private Collider2D collider;
	
	void Start()
	{
		shootTimer = 0f;
        collider = GetComponent<Collider2D>();

	}
	
	void Update()
	{
		if (shootTimer > 0)
		{
			shootTimer -= Time.deltaTime;
		}
	}
	
	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------
	
	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootTimer = durationBetweenShots;

            // Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            if (!collider)
                return;
            Vector3 spawnPos = transform.position + new Vector3(-collider.bounds.extents.x, 0, 0);
            shotTransform.position = spawnPos;
			
			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// Make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null)
			{
				move.direction = this.transform.right; // towards in 2D space is the right of the sprite
				if (shot.isEnemyShot) {
					move.direction = this.transform.right * -1; // towards in 2D space is the right of the sprite
				}
			}
		}
	}
	
	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootTimer <= 0f;
		}
	}
}
