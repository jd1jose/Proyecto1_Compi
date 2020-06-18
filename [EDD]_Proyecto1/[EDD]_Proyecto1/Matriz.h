#pragma once
#include "Nodo.h"
#include<iostream>
#include<string>
using namespace std;
class Matriz
{
public:
	Nodo* Cabecera;
	NodoL* Cabeza;
	Matriz() {
		Cabecera = new Nodo("Inicio");
		//Cabeza = new NodoL("Inicio","ID");
	}
	void InsertarElemento(string usuario, string empresa, string departamento, string pass, string nombre);
	Nodo* crearEmpresa(string empresa);
	Nodo* crearDepartamento(string depa);
	Nodo* BuscarDepartamento(string dep, Nodo* inicio);
	Nodo* BuscarEmpresa(string emp, Nodo* inicio);
	Nodo * Buscar(string user,string em,string dep);
	bool VerificarEmpresa(string Empresa, Nodo* inicio, Nodo* user);

	bool VerificarEmpresa2(string Empresa, Nodo * inicio, Nodo * user);
	
	bool Login(string depa, string empre, string user, string pass);

	void Mostrar();
	bool VerificarDepartamento(string depa, Nodo* inicio, Nodo*user);
	bool VerificarDepartamento2(string depa, Nodo * inicio, Nodo * user);
	void Catalogo(Nodo* usuario,bool reporte);
	void Dibujo(string contenido);
	void BuscarID(string id,bool tipo);
	void Mostrar(string tipo);
	void Reporte(string tipo,string dato);
	~Matriz();
};

