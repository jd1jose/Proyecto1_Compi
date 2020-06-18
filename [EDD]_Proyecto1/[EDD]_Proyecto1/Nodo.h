#pragma once
#include <iostream>
#include <string>
#include "NodoL.h"
#include "AVL.h"
class Nodo
{
public:
	Nodo* Siguiente;
	Nodo* Anterior;
	Nodo* Arriba;
	Nodo* Abajo;
	Nodo* Adelante;
	Nodo* Atras;
	NodoL* datos;
	AVL* Activos;
	string Nombre;

	Nodo(std::string name) {
		Siguiente = nullptr;
		Anterior = nullptr;
		Arriba = nullptr;
		Abajo = nullptr;
		Adelante = nullptr;
		Atras = nullptr;
		datos = nullptr;
		Activos = nullptr;
		Nombre = name;
	}
	~Nodo();
};

