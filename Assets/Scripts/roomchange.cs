using Unity.VisualScripting;
using UnityEngine;

public class roomchange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(var x in GameObject.FindGameObjectsWithTag("room 1"))
            {
                x.SetActive(false);
            }
            foreach (var x in GameObject.FindGameObjectsWithTag("room 2"))
            {
                x.GetComponent<Transform>().localPosition = Vector3.zero;
            }
        }
    }
}