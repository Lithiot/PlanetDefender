using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    private Vector3 originalSize;
    [SerializeField] private Vector3 growRate;

    public SpriteRenderer sprite;

    private void Awake()
    {
        originalSize = transform.localScale;
    }

    public void Charge()
    {
        transform.localScale += growRate * Time.deltaTime;
    }

    public void Attack()
    {
        Collider2D[] meh = Physics2D.OverlapCircleAll(transform.position, sprite.bounds.extents.x);

        for (int i = 0; i < meh.Length; i++)
        {
            if (meh[i].CompareTag("Enemy"))
                meh[i].gameObject.GetComponent<EnemyBehaviour>().Kill();
        }

        transform.localScale = originalSize;
    }

    public void DisableShield()
    {
        transform.localScale = originalSize;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, sprite.bounds.extents.x);
    }
}
