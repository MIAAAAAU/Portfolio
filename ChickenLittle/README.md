# Jogo da Galinha

Esse projeto está sendo desenvolvido em parceria com um amigo meu, ele está responsável por produzir os sprites e eu por programar o jogo e implementar os sprites no unity.

O projeto está no começo do desenvolvimento.


Por enquanto temos movimento horizontal

![run](https://user-images.githubusercontent.com/124682941/217358161-4a6de957-32c4-4ed2-8969-9bddd9a96713.gif)

Ação  idle


![idle](https://user-images.githubusercontent.com/124682941/217359752-0c1f7da6-4d8e-43ae-8b59-601682e1f5d4.gif)

E o pulo do personagem.

![jump](https://user-images.githubusercontent.com/124682941/217358291-7143c76a-42fb-4c89-8d64-e4f9f558370d.gif)

 Nota-se ao pular, que é um pulo complexo, e parametrizável; 
 
 ![jump_code](https://user-images.githubusercontent.com/124682941/217384847-b74432c8-c3c2-4997-8360-30bba50648b1.PNG)
 
 Tem uma altura mínima, e uma máxima, sendo que ao passar da altura mínima a força do pulo é decrementada de maneira progressiva (quanto mais tempo estver segurando espaço mais fraco se torna o impulso), de maneira que ao atingir seu pico e entrar em queda, sua gravidade é aumentada para dar a dinâmica de pulo desejada com base em jogos de plataforma.
 
 As animação do pulo é composta por 4 etapas, ao pular, ao ficar no ar na subida, queda e aterrissagem.
