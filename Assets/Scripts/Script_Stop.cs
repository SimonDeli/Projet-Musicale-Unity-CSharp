using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Stop : MonoBehaviour {

    public GameObject Play;
    public SpriteRenderer couleurInstru;
    public GameObject btnPlay;
    public AudioSource musique;
    public Script_Play script_play;

    public Play_Parent classe;
    public GameObject Parent_BtnPlay;

    public GameObject variable;
    public TamponCompteur tampon;

    public Sprite PlayInactif;

    // Use this for initialization
    void Start () {

      
        tampon = variable.GetComponent<TamponCompteur>();
        classe = Parent_BtnPlay.GetComponent<Play_Parent>();
        musique = Play.GetComponent<AudioSource>();
        script_play = btnPlay.GetComponent<Script_Play>();
        couleurInstru = Play.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        musique.Stop();
        btnPlay.layer = 0;
        btnPlay.tag = "Untagged";
        script_play.couleur.sprite = PlayInactif;
        couleurInstru.color = Color.grey;
    }
    private void OnMouseUp()
    {
        if (classe.nbrLayer == 0 && tampon.musiquePlay == true)
        {
            tampon.compteur = 0.0f;
            tampon.musiquePlay = false;
            tampon.CancelInvoke("compteurFonction");
            
        }
    }

}
