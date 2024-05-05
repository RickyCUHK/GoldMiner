using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool isCaptured = false;
    private GameObject hook;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCaptured = true;
        hook = GameObject.Find("HookParent");
        hook.GetComponent<HookMovement>().moveup();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCaptured)
        {
            transform.position = GameObject.Find("ItemHolder").transform.position;
        }
    }

    public void get()
    {
        Debug.Log("geto!");
        isCaptured = false;
        this.gameObject.SetActive(false);
    }
}
