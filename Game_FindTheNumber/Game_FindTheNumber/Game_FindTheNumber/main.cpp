#include <iostream>
#include <ctime>
//�crivez un programme de jeu � Devinez le nombre � comme suit : votre programme choisit d�abord un 
//nombre qu�il faut deviner, en s�lectionnant un entier au hasard � l�int�rieur d�une �chelle de 1 � 100.
//Le programme affiche ensuite :
//
//Je vous cache un nombre compris entre 1 et 100. Pouvez le devinez ?
//
//Le joueur entre ensuite un premier essai.Le programme r�pond avec l�un des messages suivants :
//1.	Excellent!Vous avez devin� le nombre!
//2.	Nombre pas assez �lev�.Essayez encore.
//3.	Nombre trop �lev�.Essayez encore.
//Le jeu se termine une fois le nombre trouv�.


int main()
{
	srand(time(0));
	int random = (rand() % 100) + 1; // G�n�re un chiffre entre 1 et 100
	int devinette;
	bool gameOn = true;
	while (gameOn) 
	{
		std::cout << "Entrer un nombre" << std::endl;
		std::cin >> devinette;
		if (devinette < random)
		{
			std::cout << "damn t'es trop petit (thats what she said)" << std::endl;
		}
		else if (devinette > random)
		{
			std::cout << "damn t'es trop grand (thats what she didnt say FeelsBadMan)" << std::endl;
		}
		else
		{
			std::cout << "f�licitation!" << std::endl;
			gameOn = false;
		}
	}

	system("pause");
}