using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    public static PoolScript instance;
    public List<GameObject> pool = new List<GameObject>();
    public List<PoolObject> poolItems = new List<PoolObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        return;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        AddToPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddToPool()
    {
        foreach (PoolObject item in poolItems)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject tempprefab = Instantiate(item.prefab);
                tempprefab.SetActive(false); //Making the gameobject to false, before adding into Pool.
                pool.Add(tempprefab);

            }
        }
    }
   public GameObject GetObjectsFromPool(string tagName)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if(pool[i].gameObject.tag == tagName)
            {
                return pool[i];

            }
        }
        return null;

    }

}

[System.Serializable]
public class PoolObject
{
    public GameObject prefab;
    public string name;
    public int amount;

   
}
