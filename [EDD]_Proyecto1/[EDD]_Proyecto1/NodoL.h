#pragma once
#include <string>
#include <iostream>
using namespace std;
class NodoL
{
public:
	NodoL* Siguiente;
	NodoL* Anterior;
	string Nombre;
	string Contraseña;
	string Usuario;
	string Empresa;
	string Departamento;
	string idactividad,id,fecha,tiempo,Actividad;
	NodoL(string name,string pass, string user, string emp, string depa) {
		Siguiente = nullptr;
		Anterior = nullptr;
		Nombre = name;
		Contraseña = pass;
		Usuario = user;
		Empresa = emp;
		Departamento = depa;
	}
	NodoL(string idtrans,string idac,string usuario,string empre,string dep, string date, string tiempo,string actividad) {
		Siguiente = nullptr;
		Anterior = nullptr;
		Usuario=usuario;
		Empresa=empre;
		Departamento=dep;
		idactividad=idtrans;
		id=idac;
		fecha=date;
		Actividad=actividad;

	}
	NodoL(string nuevoid) {
		Siguiente = nullptr;
		Anterior = nullptr;
		id = nuevoid;
	}
	~NodoL();
};

