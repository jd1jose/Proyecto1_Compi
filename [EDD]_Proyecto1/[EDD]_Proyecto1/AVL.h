#pragma once
#include "Nodo_Arbol.h"
#include <iostream>

using namespace std;
class AVL
{
public:
	int index = 0;
	Nodo_Arbol* Raiz;
	void Inorden();
	void Inorden(Nodo_Arbol * n);
	void Insertar(string name, string des, string id);
	void Insertar(Nodo_Arbol* N, Nodo_Arbol * R);
	string Reporte();
	void Reporte_Usuario(string contenido);
	//es2
	void Obtener_Arbol();
	string Obtener_Arbol(Nodo_Arbol* nodo);
	void Preorden(Nodo_Arbol * nodo);
	Nodo_Arbol* Buscar(string v);
	Nodo_Arbol* Buscar(string v, Nodo_Arbol* n);
	void Modificar(string id, string des, string estado);
	void Equilibrar(Nodo_Arbol * n, string lugar, bool estado);
	void RotSI(Nodo_Arbol* n);
	void RotDI(Nodo_Arbol* n);
	void RotSD(Nodo_Arbol* n);
	void RotDD(Nodo_Arbol* n);
	void orden();
	void orden(Nodo_Arbol* n);
	void Eliminar(string v);
	Nodo_Arbol * Eliminar2hijos(string v, Nodo_Arbol * n);
	Nodo_Arbol * Eliminar2hijos(Nodo_Arbol * n);
	Nodo_Arbol* Eliminar1hijo(string v, Nodo_Arbol * n);
	void EliminarHoja(string v, Nodo_Arbol * n);
	AVL();
	void MostrarA();
	void MostrarD();
	~AVL();
};

