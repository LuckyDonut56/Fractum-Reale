using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
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
    IEnumerator OnTriggerEnter()
    {
        GameObject.FindGameObjectWithTag("doorroom1").GetComponent<Door>().speed = 360;
        GameObject.FindGameObjectWithTag("doorroom1").GetComponent<Door>().isOpen = false;
        yield return new WaitForSeconds(0.1f);
        foreach (var x in GameObject.FindGameObjectsWithTag("room 1"))
        {
            x.SetActive(false);
        }
        GameObject.FindGameObjectWithTag("doorroom1").SetActive(false);
        foreach (var x in GameObject.FindGameObjectsWithTag("room 2"))
        {
            x.GetComponent<Transform>().localPosition = Vector3.zero;
        }
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("OnTriggerEnter");
        }
    }
}