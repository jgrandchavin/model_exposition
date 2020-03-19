using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2 : MonoBehaviour
{

    GameObject Car1;
    bool focus = false;
    Vector3 basePosition;
    Vector3 focusPosition;



    // Start is called before the first frame update
    void Start()
    {
        Car1 = GameObject.Find("Car1");
        basePosition = transform.position;
        focusPosition = new Vector3(2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CarRotation();
    }


    void OnMouseDown()
    {
        if (!focus)
        {
            FocusCar();
        }
        else
        {
            UnfocusCar();
        }
    }

    private void FocusCar()
    {
        Car1.SetActive(false);
        focus = true;
    }

    private void UnfocusCar()
    {
        Car1.SetActive(true);
        focus = false;
    }

    private void CarRotation()
    {
        if (!focus)
        {
            transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.World);
            transform.position = Vector3.MoveTowards(transform.position, basePosition, 10 * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, focusPosition, 10 * Time.deltaTime);
        }


    }
}
