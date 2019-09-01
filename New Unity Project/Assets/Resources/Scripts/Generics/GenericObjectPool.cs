using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private bool willGrow;
    [SerializeField] private int initialSize = 3;
    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < initialSize; i++)
        {
            objectPool.Add(CreateObj());
        }
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = CreateObj();
            objectPool.Add(obj);
            return obj;
        }

        return null;
    }

    private GameObject CreateObj()
    {
        GameObject obj = Instantiate(objectToPool);
        obj.SetActive(false);
        return obj;
    }

}
