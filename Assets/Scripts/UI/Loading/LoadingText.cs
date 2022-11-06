using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingText : MonoBehaviour
{
    private TextMeshProUGUI loadingtxt;
    private bool ischecked = false;

    private void Start()
    {
        loadingtxt = gameObject.GetComponent<TextMeshProUGUI>();
       
    }
    // Start is called before the first frame update
    void Update()
    {
        if(ischecked == false)
            StartCoroutine(LoadingTxt());
    }

    IEnumerator LoadingTxt()
    {
        ischecked = !ischecked;
        loadingtxt.text = "LOADING";
        yield return new WaitForSeconds(0.5f);
        loadingtxt.text = "LOADING.";
        yield return new WaitForSeconds(0.5f);
        loadingtxt.text = "LOADING..";
        yield return new WaitForSeconds(0.5f);
        loadingtxt.text = "LOADING...";
        yield return new WaitForSeconds(0.5f);
        ischecked = !ischecked;
    }


}
