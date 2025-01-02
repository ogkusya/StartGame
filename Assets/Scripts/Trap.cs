using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float damageTimer = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthManager healthManager))
        {
            StartCoroutine(DoDamage(healthManager));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<HealthManager>())
        {
            StopAllCoroutines();
        }
    }

    IEnumerator DoDamage(HealthManager healthManager)
    {
        while(true)
        {
            if (healthManager == null)
            {
                yield break;
            }

            healthManager.TakeDamage(damage);
            yield return new WaitForSeconds(damageTimer);
        }
    }
}
