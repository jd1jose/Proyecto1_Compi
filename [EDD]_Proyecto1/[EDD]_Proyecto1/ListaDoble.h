#pragma once
#include "NodoL.h"
using namespace std;
class ListaDoble
{
public:
	NodoL* Primero;
	NodoL* Ultimo;
	string dato;
	string tipo;
	ListaDoble() {
		Primero = nullptr;
		Primero = nullptr;
	}

	
	void Insertar(string idtrans, string idac, string usuario, string empre, string dep, string date, string tiempo,string actividad);

	void Insertar(string nuevoid);

	bool BuscarID(string id_B);

	void Mostrar(string id, string usuario, string emp, string dep, string actividad);
	void Mostrar();
	void Reporte(bool tipo);

	void Ordenar();

	void Devolucion(string id, string user, string emp, string dep);


	
	
	~ListaDoble();
};

