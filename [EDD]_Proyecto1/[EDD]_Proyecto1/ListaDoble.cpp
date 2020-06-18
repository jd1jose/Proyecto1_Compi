#include "stdafx.h"
#include "ListaDoble.h"
#include "NodoL.h"
#include <fstream>
#include <iostream>
#define _CRT_SECURE_NO_WARNINGS


void ListaDoble::Insertar(string idtrans, string idac, string usuario, string empre, string dep, string date, string tiempo,string activdad) {
	
	NodoL* nuevo = new NodoL(idtrans, idac, usuario,empre, dep, date, tiempo,activdad);

	if (Primero == nullptr) {
		nuevo->Siguiente = nuevo;
		nuevo->Anterior = nuevo;
		Primero= nuevo;
	}
	else {
		nuevo->Siguiente = Primero;
		nuevo->Anterior = Ultimo;
		Ultimo->Siguiente = nuevo;

		Primero->Anterior = nuevo;
	}

	Ultimo = nuevo;
	Ordenar();
}
void ListaDoble::Insertar(string nuevoid) {
	NodoL* nuevo = new NodoL(nuevoid);

	if (Primero == nullptr) {
		nuevo->Siguiente = nuevo;
		nuevo->Anterior = nuevo;
		Primero = nuevo;
	}
	else {
		nuevo->Siguiente = Primero;
		nuevo->Anterior = Ultimo;
		Ultimo->Siguiente = nuevo;

		Primero->Anterior = nuevo;
	}

	Ultimo = nuevo;
}
bool ListaDoble::BuscarID(string id_B) {
	NodoL* aux = Primero;
	do {
		if (aux->id== id_B) {
			return true;
			break;
		}
		aux = aux->Siguiente;
	} while (aux->id != Primero->id);
	return false;
}
void ListaDoble::Mostrar(string id,string usuario,string emp, string dep, string actividad) {
	NodoL* nodo = Primero;
	cout << "Usted tiene Rentados los siguientes activos\n";
	cout << nodo->Usuario + "  " + nodo->Empresa + "  " + nodo->Departamento + "\n";
	cout << "------------------------------------------------------------------------------------\n";
		do {
			if (nodo->Usuario == usuario&&nodo->Empresa == emp && nodo->Departamento == dep&&actividad == "Rentado") {
				
				cout << nodo->id  + " " + actividad + "  " + nodo->tiempo + "\n";
				cout << nodo->fecha + "\n";
				cout << "------------------------------------------------------------------------------------\n";
			}

			nodo = nodo->Siguiente;
		} while (nodo->Siguiente->idactividad != Primero->idactividad);
		if (nodo->Usuario == usuario&&nodo->Empresa == emp && nodo->Departamento == dep&&actividad == "Rentado") {

			cout << nodo->id + " " + actividad + "  " + nodo->tiempo + "\n";
			cout << nodo->fecha + "\n";
			cout << "------------------------------------------------------------------------------------\n";
		}
}
void ListaDoble::Mostrar() {
	NodoL* nodo = Primero;
	do {
		if (nodo->Actividad == "Rentado") {
			cout << "Usted tiene Rentados los siguientes activos\n";
			cout << nodo->Usuario + "  " + nodo->Empresa + "  " + nodo->Departamento + "\n";
			cout << nodo->id + " " + nodo->Actividad + "  " + nodo->tiempo + "\n";
			cout << nodo->fecha + "\n";
			cout << "------------------------------------------------------------------------------------\n";
		}

		nodo = nodo->Siguiente;
	} while (nodo->idactividad != Primero->idactividad);

}
void ListaDoble::Reporte(bool tipo) {
	string contenido;
	if (tipo==true) {
		NodoL* Aux = Ultimo;
		string anterior;
		do {
			if (Aux==Ultimo) {
				contenido += "nodo" + Aux->idactividad + "[label=\"" + "ultimo;  " + Aux->idactividad + ";\n" + Aux->id + ";\n" + Aux->Usuario + ";\n" + Aux->Departamento + ";\n" + Aux->Empresa + "\n\",shape=\"box\"];\n";
			}
			else {
				contenido += "nodo" + Aux->idactividad + "[label=\"" + Aux->idactividad + ";\n" + Aux->id + ";\n" + Aux->Usuario + ";\n" + Aux->Departamento + ";\n" + Aux->Empresa + "\n\",shape=\"box\"];\n";
			}
			
			if (anterior == "")
			{
				anterior = "nodo" + Aux->idactividad;
			}
			else {
				contenido += anterior + "->" + "nodo" + Aux->idactividad + ";\n";
				contenido += "nodo" + Aux->idactividad + "->" + anterior + ";\n";
				anterior = "nodo" + Aux->idactividad;
			}
			Aux = Aux->Siguiente;
		} while (Aux->Siguiente != Primero);
		contenido += anterior + "->" + "nodo" + Primero->idactividad + ";\n";
		contenido += "nodo" + Primero->idactividad + "->" + anterior + ";\n";
	}
	else {
		NodoL* Aux = Primero;
		string anterior;
		do {
			contenido += "nodo" + Aux->idactividad + "[label=\"" + Aux->id + ";\n" + Aux->Usuario + ";\n" + Aux->Departamento + ";\n" + Aux->Empresa + "\n\",shape=\"box\"];\n";
			if (anterior == "")
			{
				anterior = "nodo" + Aux->idactividad;
			}
			else {
				contenido += anterior + "->" + "nodo" + Aux->idactividad + ";\n";
				contenido += "nodo" + Aux->idactividad + "->" + anterior + ";\n";
				anterior = "nodo" + Aux->idactividad;
			}
			Aux = Aux->Anterior;
		} while (Aux->Anterior != Ultimo);
		contenido += anterior + "->" + "nodo" + Primero->idactividad + ";\n";
		contenido += "nodo" + Primero->idactividad + "->" + anterior + ";\n";
	}
	


	ofstream archivo;
	archivo.open("Graficas\\Transacciones.dot");
	archivo << "digraph G{\n rankdir=\"LR\";\n";
	archivo << contenido + "\n";
	archivo << "}";
	archivo.close();
	system("dot -Tpng Graficas\\Transacciones.dot -o Graficas\\Transacciones.png");
}
void ListaDoble::Ordenar() {
	NodoL* Aux = Primero;
	NodoL*dato;
	while (Aux->Siguiente!=Primero)
	{
		NodoL* Aux2 = Aux->Siguiente;
		while (Aux2!=Ultimo)
		{
			if (Aux->idactividad>Aux2->idactividad) {
				dato = Aux;
				Aux = Aux2;
				Aux2 = dato;
			
			}
			Aux2 = Aux2->Siguiente;
		}
		Aux = Aux->Siguiente;
	}
}
void ListaDoble::Devolucion(string id,string user,string emp,string dep) {
	NodoL* aux = Primero;
	do {
		if (aux->id==id&&aux->Usuario==user&&aux->Departamento==dep&&aux->Empresa==emp) {
			aux->Actividad = "Devuelto";
		}
		aux = aux->Siguiente;
	
	} while (aux != Primero);

}
ListaDoble::~ListaDoble()
{
}
