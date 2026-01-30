using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range = 15f;
    public float fireRate = 1f;
    public float turnSpeed = 10f;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private Transform target;
    private float fireCountdown = 0f;
    private string enemyTag = "Enemy";
    public int damage = 2;
    public int upgradeCost = 60;
    public float fireRateBooster = 0.5f;
    public bool isUpgraded = false;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    public void UpgradeTurret()
    {
        if (isUpgraded) return;
        damage += 2;
        fireRate += fireRateBooster;
        isUpgraded = true;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.damage = this.damage;
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
