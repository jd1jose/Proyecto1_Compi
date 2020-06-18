#pragma once
class Nodo_Arbol
{
public:
	Nodo_Arbol* Hijo_Iz;
	Nodo_Arbol* Hijo_De;
	Nodo_Arbol* Padre;
	bool estado;
	string Nombre;
	string des;
	int Altura;
	string Id;
	Nodo_Arbol(string valor, string descripcion, string id) {
		Hijo_De = nullptr;
		Hijo_Iz = nullptr;
		Padre = nullptr;
		Nombre = valor;
		Altura = 0;
		estado = false;
		des = descripcion;
		Id = id;
	}
	~Nodo_Arbol();
};

