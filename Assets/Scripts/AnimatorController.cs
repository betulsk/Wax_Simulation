using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    #region SINGLETON PATTERN
    public static AnimatorController _instance;
    public static AnimatorController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AnimatorController>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Singleton");
                    _instance = container.AddComponent<AnimatorController>();
                }
            }

            return _instance;
        }
    }
    #endregion

    Animator animator;
    [SerializeField] private GameObject objectWax;
    SkinnedMeshRenderer skinnedMeshRenderer;


    

    private void Start()
    {
       animator = objectWax.GetComponent<Animator>();
        _instance = AnimatorController.Instance;
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

    }

    internal IEnumerator IsPlayN() 
    {
        IsPlay();
        yield return new WaitForSecondsRealtime(5f);
        IsStop();
    }
    internal void IsPlay() 
    {
        animator.SetBool("Waxed",true);
    }

    internal void IsStop()
    {
        animator.SetBool("Waxed",false);
    }

    internal void Cleaning()
    {
        animator.Play("Cleaning.CleanerAnim");
    }
}
