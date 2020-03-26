using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car1 : Car
{
    // Private properties

    private GameObject Car2;

    // Lifecycle methods

    void Start()
    {
        Car2 = GameObject.Find("Car2");
        basePosition = transform.position;
        Setup();
    }

    // Public methods

    public override void Focus()
    {
        Car2.SetActive(false);
        ShouldFocus(true);
    }

    public override void UnFocus()
    {
        Car2.SetActive(true);
        ShouldFocus(false);
    }
}
