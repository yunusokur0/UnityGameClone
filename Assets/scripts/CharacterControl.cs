using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CharacterControl : MonoBehaviour
{
   

    private Rigidbody rb;
    
    private Touch touch;
    private bool speedcontrol = false;
    private bool firsttouccontrol = false;
    public float forwartspeed;
    public float speedModifier;
    public static int firsttouch = 0;
    public GameObject cam;
    private bool gameover;
    private int toopsayisi = 21;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void Update()
    {

        if (firsttouch == 1 && speedcontrol == false && !gameover)
        {
            transform.position += new Vector3(0, 0, forwartspeed * Time.deltaTime);
            cam.transform.position += new Vector3(0, 0, forwartspeed * Time.deltaTime);

        }


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)   
            {

                if (firsttouccontrol == false)
                {

                    firsttouch = 1;  

                    firsttouccontrol = true;
                }


            }


            else if (touch.phase == TouchPhase.Moved)    
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                                 transform.position.y,
                                                 transform.position.z); 


                if (firsttouccontrol == false)
                {

                    firsttouch = 1;  

                    firsttouccontrol = true;
                }

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("dusman"))
        {
            sayiAzalt(other.gameObject);

        }
        if (other.gameObject.CompareTag("dost"))
        {

            sayiArtir(other.gameObject);
        }
    }

   

    private void sayiAzalt(GameObject gameObject)
    {
        TextMeshPro dusmanintexti = gameObject.transform.GetChild(0).GetComponent<TextMeshPro>();
        int dusmaninsayisi = System.Convert.ToInt32(dusmanintexti.text);

        TextMeshPro toopsayisitext = transform.GetChild(0).GetComponent<TextMeshPro>();
        int toopsayisi = System.Convert.ToInt32(toopsayisitext.text);

        
        if (toopsayisi > 0)
        {
            toopsayisi--;
            toopsayisitext.text = toopsayisi.ToString();
           
            dusmaninsayisi++;
            dusmanintexti.text = dusmaninsayisi.ToString();
           
        }
        if (toopsayisi == 0)
        {
            gameover = true;
        }

        if (dusmaninsayisi == 0)
        {
            Destroy(gameObject);
        }


    }

    private void sayiArtir(GameObject gameObject) 
    {
        TextMeshPro dosttexti = gameObject.transform.GetChild(0).GetComponent<TextMeshPro>();
        int dostsayisi = System.Convert.ToInt32(dosttexti.text);

        TextMeshPro toopsayisitext = transform.GetChild(0).GetComponent<TextMeshPro>();
        int toopsayisi = System.Convert.ToInt32(toopsayisitext.text);


        toopsayisi++;
        toopsayisitext.text = toopsayisi.ToString();
        dostsayisi--;
        dosttexti.text = dostsayisi.ToString();


        if (dostsayisi == 0)
        {
            Destroy(gameObject);
        }

    }
}
