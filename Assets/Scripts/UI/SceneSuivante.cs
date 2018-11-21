using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSuivante : MonoBehaviour {
    public bool sceneSuiv;
    public GameObject scenePrec;
    public ScenePrecedente classe;

    public ChgmtScn variables;
    public GameObject GOvariables;


    // Use this for initialization
    void Start () {

        
        classe = scenePrec.GetComponent<ScenePrecedente>();
        variables = GOvariables.GetComponent<ChgmtScn>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseDown()
    {

        classe.scenePrec = false;
        sceneSuiv = true;
        variables.ChgmtScene();
    }
}
