using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChgmtScn : MonoBehaviour {

    //public string sceneName;
    public int nbrScenes;
    public Scene SceneCourante;
    public int indexSceneCourante;

    public GameObject flecheDroite;
    public SceneSuivante classeSuiv;

    public GameObject flecheGauche;
    public ScenePrecedente classePrec;

    // Use this for initialization
    void Start () {
        nbrScenes = SceneManager.sceneCountInBuildSettings;
        SceneCourante = SceneManager.GetActiveScene();
        indexSceneCourante = SceneCourante.buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChgmtScene()
    {
        classeSuiv = flecheDroite.GetComponent<SceneSuivante>();
        classePrec = flecheGauche.GetComponent<ScenePrecedente>();
        if (classeSuiv.sceneSuiv == true && classePrec.scenePrec == false)
        {
            if(indexSceneCourante == 3)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(indexSceneCourante + 1);
            }
            
        }
        if (classeSuiv.sceneSuiv == false && classePrec.scenePrec == true)
        {
            if(indexSceneCourante == 0)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                SceneManager.LoadScene(indexSceneCourante - 1);
            }
          
        }
        
    }
}
