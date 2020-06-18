#include "stdafx.h"
#include "AVL.h"
#include "Nodo_Arbol.h"
#include <iostream>
using namespace std;

void AVL::Inorden() {
	Inorden(Raiz);
}
void AVL::Inorden(Nodo_Arbol* n) {
	if (n == nullptr) {
		return;
	}
	Inorden(n->Hijo_Iz);
	cout << n->dato << "-";
	Inorden(n->Hijo_De);
}
void AVL:: Insertar(int v) {
	Nodo_Arbol* Nuevo = new Nodo_Arbol(v);
	if (Raiz == nullptr) {
		Raiz = Nuevo;
		Equilibrar(Nuevo, "inicio", "True");
	}
	else {
		Insertar(Nuevo, Raiz);
	}

}
void AVL::Insertar(Nodo_Arbol* N, Nodo_Arbol* R) {
	Nodo_Arbol* Aux;
	Aux = R;
	if (N->dato < Aux->dato) {
		if (Aux->Hijo_Iz != nullptr) {
			Aux = Aux->Hijo_Iz;
			Insertar(N, Aux);
		}
		else {
			Aux->Hijo_Iz = N;
			//mando a llamar equilibrar
			Equilibrar(Aux, "Iz", "True");
		}
	}
	else {
		if (Aux->Hijo_De != nullptr) {
			Aux = Aux->Hijo_De;
			Insertar(N, Aux);
		}
		else {
			Aux->Hijo_De = N;
			//mando a llamar equilibrar
			Equilibrar(Aux, "De", "True");
		}
	}
}
void AVL::Preorden() {
	Preorden(Raiz);
}
void AVL::Preorden(Nodo_Arbol* nodo) {
	if (nodo == nullptr || nodo->dato<0) {
		return;
	}
	cout << nodo->dato << "-";
	Preorden(nodo->Hijo_Iz);
	Preorden(nodo->Hijo_De);
}
void AVL::Eliminar(int v) {
	Nodo_Arbol* Aux = Raiz;
	Nodo_Arbol* Nodo_E = Buscar(v);
	int tipo = 0;
	if (Nodo_E->Hijo_De == nullptr&&Nodo_E->Hijo_Iz == nullptr) {
		tipo = 0;
	}
	else if (Nodo_E->Hijo_De == nullptr || Nodo_E->Hijo_Iz == nullptr) {
		tipo = 1;
	}
	else if (Nodo_E->Hijo_De != nullptr && Nodo_E->Hijo_Iz != nullptr) {
		tipo = 2;
	}
	switch (tipo)
	{
	case 0:
		EliminarHoja(v, Aux);
		break;
	case 1:
		Eliminar1hijo(v, Aux);
		break;
	case 2:
		Eliminar2hijos(v, Aux);
		break;
	}
}
Nodo_Arbol* AVL::Eliminar2hijos(int v, Nodo_Arbol* n) {
	Nodo_Arbol* Aux;
	Aux = n;
	Nodo_Arbol*Aux2;
	if (v <= Aux->dato) {
		if (Aux->dato == v) {

			if (Aux->Hijo_Iz == nullptr) {
				return Aux->Hijo_De;
			}
			else {
				return Eliminar2hijos(Aux->Hijo_Iz);

			}
		}
		else {

			Aux2 = Eliminar2hijos(v, Aux->Hijo_Iz);
			//aqui si 25->9
			if (Aux->Hijo_Iz->Hijo_Iz->dato == Aux2->dato) {
				Aux2->Hijo_De = Aux->Hijo_Iz->Hijo_De;
				Aux->Hijo_Iz = Aux2;
				Equilibrar(Aux, "Iz", "False");
			}
			else {
				Aux->Hijo_Iz->dato = Aux2->dato;
				//delete Aux2;
				Equilibrar(Aux, "Iz", "False");
			}
		}
	}
	else {
		if (Aux->dato == v) {

			if (Aux->Hijo_Iz == nullptr) {
				return Aux->Hijo_De;
			}
			else {
				return Eliminar2hijos(Aux->Hijo_Iz);
			}
		}
		else {

			Aux2 = Eliminar1hijo(v, Aux->Hijo_De);
			if (Aux->Hijo_De->Hijo_Iz->dato == Aux2->dato) {
				Aux2->Hijo_De = Aux->Hijo_De->Hijo_De;
				Aux->Hijo_De = Aux2;
				Equilibrar(Aux, "Iz", "False");
			}
			else {
				Aux->Hijo_De->dato = Aux2->dato;
				//delete Aux2;
				Equilibrar(Aux, "Iz", "False");
			}
		}
	}
}
Nodo_Arbol* AVL::Eliminar2hijos(Nodo_Arbol* n) {
	Nodo_Arbol* Aux = n;
	if (Aux->Hijo_De == nullptr) {
		return Aux;
	}
	else {
		return Eliminar2hijos(Aux->Hijo_De);
	}
}
Nodo_Arbol* AVL::Eliminar1hijo(int v, Nodo_Arbol* n) {
	Nodo_Arbol* Aux;
	Aux = n;
	Nodo_Arbol*Aux2;
	if (v <= Aux->dato) {
		if (Aux->dato == v) {

			if (Aux->Hijo_Iz == nullptr) {
				return Aux->Hijo_De;
			}
			else {
				Aux = Aux->Hijo_Iz;
				return Aux;
			}
		}
		else {

			Aux2 = Eliminar1hijo(v, Aux->Hijo_Iz);
			Aux->Hijo_Iz = Aux2;
			Equilibrar(Aux, "Iz", "False");

		}

	}
	else {
		if (Aux->dato == v) {

			if (Aux->Hijo_Iz == nullptr) {
				return Aux->Hijo_De;
			}
			else {
				return Aux->Hijo_Iz;
			}
		}
		else {

			Aux2 = Eliminar1hijo(v, Aux->Hijo_De);
			Aux->Hijo_De = Aux2;
			Equilibrar(Aux, "Iz", "False");
		}
	}
}
void AVL::EliminarHoja(int v, Nodo_Arbol* n) {
	Nodo_Arbol* Aux;
	Aux = n;

	if (v< Aux->dato) {
		if (Aux->Hijo_Iz->dato == v) {
			cout << "\n el dato eliminar es:" << Aux->Hijo_Iz->dato;
			Aux->Hijo_Iz = nullptr;
			Equilibrar(Aux, "Iz", "False");
			return;
		}
		else {
			Aux = Aux->Hijo_Iz;
			EliminarHoja(v, Aux);
		}
	}
	else {
		if (Aux->Hijo_De->dato == v) {
			cout << "\n el dato eliminar es:" << Aux->Hijo_De->dato;
			Aux->Hijo_De = nullptr;
			Equilibrar(Aux, "De", "False");
			return;
		}
		else {
			Aux = Aux->Hijo_De;
			EliminarHoja(v, Aux);
		}
	}
}
Nodo_Arbol* AVL::Buscar(int v) {
	Nodo_Arbol* rep = Buscar(v, Raiz);
	return rep;
}
Nodo_Arbol* AVL::Buscar(int v, Nodo_Arbol* n) {
	Nodo_Arbol* Aux;
	Aux = n;
	if (v == Aux->dato) {
		return Aux;
	}
	else if (v< Aux->dato) {
		if (Aux->Hijo_Iz != nullptr) {
			Aux = Aux->Hijo_Iz;
			return Buscar(v, Aux);
		}
		else {
			return false;
		}
	}
	else {
		if (Aux->Hijo_De != nullptr) {
			Aux = Aux->Hijo_De;
			return	Buscar(v, Aux);
		}
		else {
			return false;
		}
	}

}
void AVL::Modificar(int v1, int v2) {
	Nodo_Arbol * dato = Buscar(v1);
	if (dato->Hijo_Iz != nullptr) {
		if (v2>dato->Hijo_Iz->dato) {
			if (dato->Hijo_De != nullptr) {
				if (v2 < dato->Hijo_De->dato) {
					dato->dato = v2;
				}
				else {
					Eliminar(v1);
					Insertar(v2);
				}
			}
			else {
				dato->dato = v2;
			}

		}
		else {
			Eliminar(v1);
			Insertar(v2);
		}

	}
	else if (dato->Hijo_De != nullptr) {
		if (v2<dato->Hijo_De->dato) {
			if (dato->Hijo_Iz != nullptr) {
				if (v2 > dato->Hijo_Iz->dato) {
					dato->dato = v2;
				}
				else {
					Eliminar(v1);
					Insertar(v2);
				}
			}
			else {
				dato->dato = v2;
			}

		}
		else {
			Eliminar(v1);
			Insertar(v2);
		}
	}

}
void AVL::Equilibrar(Nodo_Arbol* n, string lugar, bool estado) {
	bool escape = false;
	while (n && !escape )
	{
		////Preguntas si es eliminar o insertar
		if (estado) {
			if (lugar=="Iz") {
				n->Altura--;
			}
			else {
				n->Altura++;
			}
		}
		else {
			if (lugar == "Iz") {
				n->Altura++;
			}
			else {
				n->Altura--;
			}
		}
		//
		if (n->Altura==0) {
			escape = true;
		}//rotacion por la derecha
		else if (n->Altura==-2) {
			if (n->Hijo_Iz->Altura==1) {
			//rotacion doble
				RotDD(n);
			}
			else {
			//rotacion simple
				RotSD(n);
			}
			escape = true;
		}
		else if (n->Altura == 2) {
			if (n->Hijo_De->Altura==-1) {
				RotDI(n);
			}
			else {
				RotSI(n);
			}
			escape = true;
		}
		if (n->Padre) {
			if (n->Padre->Hijo_De==n) {
				lugar = "De";
			}
			else
			{
				lugar = "Iz";
			}
		}
		n = n->Padre;
	}
}
void AVL::RotSI(Nodo_Arbol* n) {
	Nodo_Arbol* Padre = n->Padre;
	Nodo_Arbol* Np = n;
	Nodo_Arbol* Nd = Np->Hijo_De;//Q
	Nodo_Arbol* Ni = Nd->Hijo_Iz;//B
	
	if (Padre) {
		if (Padre->Hijo_De==Np) {
			Padre->Hijo_De = Nd;
		}
		else {
			Padre->Hijo_Iz = Nd;
		}
	}
	else {
		Raiz = Nd;
	}

	Np->Hijo_De = Ni;
	Nd->Hijo_Iz = Np;

	Np->Padre = Nd;
	if (Ni) {
		Ni->Padre = Np;
	}
	Nd->Padre = Padre;

	Np->Altura = 0;
	Nd->Altura = 0;

}
void AVL::RotSD(Nodo_Arbol* n) {
	Nodo_Arbol* Padre = n->Padre;
	Nodo_Arbol* Np = n;
	Nodo_Arbol* Nd = Np->Hijo_De;//Q
	Nodo_Arbol* Ni = Nd->Hijo_Iz;//B

	if (Padre) {
		if (Padre->Hijo_De == Np) {
			Padre->Hijo_De = Nd;
		}
		else {
			Padre->Hijo_Iz = Nd;
		}
	}
	else {
		Raiz = Nd;
	}

	Np->Hijo_Iz = Ni;
	Nd->Hijo_De = Np;

	Np->Padre = Nd;
	if (Ni) {
		Ni->Padre = Np;
	}
	Nd->Padre = Padre;

	Np->Altura = 0;
	Nd->Altura = 0;
}
void AVL::RotDI(Nodo_Arbol* n) {
	Nodo_Arbol* Padre = n->Padre;
	Nodo_Arbol* NP = n;
	Nodo_Arbol* NQ = NP->Hijo_De;
	Nodo_Arbol* NR = NQ->Hijo_Iz;
	Nodo_Arbol* NB = NR->Hijo_Iz;
	Nodo_Arbol* NC = NR->Hijo_De;

	if (Padre) {
		if (Padre->Hijo_De == n) {
			Padre->Hijo_De = NR;
		}
		else { Padre->Hijo_Iz = NR; }
	}
	else Raiz = NR;
	//Reconstruir arbol
	NP->Hijo_De = NB;
	NQ->Hijo_Iz = NC;
	NR->Hijo_Iz = NP;
	NR->Hijo_De = NQ;
	//Reasignar Padre;
	NR->Padre = Padre;
	NP->Padre = NQ->Padre = NR;
	if (NB) {
		NB->Padre = NP;
	}
	if (NC) {
		NC->Padre = NQ;
	}
	//Ajustar valores Altura
	
	switch (NR->Altura) {
	case -1:NP->Altura = 0; NQ->Altura = 1; break;
	case 0: NP->Altura = 0; NQ->Altura = 0; break;
	case 1: NP->Altura = -1;NQ->Altura = 0; break;
	}
	NR->Altura = 0;
}
void AVL::RotDD(Nodo_Arbol* n) {
	//Rotacion doble a Derecha
	Nodo_Arbol* Padre = n->Padre;
	Nodo_Arbol* NP = n;
	Nodo_Arbol* NQ = NP->Hijo_Iz;
	Nodo_Arbol* NR = NQ->Hijo_De;
	Nodo_Arbol* NB = NR->Hijo_Iz;
	Nodo_Arbol* NC = NR->Hijo_De;

	if (Padre) {
		if (Padre->Hijo_De == n) {
			Padre->Hijo_De = NR;
		}
		else { Padre->Hijo_Iz = NR; }
	}
	else Raiz = NR;

	//Reconstruir arbol
	NQ->Hijo_De = NB;
	NP->Hijo_Iz = NC;
	NR->Hijo_Iz = NQ;
	NR->Hijo_De = NP;
	//Reasignar Padre;
	NR->Padre = Padre;
	NP->Padre = NQ->Padre = NR;
	if (NB) {
		NB->Padre = NQ;
	}
	if (NC) {
		NC->Padre = NP;
	}
	//Ajustar valores Altura
	switch (NR->Altura)
	{
	case -1:NQ->Altura = 0; NP->Altura = 1; break;
	case 0: NQ->Altura = 0; NP->Altura = 0; break;
	case 1: NP->Altura = 0; NQ->Altura = -1; break;
	}
}
AVL::AVL()
{
}


AVL::~AVL()
{
}
