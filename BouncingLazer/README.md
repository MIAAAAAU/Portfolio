# Bouncing Lazer

 Esse projeto eu fiz para implementar alguns conceitos sobre algebra linear dentro do Unity.
 Para realizar esse estudo utilizei dos gizmos do editor do Unity para fazer um raio com colisão (utilizando de Raycast), utilizando do vetor de colisão normalizado projetado no vetor da normal do objeto colidido (dot product) obtemos a projeção negativa da normal, com essa projeçãopodemos deslocar o vetor para cima (sendo 2 vezes para que saia do ponto do vetor colidido, va para ponto 0 e depois para o ponto de reflexão), e inverter a direção do raio (multiplicando por -1), e depois chamando o raycast novamente.
 
![image](https://user-images.githubusercontent.com/124682941/221316522-92f8e3dc-742a-4f86-86be-e05042ba6737.png)

![BouncingLazer](https://user-images.githubusercontent.com/124682941/221316607-25d2d2fa-cb49-4e2f-b9e2-74532bb04201.gif)
