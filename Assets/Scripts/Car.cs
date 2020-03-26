using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{

    // Public properties

    public Vector3 basePosition;
    public Vector3 focusPosition;

    // Private properties

    private bool focus = false;
    private float rotationSpeed = 0.2f;
    private List<string> materialNames;

    private GameObject returnButton;

    // Lifecycle methods

    void Start() 
    {
    }

    void Update()
    {
        CarRotation();
    }

    void OnMouseDown()
    {
        if (!focus)
        {
            Focus();
                
        } else {
            ApplyTexture();
        }
    }

    void OnMouseDrag()
	{
        if (focus) {
            float XaxisRotation = Input.GetAxis("Mouse X")*rotationSpeed;
		    float YaxisRotation = Input.GetAxis("Mouse Y")*rotationSpeed;
		    // select the axis by which you want to rotate the GameObject
		    transform.RotateAround(Vector3.down, XaxisRotation);
		    transform.RotateAround(Vector3.right, YaxisRotation);
        }
		
	}

     // Public methods

    public void Setup() {
        returnButton = GameObject.Find("Button");
        returnButton.GetComponent<Button>().onClick.AddListener(delegate() { UnFocus(); });
        materialNames = new List<string>()
        {
            "Body_2",
            "body_3",
            "body_4",
            "body_5",
            "body_6",
            "body_7",
            "body_11",
            "lambert3",
            "matte_4",
            "matte_5",
            "matte_6",
            "matte_7",
            "matte_8"
        };
    }

    public void ShouldFocus(bool state)
    {
        if (state)
         {
            focus = true;
        } else 
        {
            focus = false;
            ResetIdentityPosition();
        }
    }

    public virtual void Focus() {}
    public virtual void UnFocus() {}

    // Private methods

    private void ResetIdentityPosition() {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void CarRotation()
    {
        if (!focus)
        {
            transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.World);
        }

        transform.position = Vector3.MoveTowards(transform.position, !focus ? basePosition: focusPosition, 10 * Time.deltaTime);
    }

    private void ApplyTexture() {
        var random = new System.Random();
        string materialName = materialNames[random.Next(materialNames.Count)];
        Material newMat = Resources.Load(materialName, typeof(Material)) as Material;
        GetComponentInChildren<Renderer>().material = newMat;
    }
}
