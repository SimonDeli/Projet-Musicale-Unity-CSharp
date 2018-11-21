using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGauche : MonoBehaviour {

    public float positionXDebut;
    public float positionUpdate;
    public float positionXFin;
    public bool autorisation = false;
    public bool autorisationBack = false;
    public bool menuDeroule = false;
    public GameObject boutton_Enfant;
    public bouttonMenu bouttonMenu;
    private float ease = 1;
    private float expon = 0.4f;

    private float vitesse = 1f;

	// Use this for initialization
	void Start () {
        bouttonMenu = boutton_Enfant.GetComponent<bouttonMenu>();
        positionXDebut = transform.position.x;
        positionXFin = positionXDebut + 4.5f;
    }
	
	// Update is called once per frame
	void Update () {
        positionUpdate = transform.position.x;
        if (autorisation == true && menuDeroule == false)
        {
            ease += expon;
            bouttonMenu.rotationFleche = true;
            transform.Translate(Vector2.right * vitesse * ease * Time.deltaTime, Space.World);
            if(positionUpdate >= positionXFin)
            {
                autorisation = false;
                menuDeroule = true;
                ease = 1;
            }
        }
        if (autorisationBack == true && menuDeroule == true)
        {
            ease += expon;
            bouttonMenu.rotationFlecheBack = true;
            transform.Translate(Vector2.left * vitesse * ease * Time.deltaTime, Space.World);
            if(positionUpdate <= positionXDebut+0.1f)
            {
                autorisationBack = false;
                menuDeroule = false;
                ease = 1;
            }
        }
	}
    public void Deplacement ()
    {
        if(menuDeroule == false) {
            autorisation = true;
            autorisationBack = false;
        }
        else
        {
            autorisationBack = true;
            autorisation = false;
        }
       
        
        
    }
}
