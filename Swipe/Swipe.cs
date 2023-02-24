using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public float deadZone;
    public float velocidade;
    public float jumpTime;

    public Transform[] arrayPositions;
    public Transform jumpPosition;
    public GameObject cubo;

    Vector2 posInicial, posFinal;

    int _atualArrayPosition;
    float _atualPositionY;


    void Start()
    {
        _atualArrayPosition = 1;
        _atualPositionY = arrayPositions[_atualArrayPosition].position.y;
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            posInicial = Input.mousePosition;                                       //pega a coordenada inicial
        }
        else if (Input.GetButton("Fire1"))
        {
            posFinal = Input.mousePosition;                                         //vai pegando a cordenada até parar de tocar na tela
        }
        else if (Input.GetButtonUp("Fire1"))                                        //ao parar de tocar na tela:
        {
            if (Vector2.Distance(posFinal, posInicial) > deadZone)                              //se a distancia percorrida na tela for maior que o deadzone
            {                                                                                   //ocorre a movimentação horizontal correspondente
                if (posFinal.x > posInicial.x && _atualArrayPosition < arrayPositions.Length)   
                {
                    _atualArrayPosition++;
                }
                else if (posFinal.x < posInicial.x && _atualArrayPosition > 0)          
                {
                    _atualArrayPosition--;
                }
            }
            else
            {                                                                                   //se não ocorre um pulo.
                                                                            
                _atualPositionY = jumpPosition.position.y;                          
            }
        }


        if (cubo.transform.position.y >= jumpPosition.position.y - .1f)             // [-.1f] para arrumar o bug do float
        {
            StartCoroutine(JumpTime());
        }

        cubo.transform.position = Vector3.Lerp(cubo.transform.position, new Vector3(arrayPositions[_atualArrayPosition].position.x,     //movimento do cubo
            _atualPositionY, 0), velocidade * Time.deltaTime);                          
    }


    IEnumerator JumpTime()                              //tempo em que o cubo fica no ar
    {
        yield return new WaitForSeconds(jumpTime);
        _atualPositionY = arrayPositions[_atualArrayPosition].position.y;
    }

}
