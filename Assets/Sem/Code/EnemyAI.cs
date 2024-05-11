using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool canMove = true; // Düşmanın hareket edip edemeyeceği
    public int damage = 10; // Düşmanın verdiği zarar miktarı

    private Transform target; // Hareket etmesi gereken hedef
    private bool isAttacking = false; // Saldırı durumu

    private void Start()
    {
        target = FindNearestSoldier(); // En yakın askeri bul
    }

    private void Update()
    {
        if (canMove)
        {
            if (!isAttacking)
            {
                StartCoroutine(nameof(Attack));
            }
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        while (isAttacking)
        {
            yield return new WaitForSeconds(2f);

            if (target != null)
            {
                // Askere zarar verme işlemi
                target.GetComponent<SoldierStats>().TakeDamage(damage);
                Debug.Log("Attacking soldier!");
            }
        }
    }

    private Transform FindNearestSoldier()
    {
        SoldierStats[] soldiers = GameObject.FindObjectsOfType<SoldierStats>(); // Tüm askerleri bul

        SoldierStats nearestSoldier = null;
        float minDistance = Mathf.Infinity;

        foreach (SoldierStats soldier in soldiers)
        {
            float distance = Vector3.Distance(transform.position, soldier.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestSoldier = soldier;
            }
        }

        return nearestSoldier?.transform;
    }
}
