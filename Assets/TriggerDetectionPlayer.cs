using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetectionPlayer : MonoBehaviour
{
    private List<Vector3> listPObj = new List<Vector3>();
    [Serializable]
    public class KeyValuePair
    {
        public GameObject partOfModel;
        public Vector3 val;
    }

    public List<KeyValuePair> List = new List<KeyValuePair>();
    Dictionary<GameObject, Vector3> myDict = new Dictionary<GameObject, Vector3>();

    void Awake()
    {
        foreach (var kvp in List)
        {
            myDict[kvp.partOfModel] = kvp.val;
        }
        foreach (KeyValuePair<GameObject, Vector3> kvp in myDict)
        {

            listPObj.Add(kvp.Key.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (KeyValuePair<GameObject, Vector3> kvp in myDict)
            {

                kvp.Key.transform.localPosition = new Vector3(kvp.Value.x, kvp.Value.y, kvp.Value.z);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int i = 0;
            foreach (KeyValuePair<GameObject, Vector3> kvp in myDict)
            {
                kvp.Key.transform.position = new Vector3(listPObj[i].x, listPObj[i].y, listPObj[i].z);
                i++;
            }
        }
    }
}
