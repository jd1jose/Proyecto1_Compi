#include "stdafx.h"
#include "Menu_.h";
#include <iostream>
#include "Matriz.h"
#include "[EDD]_Proyecto1.h"
using namespace std;

int main()
{
	Menu_* menu=new Menu_();
	Nodo* d = new Nodo("pela");
	menu->M->InsertarElemento("Jose", "Max", "Guatemala", "123", "jose ALdana");
	 d=menu->M->Buscar("Jose", "Max", "Guatemala");
	d->Activos->Insertar("Activo1","des_Activo1", "id4");
	d->Activos->Insertar("Activo2", "des_Activo2", "id7");
	d->Activos->Insertar("Activo3", "des_Activo3", "id3");
	d->Activos->Insertar("Activo4", "des_Activo4", "id5");
	d->Activos->Insertar("Activo5", "des_Activo5", "id1");
	d->Activos->Reporte_Usuario(d->Activos->Reporte());
	menu->M->InsertarElemento("Jose2", "Max1", "Guatemala1", "123", "jose ALdana");
	 d = menu->M->Buscar("Jose2", "Max1", "Guatemala1");
	d->Activos->Insertar("Activo2-1", "des2_Activo1", "id4_1");
	d->Activos->Insertar("Activo2-2", "des2_Activo2", "id7_2");
	d->Activos->Insertar("Activo2-3", "des2_Activo3", "id3_3");
	d->Activos->Insertar("Activo2-4", "des2_Activo4", "id5_4");
	d->Activos->Insertar("Activo2-5", "des2_Activo5", "id11_5");
	d->Activos->Reporte_Usuario(d->Activos->Reporte());
	menu->M->InsertarElemento("Jose3", "Max2", "Guatemala1", "123", "jose ALdana");
	 d = menu->M->Buscar("Jose3", "Max2", "Guatemala1");
	d->Activos->Insertar("Activo3-1", "des3_Activo1", "id4_5");
	d->Activos->Insertar("Activo3-2", "des3_Activo2", "id7_5");
	d->Activos->Insertar("Activo3-3", "des3_Activo3", "id3_5");
	d->Activos->Insertar("Activo3-4", "des3_Activo4", "id5_5");
	d->Activos->Insertar("Activo3-5", "des3_Activo5", "id1_5");
	d->Activos->Reporte_Usuario(d->Activos->Reporte());
	menu->Loguin();
	
	/*Matriz* M = new Matriz();

	
	
	M->InsertarElemento("Jose4", "Max1", "Guatemala2", "123", "jose ALdana");
	M->InsertarElemento("Jose5", "Max", "Guatemala3", "123", "jose ALdana");
	M->Catalogo(nullptr,true);
	M->Mostrar();*/

	/*AVL* ar = new AVL();
	ar->Insertar("nombre1","des1","id1");
	ar->Insertar("nombre2", "des2", "id2");
	ar->Insertar("nombre3", "des3", "id3");
	ar->Insertar("nombre4", "des4", "id4");
	ar->Insertar("nombre5", "des5", "id5");
	ar->Insertar("nombre6", "des6", "id6");
	ar->Reporte_Usuario(ar->Reporte());
	ar->Inorden();
	ar->Eliminar("id5");
	ar->Inorden();
	ar->Reporte_Usuario(ar->Reporte());*/
    return 0;
}

