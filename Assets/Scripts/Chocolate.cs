using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocolate : MonoBehaviour
{//anim
    public bool don;
   
    float yy;
    // Start is called before the first frame update
    void Start()
    {
        yy = transform.position.y + 0.15f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {    
        if (don)
        {

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(transform.position.x, yy, transform.position.z), Time.deltaTime * 0.5f);
            StartCoroutine(objectRotation(gameObject.transform));
            GetComponentInParent<Game>().transform.GetChild(4).gameObject.SetActive(true);
           
        }
    }


    IEnumerator objectRotation(Transform subject)
    {
        subject.Rotate(Vector3.up, Time.deltaTime * 100);
        yield return new WaitForSeconds(0.001f);

    }
 
}
