using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class Player_Mov : MonoBehaviour
{
    Rigidbody Player;
    int totalitems = 8;
    private int Punts = 0;
    [SerializeField] int Speed = 10;
    [SerializeField] public TextMeshProUGUI Puntuacio;
    public TextMeshProUGUI GameOver;
    public TextMeshProUGUI Victoria;


    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        float mov_horizontal = Input.GetAxis("Horizontal");
        float mov_vertical = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(mov_horizontal, 0.0f, mov_vertical);
        Player.AddForce(mov * Speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            Punts++;
            Puntuacio.text = Punts.ToString();
            totalitems--;
        }

        if (other.gameObject.tag == "Hazard")
        {
            other.gameObject.SetActive(false);
            Vector3 jump = new Vector3(0.0f, 30, 0.0f);
            Player.AddForce(jump * Speed * Time.deltaTime);
        }

        if (totalitems == 0)
        {

            Victoria.text = "Albert Has guanyat!";
            Victoria.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Escape))
                SceneManager.LoadScene("SampleScene");


        }



       
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Terra"))
        {
            GameOver.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.Escape))
                SceneManager.LoadScene("SampleScene");
        }
    }
}
    
