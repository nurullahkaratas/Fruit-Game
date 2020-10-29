using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuberoll : MonoBehaviour
{
    [SerializeField]
    List<Transform> pivots;
    bool isRolling;
    int pivotSayac = 0;

    bool keyClick = false;
    [SerializeField]
    public List<Transform> tableDots;
    public float rollSpeed = 10;

    Transform gecerliPivot;
    public int currentPart;

    //lerpmove
    public float journeyTime = 1.0f;
    public float speed;


    float startTime;
    Vector3 centerPoint;
    Vector3 startRelCenter;
    Vector3 endRelCenter;

    void Start()
    {
        pivotSayac = 0;
        currentPart = 14;
    }

    void Update()
    {
        //roll
        #region
        if (isRolling)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentPart - 1 > -1 && currentPart != 10 && currentPart != 5)
            {

                currentPart = currentPart - 1;
                if (pivotSayac == 4)
                {
                    pivotSayac = 0;
                }
                isRolling = true;
                StartCoroutine(Roll(pivots[pivotSayac].position, new Vector3(-1, 0, 1)));
                pivotSayac++;
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentPart + 1 < 15 && currentPart != 9 && currentPart != 4)
            {

                currentPart = currentPart + 1;
                pivotSayac--;
                if (pivotSayac == -1)
                {
                    pivotSayac = 3;
                }
                isRolling = true;
                StartCoroutine(Roll(pivots[pivotSayac].position, new Vector3(1, 0, -1)));
            }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////
        ///
        if (Input.GetKeyDown(KeyCode.UpArrow) && !keyClick & currentPart - 5 > -1)
        {
            transform.position = (new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z));
            startTime = Time.time;
            currentPart = currentPart - 5;
            keyClick = true;
            GetCenter(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !keyClick & currentPart + 5 < 15)
        {
            transform.position = (new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z));
            startTime = Time.time;
            currentPart = currentPart + 5;
            keyClick = true;
            GetCenter(Vector3.up);
        }
        if (transform.position != new Vector3(tableDots[currentPart].position.x, transform.position.y, tableDots[currentPart].position.z) && keyClick && !isRolling)
        {

            GetCenter(Vector3.up);
            isRolling = true;

            float fracComplete = (Time.time - startTime) / journeyTime * speed;
            transform.position = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete * speed);
            transform.position += centerPoint;
            isRolling = false;

            if (transform.position == new Vector3(tableDots[currentPart].position.x, transform.position.y, tableDots[currentPart].position.z))
            {
                transform.position = (new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z));
                keyClick = false;
                isRolling = false;
            }

        }

    }
    IEnumerator Roll(Vector3 pivot, Vector3 _vector)
    {
        for (int i = 0; i < 90 / rollSpeed; i++)
        {
            transform.RotateAround(pivot, _vector, rollSpeed);
            yield return new WaitForSeconds(0.001f);
        }
        isRolling = false;
        yield return null;
    }

    public void GetCenter(Vector3 direction)
    {
        centerPoint = (transform.position + new Vector3(tableDots[currentPart].position.x, transform.position.y, tableDots[currentPart].position.z) * .5f);
        centerPoint -= direction;
        startRelCenter = transform.position - centerPoint;
        endRelCenter = new Vector3(tableDots[currentPart].position.x, transform.position.y, tableDots[currentPart].position.z) - centerPoint;
    }

}
