using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouttonMenu : MonoBehaviour {

    public bool rotationFleche = false;
    public bool rotationFlecheBack = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rotationFleche)
        {
            rotation();
        }
        if (rotationFlecheBack)
        {
            rotationBack();
        }
	}
    void rotation()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        rotationFleche = false;
    }
    void rotationBack()
    {
        transform.eulerAngles = new Vector3(0, 0, 180);
        rotationFlecheBack = false;
    }
}
