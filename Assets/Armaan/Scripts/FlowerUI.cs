using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI space;
    [SerializeField] TextMeshProUGUI retrive;
    bool setRetrive = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setRetrive = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            setRetrive = false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        space.gameObject.SetActive(true);
        if (setRetrive == true)
        {
            retrive.gameObject.SetActive(true);
            space.gameObject.SetActive(false);
        }
       
        
    }
    private void OnTriggerExit(Collider other)
    {
        space.gameObject.SetActive(false);
        retrive.gameObject.SetActive(false);
        
    }
    public void retrivefalse()
    {
        setRetrive = false;
    }
}
