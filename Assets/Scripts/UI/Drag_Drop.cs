using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag_Drop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject ItemDrag;
    public Vector3 Mp;
    public Vector3 startPositionItem;
    public GameObject instrumentPlay;
    public bool dragOk = false;
    public Vector2 sizeBox = new Vector2(1, 1f);
    public LayerMask instrumentLayer;
    public AudioClip sample;
    public Sprite this_sprite;
    public TamponCompteur tampon;
    public GameObject Variable;
    public GameObject BtnPlay;

    public Script_Gui erreur;
    public GameObject GOerreur;
    public void Start()
    {
        tampon = Variable.GetComponent<TamponCompteur>();
        erreur = GOerreur.GetComponent<Script_Gui>();
    }

    public void FixedUpdate()
    {
        dragOk = Physics2D.OverlapBox(transform.position, sizeBox, 0, instrumentLayer); //True lorsque "this" est en colision avec le layer "instrumentLayer"
        
    }
    public void Update()
    {
        Mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Mp.z = 0;
    }

    public void OnBeginDrag(PointerEventData eventData) //au moment du clique 
    {
        ItemDrag = gameObject;
        startPositionItem = transform.position;
    }

    public void OnDrag(PointerEventData eventData) //pendant le drag
    {
        transform.position = Mp; //position de la souris
        //image.color = Color.gray;

    }

    public void OnEndDrag(PointerEventData eventData) //clic relaché
    {
        ItemDrag = null;
        
        if (dragOk) //si il est déposé sur le bon instrument
        {
           // instrumentPlay.GetComponent<AudioSource>().clip = sample; //l'instrument prend le clip correpondant ) "this"
            //instrumentPlay.GetComponent<SpriteRenderer>().sprite = this_sprite; //l'instrument prend le sprite correpondant
            transform.position = startPositionItem; //il retourne à sa palce
            if(BtnPlay.layer == 8 && tampon.compteur != 1)
            {
                tampon.tampon = true;
                BtnPlay.tag = "enTampon";                
                instrumentPlay.GetComponent<AudioSource>().clip = sample; //l'instrument prend le clip correpondant ) "this"
                instrumentPlay.GetComponent<SpriteRenderer>().sprite = this_sprite; //l'instrument prend le sprite correpondant
            }
            else
            {
                instrumentPlay.GetComponent<AudioSource>().clip = sample; //l'instrument prend le clip correpondant ) "this"
                instrumentPlay.GetComponent<SpriteRenderer>().sprite = this_sprite; //l'instrument prend le sprite correpondant
            }
           
        }
        else
        {
            transform.position = startPositionItem; //s'il n'est pas sur l'instrument lui étant dédié, il retourne à sa place
            erreur.erreur("Vous n'avez pas déposé le sample au bon endroit !");
}
    }

}
