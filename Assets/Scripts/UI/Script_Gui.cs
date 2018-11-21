using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Gui : MonoBehaviour {
    public bool error = false;
    float screenWidth = Screen.width;
    float screenHeight = Screen.height;
    float xRect;
    float yRect;
 
    GUIStyle style = new GUIStyle();
    GUIContent content = new GUIContent();


    // Use this for initialization
    void Start () {
        

        xRect = screenWidth * 0.6f;
        yRect = screenHeight * 0.2f;

        style.normal.textColor = Color.white;
        style.fontSize = 25;
        style.alignment = TextAnchor.MiddleCenter;

    
    }
    private void OnGUI()
    {
        if (error) { 
            GUI.Box(new Rect((screenWidth / 2) - (xRect / 2), (screenHeight - yRect) - 50, xRect, yRect), content, style);
            InvokeRepeating("disparition", 3f, 0f);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void erreur(string contenu)
    {
        content.text = contenu;
        error = true;
    }
    public void disparition()
    {
        error = false;
        CancelInvoke();
    }
}
