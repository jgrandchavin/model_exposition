using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2 : Car
{
    // Private properties

    private GameObject Car1;

    // Lifecycle methods

    void Start()
    {
        Car1 = GameObject.Find("Car1");
        basePosition = transform.position;
        Setup();
    }

    // Public methods

    public override void Focus()
    {
        Car1.SetActive(false);
        ShouldFocus(true);
    }

    public override void UnFocus()
    {
        Car1.SetActive(true);
        ShouldFocus(false);
    }

}
