using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Parent : MonoBehaviour {

    public GameObject btnPlayUn;
    public GameObject btnPlayDeux;
    public GameObject btnPlayTrois;
    public GameObject btnPlayQuatre;
    public GameObject btnPlayCinq;

    public int nbrLayer;

    // Use this for initialization
    void Start () {
        nbrLayer = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(btnPlayUn.layer == 8 || btnPlayDeux.layer == 8 || btnPlayTrois.layer == 8 || btnPlayQuatre.layer == 8 || btnPlayCinq.layer == 8)
        {
            nbrLayer = 1;
        }
        else
        {
            nbrLayer = 0;
        }
	}
}
