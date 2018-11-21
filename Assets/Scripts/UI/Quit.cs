using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

    private bool quitter = false;
    private Rect popUp = new Rect();
    public GUIContent content = new GUIContent();
    public GUIStyle style = new GUIStyle();

    public GUIStyle styleBoutton = new GUIStyle();

    public int widthPopUp; 
    public int heightPopUp;

    // Use this for initialization
    void Start () {
        widthPopUp = 1000;
        heightPopUp = 400;

        popUp.width = widthPopUp;
        popUp.height = heightPopUp;
        popUp.x = Screen.width/2 - popUp.width / 2;
        popUp.y = Screen.height/2 - popUp.height / 2;

        content.text = "Voulez vous vraiment quitter ?";

        style.alignment = TextAnchor.UpperCenter;
        style.fontSize = 50;
        style.normal.textColor = Color.white;
        style.normal.background = MakeTextureBlack(widthPopUp, heightPopUp, new Color(0.1f, 0.1f, 0.1f, 0.9f));
        style.padding.top = 40;

        styleBoutton.fontSize = 30;
        styleBoutton.normal.textColor = Color.black;
        styleBoutton.normal.background = MakeTextureBlack(widthPopUp, heightPopUp, new Color(0.9f, 0.9f, 0.9f, 1f));
        styleBoutton.alignment = TextAnchor.MiddleCenter;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        quitter = true;
    }
    private void OnGUI()
    {
        if(quitter == true)
        {
            GUI.Window(1, popUp, DoMyWindow, content, style);
        }
    }
    void quitterAppli()
    {
        Debug.Log("quitter");
        Application.Quit();
    }
    void DoMyWindow(int salut)
    {
        if (GUI.Button(new Rect(220, 200, 130, 100), "Oui", styleBoutton))
            quitterAppli();

        if (GUI.Button(new Rect(widthPopUp - 130 - 220, 200, 130, 100), "Non", styleBoutton))
            quitter = false;
    }
    private Texture2D MakeTextureBlack(int width, int height, Color couleur)
    {
        Color[] pix = new Color[width * height]; //créer un tableau de Color, avec une taille égale au nombre de pixel de la texture
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = couleur;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix); //utilise un tableau de couleur pour colorer la texture
        result.Apply(); //applique SetPixels
        return result;
    }
}
