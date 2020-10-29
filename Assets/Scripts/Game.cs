using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    GameObject chocolatte;
    GameObject fork;
    [SerializeField]
    float speedTurn;
    bool finish;
    public bool turn=false;
    
    float konum;
    bool beingHandled;
    void Start()
    {
      
        speedTurn = 10;
        chocolatte = GameObject.Find("finish-chocolate");
        fork = GameObject.Find("merkez");
        konum = fork.transform.position.y + 0.5f;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (chocolatte.transform.GetChild(0).transform.GetChild(0).gameObject.activeSelf == true
         && chocolatte.transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf == true
         && chocolatte.transform.GetChild(2).transform.GetChild(0).gameObject.activeSelf == true
         && chocolatte.transform.GetChild(3).transform.GetChild(0).gameObject.activeSelf == true
           ) finish = true;
      

        if (finish)
        {

           fork.transform.position = Vector3.Lerp(fork.transform.position, new Vector3(fork.transform.position.x,konum , fork.transform.position.z), Time.deltaTime * 10f);

            if (beingHandled)
            {
                turn = true;
                StartCoroutine(Sec2());
                
               
            }
            else { objectRotation(fork.transform, 0.04f); StartCoroutine(Sec()); }

        }
        if (turn)
        {
            
            fork.transform.position = Vector3.Lerp(fork.transform.position, transform.position, Time.deltaTime);
        }
    }

    void objectRotation(Transform subject, float speedOfRotation)
    {
        for (int i = 0; i < 85; i++)
        {
            subject.Rotate(Vector3.left, Time.deltaTime * speedTurn);

        }

    }

    IEnumerator Sec()
    {
        beingHandled = false;
       
        
        yield return new WaitForSeconds(0.5f);

        beingHandled = true;
    }
    IEnumerator Sec2()
    {
        yield return new WaitForSeconds(1.0f);
        
        GetComponentInChildren<CameraManager>().kem = true;

        yield return new WaitForSeconds(1.0f);
        GetComponentInChildren<Chocolate>().don = true;


    }

}
