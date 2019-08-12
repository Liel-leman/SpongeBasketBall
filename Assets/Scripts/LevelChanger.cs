using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    public string LvlName;

    public void FadeIntoLvl()
    {
        animator.SetTrigger("FadeOut");
    }


    public void OnFadeComplete()
    { 
        Application.LoadLevel(LvlName);
    }
}
