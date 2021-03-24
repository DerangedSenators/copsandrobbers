using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControls : MonoBehaviour
{
    [SerializeField]
    private Canvas menuCanvas;
    private bool viewMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (viewMenu)
        {
            menuCanvas.gameObject.SetActive(true);
        }
        else
        {
            menuCanvas.gameObject.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && !viewMenu)
        {
            viewMenu = true;
            return;
        }
        

        if (Input.GetKeyDown(KeyCode.Escape) && viewMenu)
        {
            viewMenu = false;
            return;
        }
        
    }
    
    
    
    
    
}
