#include "stdafx.h"
#include "Matriz.h"
#include"NodoL.h"
#include <fstream>
#include <iostream>
#define _CRT_SECURE_NO_WARNINGS



void Matriz::InsertarElemento(string usuario, string empresa, string departamento, string pass,string nombre)
{
	Nodo* Usuario = new Nodo(usuario);
	Nodo* Empresa;
	Nodo* Departamento;
	NodoL* datos_User;
	Usuario->datos = datos_User = new NodoL(nombre, pass, usuario, empresa, departamento);
	AVL* ar = new AVL();
	ar->Insertar("0","0","0");
	Usuario->Activos = ar;
	
	Departamento = BuscarDepartamento(departamento, Cabecera);
	Empresa = BuscarEmpresa(empresa, Cabecera);

	if (Departamento == nullptr) {
		Departamento = crearDepartamento(departamento);
	}
	if (Empresa == nullptr) {
		Empresa = crearEmpresa(empresa);
	}


	//Departamento--------------------------------------------
	if (Departamento->Abajo == nullptr) {
		Departamento->Abajo = Usuario;
		Usuario->Arriba = Departamento;
	}
	else if (Empresa->Abajo == nullptr) {
		Nodo* aux = Departamento->Abajo;
		while (aux->Abajo != nullptr) {
			aux = aux->Abajo;
		}
		if (!VerificarEmpresa(empresa, aux, Usuario)) {
			if (VerificarEmpresa2(empresa, aux, Usuario)==true) {
				cout << "El usuario ya existe" << Usuario->Nombre;
				delete Usuario;
				return;
			}			
			aux->Abajo = Usuario;
			Usuario->Arriba = aux;
		}
		
  	
	}
	else {
		Nodo* aux = Departamento;
		do {
			aux = aux->Abajo;
			if (!VerificarEmpresa(empresa, aux, Usuario)) {
				if (VerificarEmpresa2(empresa, aux, Usuario)==true) {
					cout << "El usuario ya existe" << Usuario->Nombre;
					delete Usuario;
					return;
				}				
				Nodo* aux_emp = aux->Anterior;
				while (aux_emp->Anterior != nullptr) {
					aux_emp = aux_emp->Anterior;
				}
				while (aux_emp->Arriba != nullptr) {
					if (aux_emp->Nombre == empresa) {
						Usuario->Abajo = aux;
						Usuario->Arriba = aux->Arriba;

						aux->Arriba->Abajo = Usuario;
						aux->Arriba = Usuario;
						break;
					}
					aux_emp = aux_emp->Arriba;
				}
			}
			
		
		} while (aux->Abajo != nullptr && Usuario->Arriba == nullptr);

		if (Usuario->Arriba == nullptr && Usuario->Adelante == nullptr) {
			aux->Abajo = Usuario;
			Usuario->Arriba = aux;
		}

	}
	if (Usuario->Arriba == nullptr && Usuario->Atras == nullptr) {
		return;
	}
	//Empresa----------------------------------------------------------
	if (Empresa->Siguiente == nullptr) {
		Empresa->Siguiente = Usuario;
		Usuario->Anterior = Empresa;
	}
	else if (Departamento->Siguiente == nullptr) {
		Nodo* aux = Empresa->Siguiente;
		while (aux->Siguiente != nullptr) {
			aux = aux->Siguiente;
		}
		if (!VerificarDepartamento(departamento, aux, Usuario)) {
			if (VerificarDepartamento2(departamento, aux, Usuario)==true) {
				cout << "El usuario ya existe"<<Usuario->Nombre;
				delete Usuario;
				return;
			}
			aux->Siguiente = Usuario;
			Usuario->Anterior = aux;
		}
		

	}else {
		Nodo* aux = Empresa;
		do {
			aux = aux->Siguiente;
			if (!VerificarDepartamento(departamento, aux, Usuario)) {
				
				if (VerificarDepartamento2(departamento, aux, Usuario)==true) {
					cout << "El usuario ya existe" << Usuario->Nombre;
					delete Usuario;
					return;
				}
				Nodo* aux_Depa = aux->Arriba;
				while (aux_Depa->Arriba != nullptr) {
					aux_Depa = aux_Depa->Arriba;
				}
				while (aux_Depa->Anterior != nullptr) {
					if (aux_Depa->Nombre == departamento) {
						Usuario->Siguiente = aux;
						Usuario->Anterior = aux->Anterior;
						aux->Anterior->Siguiente = Usuario;
						aux->Anterior = Usuario;
						break;
					}
					aux_Depa = aux_Depa->Anterior;
				}
			}
			

		} while (aux->Siguiente != nullptr && Usuario->Anterior == nullptr);
		if (Usuario->Anterior == nullptr && Usuario->Adelante == nullptr) {
			aux->Siguiente = Usuario;
			Usuario->Anterior = aux;
		}
	}
 }
