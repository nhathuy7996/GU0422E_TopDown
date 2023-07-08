using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private static ObjectPooling _instant;
    public static ObjectPooling Instant => _instant;

    //pooling
    Dictionary<GameObject, List<GameObject>> _pool = new Dictionary<GameObject, List<GameObject>>();



    private void Awake()
    {
        _instant = this;
    }

    public virtual GameObject GetObj(GameObject prefab)
    {
        List<GameObject> listObj = new List<GameObject>();
        if (_pool.ContainsKey(prefab))
            listObj = _pool[prefab];
        else {
            _pool.Add(prefab, listObj);
        }

        foreach (GameObject g in listObj) {
            if (g.activeSelf)
                continue;
            return g;
        }

        GameObject g2 = Instantiate(prefab, this.transform.position, Quaternion.identity);
        listObj.Add(g2);

        return g2;
    }

    public virtual T Getcomp<T>(T prefab) where T: MonoBehaviour {

        return this.GetObj(prefab.gameObject).GetComponent<T>();
    }
}
