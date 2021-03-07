using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVida : MonoBehaviour
{
    public GameObject corazon1, corazon2, corazon3;
    public float maxVida = 3f;
    public float actualVida;

    public bool inmortal = false;
    public float tiempoInmortal = 1.0f;

    public GameManager gameManagerSC;

    private void Start()
    {
        corazon1 = GameObject.Find("Vida1");
        corazon2 = GameObject.Find("Vida2");
        corazon3 = GameObject.Find("Vida3");

        actualVida = maxVida; //Limitamos el numero de vidas posibles 

        gameManagerSC = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (actualVida>maxVida) //Si la vida actual es mayor que la vida maxima la rebajamos
        {
            actualVida = maxVida;
        }

        if (actualVida<=0) //Si la vida está a 0 desactiva todos los sprites de corazones y llama al metodo muerte.
        {
            corazon1.SetActive(false);
            corazon2.SetActive(false);
            corazon3.SetActive(false);
            Muerte();
        }

        if (actualVida==1) //Si la vida esta a uno desactiva los sprites de los dos ultimos corazones.
        {
            corazon1.SetActive(true);
            corazon2.SetActive(false);
            corazon3.SetActive(false);
        }
        if (actualVida == 2) //Si la vida esta a 2 desactiva el ultimo sprite de corazon
        {
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon3.SetActive(false);
        }
        if (actualVida == 3) //Si la vida esta al maximo los sprites de corazones estan activos
        {
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon3.SetActive(true);
        }

    }


    public void QuitarVida(float daño) //Recoge el valor daño del enemigo/Trampa y lo usa para restarte una vida
    {
        if (inmortal==true) //Si eres inmortal evita que no puedas recibir daño
        {
            return;
        }
        actualVida -= daño; //Resta el valor daño a la vida actual.

        StartCoroutine(TiempoInmortal()); //Activa corrutina inmortalidad
    }

    public void DarVida(float vida) //Suma la cantidad de vida a la vida actual al recoger el pickup
    {
        actualVida += vida;
    }

    public void Muerte() //Llamamos al metodo game over del game manager
    {
        gameManagerSC.GameOver();
    }

    IEnumerator TiempoInmortal() //Durante el tiempo en el que eres inmortal no puedes recibir daño hasta pasado un segundo
    {
        inmortal = true;
        yield return new WaitForSeconds(tiempoInmortal);
        inmortal = false;
    }

}
