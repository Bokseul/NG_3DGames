using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolIG : MonoBehaviour
{
    public static ObjectPoolIG sInstance;

    [SerializeField]
    private GameObject mPoolingObjectPrefab;

    Queue<Bullet> mPoolingObjectQueue = new Queue<Bullet>();

    private void Awake()
    {
        sInstance = this;

        Initialize(10);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            mPoolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private Bullet CreateNewObject()
    {
        var newObj = Instantiate(mPoolingObjectPrefab).GetComponent<Bullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;

    }

    public static Bullet GetObject()
    {
        if(sInstance.mPoolingObjectQueue.Count > 0)
        {
            var obj = sInstance.mPoolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = sInstance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void sReturnObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(sInstance.transform);
        sInstance.mPoolingObjectQueue.Enqueue(obj);
    }
    
}
