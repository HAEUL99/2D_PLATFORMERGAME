using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomThemeImg : MonoBehaviour
{
    [SerializeField]
    private ChooseTheme chooseTheme;
    [SerializeField]
    private Sprite[] change_img = new Sprite[4];
    private Image startImg;

    
    

    // Start is called before the first frame update
    void Start()
    {
        startImg = gameObject.GetComponent<Image>();

        startImg.sprite = change_img[chooseTheme._numTheme];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
