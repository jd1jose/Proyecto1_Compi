#pragma once
#include <iostream>
#include <string>;
#include "Matriz.h";
#include "ListaDoble.h";
class Menu_
{
public:
	Matriz* M;
	ListaDoble*ListaId;
	ListaDoble* Transacciones;
	Menu_() {
	 M = new Matriz();
	 Transacciones = new ListaDoble();
	 ListaId = new ListaDoble();
	};
	string IDRandom();
	string Fechahora();
	void Loguin();
	void Menu_Admin();
	void Menu_Principal(std::string user, std::string empresa,std::string de);
	void Sub_Menu(int opcion,string User, string emp, string de);
	void Sub_MenuAd(int d);
	~Menu_(); 
};

