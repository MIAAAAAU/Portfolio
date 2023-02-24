using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingLazer : MonoBehaviour
{

    int maxBounces = 5;

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;            //pega a origem do raycast
        Vector3 dir = transform.right;                //pega a dire��o do raycast
        Ray ray = new Ray(origin, dir);                 //cria o ray do raycast e atribui sua origem e dire��o

        Gizmos.DrawLine(origin, origin + dir);          //desenha o raycast

        for (int i = 0; i < maxBounces; i++)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))                    //se o raycast collidir
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(ray.origin, hit.point);                     //desenha uma linha da origem ate o ponto onde colide
                Vector3 reflected = Reflect(ray.direction, hit.normal);     //pega a dire��o da reflex�o do ray
                Gizmos.color = Color.white;
                Gizmos.DrawLine(hit.point, hit.point + reflected);           //desenha a dire��o da reflex�o no ponto de colis�o
                ray.direction = reflected;                                  //atribui a dire��o refletida como dire��o base para o ray 
                ray.origin = hit.point;                                     //atribui como origem o ultimo ponto de colis�o
            }
            else break;
        }
    }

    Vector3 Reflect(Vector3 rayDir, Vector3 n)
    {
        float proj = Vector3.Dot(rayDir, n);            //dot product da dire��o do ray com a normal da colis�o
        return rayDir - 2 * proj * n;                   //retorna a dire��o de reflex�o do ray
    }
}