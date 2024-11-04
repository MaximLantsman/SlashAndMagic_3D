using System.Collections;
using System.Collections.Generic;
using Damagable;
using UnityEngine;

public class WeaponHitboxHandler : MonoBehaviour
{
    private int enemyLayer;
    private int curremtDamage;

    private Collider weaponHitbox;
    private List<GameObject> hittedEnemies = new List<GameObject>();

    private void Awake()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        weaponHitbox = GetComponent<Collider>();
    } 
    
    public void PreformHitboxAttack(float attackDuration,int attackDamage)
    {
        weaponHitbox.enabled = true;
        hittedEnemies.Clear();
        curremtDamage = attackDamage;
        StartCoroutine(StopHitboxAttack(attackDuration));
    }

    private IEnumerator StopHitboxAttack(float duration)
    {
        yield return new WaitForSeconds(duration);
        weaponHitbox.enabled = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamagable>() != null && !hittedEnemies.Contains(other.gameObject))
        {
            hittedEnemies.Add(other.gameObject);
            other.GetComponent<IDamagable>().Damage(curremtDamage);
        }
    }
}