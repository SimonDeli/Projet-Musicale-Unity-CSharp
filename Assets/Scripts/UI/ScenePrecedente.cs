using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePrecedente : MonoBehaviour {
    public bool scenePrec;
    public GameObject sceneSuiv;
    public SceneSuivante classe;

    public ChgmtScn variables;
    public GameObject GOvariables;

    

    // Use this for initialization
    void Start () {

        classe = sceneSuiv.GetComponent<SceneSuivante>();
        variables = GOvariables.GetComponent<ChgmtScn>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseDown()
    {
        scenePrec = true;
        classe.sceneSuiv = false;
        variables.ChgmtScene();
    }
}
