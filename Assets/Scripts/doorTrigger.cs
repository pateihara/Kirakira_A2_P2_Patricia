using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{

    public GameObject Porta;
    public void Start()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Porta.GetComponent<Animator>().SetTrigger("open");
            Destroy(this.gameObject);

        }
    }
}
