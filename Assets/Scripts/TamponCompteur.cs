using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamponCompteur : MonoBehaviour {

    public bool tampon;
    public bool musiquePlay;
    public float compteur;

    //controlé par d'autre script (Script_Play, Script_Stop)
    // Use this for initialization
    void Start () {
       
        musiquePlay = false; 
        tampon = false;
        compteur = 0.0f;
        
	}
	
	// Update is called once per frame
	void Update () {
        
       
    }
    public void compteurFonction()
    {
        if (compteur < 8f)
        {
            compteur++;
        }
        else
        {
            compteur = 1f;
        }
    }
}
