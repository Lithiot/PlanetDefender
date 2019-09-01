using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float damage = 1;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position,
                     GameManager.instance.player.transform.position,
                     speed * Time.deltaTime);
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().GetDamaged(damage);
            gameObject.SetActive(false);
        }
    }
}
