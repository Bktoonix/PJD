using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //Velocidade que pode ser mudada
    private float speed = 5f;
    //Tamanho maximo de x
    private float xMax = 8.1f;
    //Tamanho maximo de y
    private float yMax = 4.13f;
    public GameObject laserPrefab;
    public bool Powerup3 = false;
    void Start()
    {

    }

    void Update() {
        {
            moviment();
            tiro();
        }
    }

    private void tiro()
    {
        if (Powerup3 == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f), Quaternion.identity);
            }
        } else if (Powerup3 == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f), Quaternion.identity);
                Instantiate(laserPrefab, transform.position + new Vector3(-1, -0.8f), Quaternion.identity);
                Instantiate(laserPrefab, transform.position + new Vector3(1, -0.8f), Quaternion.identity);
            }
        }


    }
    public void moviment()
    {    //Movimentaçao Horizontal
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        //Movimentaçao Vertical
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);

        //Faz o Player Aparece do Outro Lado da Tela na Horizontal e na Vertical
        if (transform.position.x >= xMax)
        {
            transform.position = new Vector3(-xMax, transform.position.y);
        }
        else if (transform.position.x <= -xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y);
        }
        else if (transform.position.y >= yMax)
        {
            transform.position = new Vector3(transform.position.x, -yMax);
        }
        else if (transform.position.y <= -yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax);
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {   //Faz o powerup sumir 
        if (collision.tag == "Powerup3")
        {
            Powerup3 = true;
            Destroy(collision.gameObject);
            StartCoroutine(temporizador());
        }
        if (collision.tag == "Asteroid")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }

    IEnumerator temporizador ()
    {
        yield return new WaitForSeconds(5f);
        Powerup3 = false;
    }
}