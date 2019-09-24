#include <iostream>
#include <ctime>
//Écrivez un programme de jeu « Devinez le nombre » comme suit : votre programme choisit d’abord un 
//nombre qu’il faut deviner, en sélectionnant un entier au hasard à l’intérieur d’une échelle de 1 à 100.
//Le programme affiche ensuite :
//
//Je vous cache un nombre compris entre 1 et 100. Pouvez le devinez ?
//
//Le joueur entre ensuite un premier essai.Le programme répond avec l’un des messages suivants :
//1.	Excellent!Vous avez deviné le nombre!
//2.	Nombre pas assez élevé.Essayez encore.
//3.	Nombre trop élevé.Essayez encore.
//Le jeu se termine une fois le nombre trouvé.


int main()
{
	srand(time(0));
	int random = (rand() % 100) + 1; // Génère un chiffre entre 1 et 100
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
			std::cout << "félicitation!" << std::endl;
			gameOn = false;
		}
	}

	system("pause");
}