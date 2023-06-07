using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{

    public GameObject Engel;
    public Transform Transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
        {   
            if(other.gameObject.CompareTag("Player"))
            {
                Engel.transform.position = new Vector3(Transform.position.x, Transform.position.y, Transform.position.z);
            }
        }
}
