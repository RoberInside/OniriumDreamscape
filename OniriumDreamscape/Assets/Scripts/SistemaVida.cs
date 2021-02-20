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

        actualVida = maxVida;

        gameManagerSC = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (actualVida>maxVida)
        {
            actualVida = maxVida;
        }

        if (actualVida<=0)
        {
            Muerte();
            corazon1.SetActive(false);
            corazon2.SetActive(false);
            corazon3.SetActive(false);
        }

        if (actualVida==1)
        {
            corazon1.SetActive(true);
            corazon2.SetActive(false);
            corazon3.SetActive(false);
        }
        if (actualVida == 2)
        {
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon3.SetActive(false);
        }
        if (actualVida == 3)
        {
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon3.SetActive(true);
        }

    }


    public void QuitarVida(float daño)
    {
        if (inmortal==true)
        {
            return;
        }
        actualVida -= daño;

        StartCoroutine(TiempoInmortal());
    }

    public void DarVida(float vida)
    {
        actualVida += vida;
    }

    public void Muerte()
    {
        gameManagerSC.GameOver();
    }

    IEnumerator TiempoInmortal()
    {
        inmortal = true;
        yield return new WaitForSeconds(tiempoInmortal);
        inmortal = false;
    }

}
