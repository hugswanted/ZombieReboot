using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noobdelete : MonoBehaviour
{
     public float timer;
    // Start is called before the first frame update
    void Start()
    {
         timer += 1.0F * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 100)
        {
 GameObject.Destroy(gameObject);
        }

    }
}
