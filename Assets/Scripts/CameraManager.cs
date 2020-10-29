using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public Transform target,posTar;
    public float degreesPerSec;
    [SerializeField]
    public bool kem;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (kem)
        {
            Vector3 dirFromMeToTarget = -target.position + transform.position;
            //dirFromMeToTarget.y = 0f;
            transform.position = Vector3.Lerp(transform.position, posTar.position, Time.deltaTime*0.5f);
            Quaternion lookRotation = Quaternion.LookRotation(dirFromMeToTarget);

            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * (degreesPerSec / 360f));
        }
    }
}
