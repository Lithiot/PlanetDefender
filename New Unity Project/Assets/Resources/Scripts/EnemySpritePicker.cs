using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpritePicker : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
    }
}
