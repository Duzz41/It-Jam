using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public int damage = 10; // Düşmanın verdiği zarar miktarı

    private SoldierStats target; // Hareket etmesi gereken hedef
    private bool isAttacking = false; // Saldırı durumu
    public float detectionRadius = 10f; // Düşman algılama yarıçapı
    public LayerMask enemyLayer; // Düşmanın katmanı

    private float lastAttackTime = 0f;
    private List<SoldierStats> nearestSoldiers = new List<SoldierStats>();
    private AudioSource _audioSource;
    public AudioClip _shoot;
    public AudioClip[] _die;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        EvntManager.StartListening("DeathSoud", DieSoundPlay);
    }

    private void FixedUpdate()
    {
        _audioSource.volume = AudioManager.instance.sfxSource.volume;
        if (!isAttacking & target != null)
        {
            StartCoroutine(nameof(Attack));
        }

        // Her 2 saniyede bir en yakın düşman kontrolü

        // Her 2 saniyede bir en yakın düşman kontrolü
        if (Time.time - lastAttackTime >= 2f && target == null)
        {
            Debug.Log("Searching for enemies...");
            SearchForEnemies();
            lastAttackTime = Time.time;
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
                _audioSource.PlayOneShot(_shoot, 0.5f);

                target.TakeDamage(damage);
                Debug.Log("Attacking soldier!");
            }

            // Saldırı tamamlandıktan sonra isAttacking değerini false olarak ayarla
            isAttacking = false;
        }
    }
    private void SearchForEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        nearestSoldiers.Clear();

        foreach (Collider col in colliders)
        {
            nearestSoldiers.Add(col.transform.GetComponent<SoldierStats>());
        }

        if (nearestSoldiers.Count > 0)
        {
            FindNearestSoldier();
        }
    }
    private Transform FindNearestSoldier()
    {


        SoldierStats nearestSoldier = null;
        float minDistance = Mathf.Infinity;

        foreach (SoldierStats soldier in nearestSoldiers)
        {
            float distance = Vector3.Distance(transform.position, soldier.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestSoldier = soldier.GetComponent<SoldierStats>();
                target = nearestSoldier;
            }
        }

        return nearestSoldier?.transform;
    }
    public void DieSoundPlay()
    {
        _audioSource.PlayOneShot(_die[UnityEngine.Random.Range(0, 2)], 0.5f);
    }
}
