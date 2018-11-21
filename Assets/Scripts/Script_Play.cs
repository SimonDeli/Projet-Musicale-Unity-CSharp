using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Script_Play : MonoBehaviour {

    public GameObject Variables;
    public TamponCompteur tampon;
    public AudioSource musique;
    public SpriteRenderer couleur;
    public GameObject instruments;
    public SpriteRenderer spriteInstru;

    public Sprite CarreVide;
    public Sprite CarrePlein;
    public Sprite PlayActif;
    public Sprite PlayInactif;

    public Script_Gui erreur;
    public GameObject GOerreur;

    public int BPM;
    private float timeBPM;

    public int indexScene;
    public Scene currentScene;


    // Use this for initialization
    void Start()
    {
        erreur = GOerreur.GetComponent<Script_Gui>();
        currentScene = SceneManager.GetActiveScene();
        indexScene = currentScene.buildIndex;
        if (indexScene == 0)
        {
            BPM = 170;
        }
        if (indexScene == 1)
        {
           BPM = 170;
        }
        if (indexScene == 2)
        {
           BPM = 120;
        }
        if (indexScene == 3)
        {
            BPM = 135;
        }
        musique = instruments.GetComponent<AudioSource>();
        couleur = GetComponent<SpriteRenderer>();
        tampon = Variables.GetComponent<TamponCompteur>(); //Pour gerer le compteur, le tampon, et musiquePlay
        spriteInstru = instruments.GetComponent<SpriteRenderer>();
   
        timeBPM = 60.0f / BPM;
        spriteInstru.color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        if (tampon.musiquePlay == true) 
        {
            if (tampon.tampon == true)
            {
                if (tampon.compteur == 1.0f && tampon.tampon == true && gameObject.tag == "enTampon") 
                {
                    gameObject.tag = "Untagged";
                    musique.Play();
                    InvokeRepeating("frame2", 0.1f, 0f); //Meme explication que la ligne 80. (tampon.tampon = false)
                    couleur.sprite = PlayActif;
                    couleur.color = Color.white;
                    spriteInstru.color = Color.white;
                }
            }
        }

        if (gameObject.tag == "enTampon")
        {
            couleur.color = Color.gray;
        }
        else
        {
            couleur.color = Color.white;
        }

        if(musique.clip == null)
        {
            spriteInstru.sprite = CarreVide;
        }

    }
    void OnMouseDown()
    {
        if (tampon.musiquePlay == false && musique.clip != null) //Si il n'y a pas de musique, on lance la musique et le compteur
        {
            musique.Play();
            tampon.InvokeRepeating("compteurFonction", 0f, timeBPM); //compteur lancé
            InvokeRepeating("frame", 0.1f, 0f); //InvokeRepeating car je veux que tampon.musiquePlay passe à true APRES l'execution de toute la fonction OnMouseDown(), afin que ca ne dérange pas le reste de la fonction (ligne 90 par exemple)
            gameObject.layer = 8;
            couleur.sprite = PlayActif;
            spriteInstru.color = Color.white;
        }
        else
        {
            //couleur.sprite = PlayInactif;
        }

        if (tampon.musiquePlay == true && tampon.compteur != 1 && musique.clip != null) //si un instrument est déjà en train de jouer, et s'il y a un clip sur l'instrument (compteur !=1 car la "gate" qui envoie les clips en tampons s'ouvre pendant toute la durée du "compteur = 1", donc ca peut créer des décalges si un instrument est lancé sur play à la fin du 1, et non au début comme prévu)
        {
            tampon.tampon = true;
            gameObject.tag = "enTampon";
            gameObject.layer = 8; //onPlay
            
        }
        if(tampon.compteur == 1)
        {
            erreur.erreur("Vous ne pouvez pas lancer un sample lorsque le temps est égal à 1");
        }
        if(musique.clip == null)
        {
            erreur.erreur("Veuillez inserer un sample à l'emplacement prévue à cet effet. (Ils sont en haut à gauche ;) )");
        }
    
    }
   /* public void compteur()
    {
        if (tampon.compteur < 8f)
        {
            tampon.compteur ++;
        }
        else
        {
            tampon.compteur = 1f;
        }
    }*/

    void frame () //explication ligne 80
    {
        tampon.musiquePlay = true;
    }
    void frame2()
    {
        tampon.tampon = false;
    }   
}
