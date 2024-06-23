using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface gunInterface
{
    void shootGun(GameObject bulletPrefab, Rigidbody2D playerRb, Transform aiming);
}

public abstract class BaseGun : ScriptableObject, gunInterface
{
    public abstract void shootGun(GameObject bulletPrefab, Rigidbody2D playerRb, Transform aiming);

    public string itemName;
    public Sprite icon;
    public int damage;
    public int ammo;
    public float fireRate;
    public string ammoType;
}

[CreateAssetMenu(fileName = "New Gun Item", menuName = "Inventory/Gun Item")]
public class GunItem : BaseGun
{
    public override void shootGun(GameObject bulletPrefab, Rigidbody2D playerRb, Transform aiming)
    {
        GameObject newBullet = Instantiate(bulletPrefab, playerRb.transform.position, aiming.rotation);

        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(aiming.transform.up * 20f, ForceMode2D.Impulse);
    }
}