Nodo * Matriz::crearEmpresa(string empresa)
{
	Nodo* Empresa;
	Empresa = new Nodo(empresa);
	Nodo* aux = Cabecera;
	while (aux->Abajo != nullptr) {
		aux = aux->Abajo;
	}
	aux->Abajo = Empresa;
	Empresa->Arriba = aux;
	return Empresa;
}
Nodo * Matriz::crearDepartamento(string depa)
{
	Nodo* Depar;
	Depar = new Nodo(depa);
	Nodo* aux = Cabecera;
	while (aux->Siguiente!= nullptr) {
		aux = aux->Siguiente;
	}
	aux->Siguiente = Depar;
	Depar->Anterior = aux;
	return Depar;
}
Nodo * Matriz::BuscarDepartamento(string dep, Nodo * inicio)
{
	Nodo* aux = inicio;
	while (aux != nullptr) {
		if (aux->Nombre == dep) {
			return aux;
		}
		aux = aux->Siguiente;

	}
	return false;
}
Nodo * Matriz::BuscarEmpresa(string emp, Nodo * inicio)
{
	Nodo* aux = inicio;
	while (aux != nullptr) {
		if (aux->Nombre == emp) {
			return aux;
		}
		aux = aux->Abajo;

	}
	return false;
}
Nodo* Matriz::Buscar(string user,string em,string de) {
	Nodo* aux = Cabecera;
	Nodo* us ;
	
	while (aux != nullptr) {
		if (aux->Nombre == de) {
			break;
		}
		aux = aux->Siguiente;

	}

	while (aux != nullptr) {
		if (aux->Nombre == user) {
			us = aux;
			while (aux->Anterior != nullptr) {
				aux = aux->Anterior;
			}
			if (aux->Nombre==em) {
				return us;
				
			}
			else us = nullptr;
			
		}
		aux = aux->Abajo;

	}
	if (aux==nullptr) {
		aux = Cabecera;
		while (aux != nullptr) {
			if (aux->Nombre == de) {
				while (aux != nullptr) {
					while (aux->Atras != nullptr) {
						if (aux->Atras->Nombre==user) {
							us = aux->Atras;
							return us;
							break;
						}
						aux = aux->Atras;
					}
					aux = aux->Abajo;

				}

			}
			aux = aux->Siguiente;

		}
		
	}
	//if para saber devolver un no se a encontrado no existe 
}
bool Matriz::VerificarEmpresa(string Empresa, Nodo * inicio, Nodo * user)
{
	Nodo* auxEmp = inicio;//->Anterior;
	while(auxEmp->Anterior != nullptr) {
		auxEmp = auxEmp->Anterior;
	}
	if (auxEmp->Nombre == Empresa) {

		while (inicio->Atras != nullptr) {			
				inicio = inicio->Atras;
		}
		if (inicio->Nombre==user->Nombre) {
			return false;
		}
		else {
			inicio->Atras = user;
			user->Adelante = inicio;
			return true;
		}	
		
	}
	return false;
}
bool Matriz::VerificarEmpresa2(string Empresa, Nodo * inicio, Nodo * user)
{
	Nodo* auxEmp = inicio;//->Anterior;
	while (auxEmp->Anterior != nullptr) {
		auxEmp = auxEmp->Anterior;
	}
	if (auxEmp->Nombre == Empresa) {

		while (inicio->Atras != nullptr) {


			inicio = inicio->Atras;
		}
		if (inicio->Nombre == user->Nombre) {
			return true;
		}
		else {
			inicio->Atras = user;
			user->Adelante = inicio;
			return true;
		}
	}
	return false;
}
bool Matriz::VerificarDepartamento(string depa, Nodo * inicio, Nodo * user)
{
	Nodo* aux = inicio;//->Arriba;
	while (aux->Arriba != nullptr) {
		aux = aux->Arriba;
	}
	if (aux->Nombre == depa) {
		while (inicio->Atras != nullptr) {


			inicio = inicio->Atras;

		}
		if (inicio->Nombre == user->Nombre) {
			return false;
		}
		else {
			inicio->Atras = user;
			user->Adelante = inicio;
			return true;
		}


	}
	return false;
}
bool Matriz::VerificarDepartamento2(string depa, Nodo * inicio, Nodo * user)
{
	Nodo* aux = inicio;//->Arriba;
	while (aux->Arriba != nullptr) {
		aux = aux->Arriba;
	}
	if (aux->Nombre == depa) {
		while (inicio->Atras != nullptr) {


			inicio = inicio->Atras;

		}
		if (inicio->Nombre == user->Nombre) {
			return true;
		}
		else {
			inicio->Atras = user;
			user->Adelante = inicio;
			return true;
		}


	}
	return false;
}
bool Matriz::Login(string depa,string empre,string user,string pass) {
	Nodo* d;
	Nodo* e;
	Nodo* us=nullptr;
	d = BuscarDepartamento(depa,Cabecera);
	e = BuscarEmpresa(empre,Cabecera);
	
	
	if (d != nullptr&&e != nullptr) {
		Nodo* aux = d->Abajo;
		Nodo* aux3;
		Nodo* aux2;
		string encontrado = "no";
		do {
			aux2 = aux;
			do {

				if (aux->Nombre == user) {
					us = aux2;
					aux3 = us;

					do {
						if (aux3 == e) {
							us = aux2;
							encontrado = "si";
							break;
						}
						else {
							encontrado = "no";
							us = nullptr;
						}
						aux3 = aux3->Anterior;
					} while (aux3 != nullptr);

				}
				aux2 = aux2->Atras;
			} while (aux2 != nullptr);

			if (us != nullptr) {
				break;
			}
			aux = aux->Abajo;
		} while (aux != nullptr);

		if (encontrado == "no") {
			aux = d->Abajo;
			do {
				if (aux->Atras != nullptr) {
					aux2 = aux;
					do {
						if (aux2->Nombre == user) {
							us = aux2;
							break;
						}
						aux2 = aux2->Atras;
					} while (aux2 != nullptr);


				}
				aux = aux->Abajo;
			} while (aux != nullptr);
			aux = e->Siguiente;
			do {
				if (aux->Atras != nullptr) {
					aux2 = aux;
					do {
						if (aux2->Nombre == user) {
							if (us->datos->Usuario == aux2->datos->Usuario &&us->datos->Contraseña == aux2->datos->Contraseña) {
								encontrado = "si";
								break;

							}

						}
						aux2 = aux2->Atras;
					} while (aux2 != nullptr);
				}
				aux = aux->Siguiente;
			} while (aux != nullptr);

		}
		if (encontrado == "si") {
			if (us->datos->Usuario == user&&us->datos->Contraseña == pass) {
				//encontramos el usuario y contraseña
				return true;
			}
			return false;
		}


		return false;
	}
	else {
		return false;
	}
	
}
void Matriz::Mostrar() {
	Nodo* aux = Cabecera->Siguiente;
	Nodo* aux2;
	Nodo* aux3;
	Nodo* auxem;
	string datos = "";
	string emp, dep;
	while (aux != nullptr)
	{
		dep = aux->Nombre;
		aux2 = aux->Abajo;
		auxem = aux2;

		while (aux2 != nullptr) {

			while (auxem!=nullptr) {
				emp = auxem->Nombre;
				auxem = auxem->Anterior;
		
			}
		
		
			
			datos += "Nombre:" + aux2->Nombre + "; Empresa:" + emp + "; Departamento:" + dep + ";\n";
			if (aux2->Atras!=nullptr) {
				aux3 = aux2->Atras;
				while (aux3!=nullptr)
				{
					datos += "Nombre:" + aux3->Nombre + "; Empresa:" + emp + "; Departamento:" + dep + ";\n";
					aux3 = aux3->Atras;
				}
				
			}

			aux2 = aux2->Abajo;
			auxem = aux2;
		}
		aux = aux->Siguiente;
	}
	cout << datos+"\n";
}
void Matriz::Catalogo(Nodo* usuario,bool reporte) {

	string id;
	string name;
	Nodo* aux = Cabecera->Siguiente;
	Nodo* aux2;
	Nodo* aux3;
	string rama;
	
	if (reporte==false) {
		name = usuario->Nombre;
		if (usuario->Activos->Raiz != NULL) {
			id = usuario->Activos->Raiz->Id;

		}
		else
		{
			id = "";
		}
		while (aux != nullptr)
		{
			aux2 = aux->Abajo;
			while (aux2 != nullptr)
			{
				
				if (aux2->Nombre == name && aux2->Activos->Raiz->Id == id|| aux2->Activos->Raiz->Id == "0") {
					//es el mismo usuario que no haga nada
				}
				else {
					aux2->Activos->Inorden();
					if (aux2->Atras != nullptr) {
						aux3 = aux2->Atras;
						while (aux3 != nullptr) {
							if (aux3->Nombre == name && aux3->Activos->Raiz->Id == id || aux3->Activos->Raiz->Id == "0") {
								//es el mismo usuario que no haga nada
							}
							else {
								aux3->Activos->Inorden();
							}
							aux3 = aux3->Atras;
						}

					}
				}
				aux2 = aux2->Abajo;
			}
			aux = aux->Siguiente;
		}
	}
	else {
		//creamos los nodos
		string cabeD, cabeE, nodo,orden,contenido;

		aux = Cabecera;
		while (aux!=nullptr)
		{
			if (aux->Nombre == "Inicio") {
				cabeD = "nodoInicio [label=\"" + aux->Nombre + "\"];\n";
				rama = "{rank = same; nodoInicio;";
			}
			else
			{
				cabeD += "nodo"+aux->Nombre+"[label=\"" + aux->Nombre + "\"];\n";
				rama += "nodo" + aux->Nombre + "; ";
			}
			aux = aux->Siguiente;
		}
		rama += "}\n";
		aux = Cabecera->Abajo;
		while (aux != nullptr)
		{
			if (cabeE == "") {
				cabeE = "nodo" + aux->Nombre+ "[label=\"" + aux->Nombre + "\"];\n";
				
			}
			else
			{
				cabeE+= "nodo" + aux->Nombre + "[label=\"" + aux->Nombre + "\"];\n";
			}
		
			aux = aux->Abajo;
		}
		aux = Cabecera->Siguiente;
		Nodo* y ;
		while (aux != nullptr)
		{
			aux2 = aux->Abajo;
			while (aux2 != nullptr)
			{
				//poner aqui el dibujo de graphis
				y = aux2;
				while (y->Anterior!=nullptr)
				{
					y = y->Anterior;
				}
				
					if (aux2->Atras != nullptr) {
						if (nodo == "") {
							nodo = "nodo" + aux->Nombre + y->Nombre + "[label=\"" + aux2->Nombre + "\",color=green];\n";

						}
						else {
							nodo += "nodo" + aux->Nombre + y->Nombre + "[label=\"" + aux2->Nombre + "\",color=green];\n";
						}
					}
					else {
					
						if (nodo == "") {
							nodo = "nodo" + aux->Nombre + y->Nombre + "[label=\"" + aux2->Nombre + "\"];\n";

						}
						else {
							nodo += "nodo" + aux->Nombre + y->Nombre + "[label=\"" + aux2->Nombre + "\"];\n";
						}
					}
				aux2 = aux2->Abajo;
			}
			aux = aux->Siguiente;
		}

		//señalamientos de cabeceras x,y;
		aux = Cabecera;
		while (aux != nullptr)
		{
			
			if (aux->Siguiente != nullptr) {
				orden += "nodo" + aux->Nombre + "-> nodo" + aux->Siguiente->Nombre + " [dir=both];\n";
			}
				
			
			aux = aux->Siguiente;
		}
		aux = Cabecera;
		while (aux != nullptr)
		{
			
			if (aux->Abajo != nullptr) {
				orden += "nodo" + aux->Nombre + "-> nodo" + aux->Abajo->Nombre + " [dir=both];\n";
			}

			aux = aux->Abajo;
		}
		//señalo verticalmente 
		aux = Cabecera->Siguiente;
		string anterior = aux->Nombre;
		while (aux != nullptr)
		{
			anterior = aux->Nombre;
			aux2 = aux->Abajo;
			while (aux2 != nullptr)
			{
				//poner aqui el dibujo de graphis

				y = aux2;
				while (y->Anterior != nullptr)
				{
					y = y->Anterior;
				}
					orden += "nodo" + anterior + "->" + "nodo" + aux->Nombre + y->Nombre + "[dir=both];\n";	
					anterior = aux->Nombre + y->Nombre;
					
				aux2 = aux2->Abajo;
			}
			aux = aux->Siguiente;
			
		}
		//aqui señalamos horizontalmente
		aux = Cabecera->Abajo;
		 anterior = aux->Nombre;
		while (aux != nullptr)
		{
			anterior = aux->Nombre;
			rama += "{rank = same; nodo" + anterior+";";
			aux2 = aux->Siguiente;
			while (aux2 != nullptr)
			{
				//y se vuele x
				y = aux2;
				while (y->Arriba != nullptr)
				{
					y = y->Arriba;
				}
				orden += "nodo" + anterior + "->" + "nodo" + y->Nombre + aux->Nombre  + "[constraint=false,dir=both];\n";
				anterior = y->Nombre+aux->Nombre  ;
				rama += "nodo"+anterior + "; ";
			
				aux2 = aux2->Siguiente;
			}
			aux = aux->Abajo;
			
			rama += "}\n";
		}
		contenido = "rankdir = TB;\n node[shape = rectangle, color = blue, height = 0.5, width = 0.5];\n edge[color = red];graph[nodesep = 0.5];\n"+
			cabeD+cabeE+nodo+orden+rama;
		Dibujo(contenido);
	}
	

}
void Matriz::Dibujo(string contenido) {
	//C:\\Users\\José David\\Desktop\\
	
	ofstream archivo;
	archivo.open("Graficas\\Matriz.dot");
	archivo << "digraph G{\n\n";
	archivo << contenido + "\n";
	archivo << "}";
	archivo.close();
	system("dot -Tpng Graficas\\Matriz.dot -o Graficas\\MatrizDisperza.png");
}
void Matriz::BuscarID(string id,bool tipo) {
	//para la devolucion es lo mismo solo 
	//que con if mas de si es rentar o devolcio

	Nodo_Arbol* idB;
	Nodo* aux = Cabecera->Siguiente;
	Nodo* aux2;
	Nodo* aux3;
	Nodo* p=Cabecera;
	Nodo_Arbol* user;
	string d;
	while (aux != nullptr)
	{
		aux2 = aux->Abajo;
		while (aux2 != nullptr)
		{
				//aqui mandado el nodo Raiz ya que es un Nodo_Arbol
				user = aux2->Activos->Raiz;
				idB = p->Activos->Buscar(id,user);
				if (idB!=nullptr) {
					if (tipo==true) {
						cout << "El activo alquilado es\n";
						cout << "Id:" + idB->Id + " Nombre:" + idB->Nombre + " Descripcion:" + idB->des + "\n";
						cin >> d;
						idB->estado = false;
						break;
					}
					else {
						cout << "El activo que va devolver es";
						cout << "Id:" + idB->Id + " Nombre:" + idB->Nombre + " Descripcion:" + idB->des + "\n";
						
						idB->estado = true;
						break;
					}
					

				}
				if (aux2->Atras != nullptr) {
					aux3 = aux2->Atras;

					while (aux3 != nullptr) {
						//aqui mandado el nodo Raiz ya que es un Nodo_Arbol
						user = aux3->Activos->Raiz;
						idB = p->Activos->Buscar(id, user);
						if (idB != nullptr) {
							if (tipo == true) {
								cout << "El activo alquilado es";
								cout << "Id:" + idB->Id + " Nombre:" + idB->Nombre + " Descripcion:" + idB->des + "\n";
								idB->estado = false;
								
								break;
							}
							else {
								cout << "El activo que va devolver es";
								cout << "Id:" + idB->Id + " Nombre:" + idB->Nombre + " Descripcion:" + idB->des + "\n";
								
								idB->estado = true;
								
								break;
							}
						}
						aux3 = aux3->Atras;
					}
				}
			aux2 = aux2->Abajo;
		}
		aux = aux->Siguiente;
	}
	
}
void Matriz::Mostrar(string tipo) {
	Nodo* Inicio = Cabecera;
	int i = 1;
	if (tipo=="Dep") {
		Inicio = Inicio->Siguiente;
		while (Inicio!=nullptr)
		{
			cout << to_string(i) + "." + Inicio->Nombre + " ;  ";
			i++;
			Inicio = Inicio->Siguiente;
		}
	}
	else {
		Inicio = Inicio->Abajo;
		while (Inicio != nullptr)
		{
			cout << to_string(i) + "." + Inicio->Nombre + " ;  ";
			i++;
			Inicio = Inicio->Abajo;
		}
	}
	
}
void Matriz::Reporte(string tipo,string dato) {
	Nodo* Aux;
	Nodo* Aux2;
	Nodo* usuario;
	string contenido = " subgraph cluster_01 { label=\"Reporte de" + dato + "\";\n";

	if (tipo=="Dep") {
			Aux= BuscarDepartamento(dato, Cabecera)->Abajo;
			while (Aux!=nullptr) {
				contenido += "Usuario_" + Aux->Nombre + "\n";
				contenido += Aux->Activos->Reporte()+"\n";
				Aux2 = Aux;
				if (Aux2->Atras!=nullptr) {
					while (Aux2->Atras != nullptr)
					{
						contenido += "Usuario_" + Aux2->Nombre + "\n";
						contenido += Aux2->Activos->Reporte() + "\n";
						Aux2 = Aux2->Atras;
					}
				}
				Aux = Aux->Abajo;
			}
	}
	else {
		Aux = BuscarEmpresa(dato, Cabecera)->Siguiente;
		while (Aux != nullptr) {
			contenido += "Usuario_" + Aux->Nombre + "\n";
			contenido += Aux->Activos->Reporte() + "\n";
			Aux2 = Aux;
			if (Aux2->Atras != nullptr) {
				while (Aux2->Atras != nullptr)
				{
					contenido += "Usuario_" + Aux2->Nombre + "\n";
					contenido += Aux2->Activos->Reporte() + "\n";
					Aux2 = Aux2->Atras;
				}
			}
			Aux = Aux->Siguiente;
		}
	}
	contenido+="}";
	ofstream archivo;
	archivo.open("Graficas\\Reporte"+tipo+".dot");
	archivo << "digraph G{\n\n";
	archivo << contenido + "\n";
	archivo << "}";
	archivo.close();
	string name = "Reporte"+tipo+".dot";
	string v = "dot -Tpng Graficas\\" + name + " -o Graficas\\Reporte"+tipo+".png";
	system(v.c_str());
}
Matriz::~Matriz()
{
}
