#include "stdafx.h"
#include "Menu_.h"
#include <iostream>;
#include <string>;
#include <cstdlib>;
#include "Matriz.h";
#include "ListaDoble.h";
#include <time.h>
#define _CRT_SECURE_NO_WARNINGS


void Menu_::Loguin() {
	string User = "";
	string Pass = "";
	string Dep = "";
	string Emp = "";
	cout << "--------Renta de Actvos--------\n";
	cout << "--------Usuario--------\n";
	cin >> User;
	cout << "--------Contraseña--------\n";
	cin >> Pass;
	cout << "-------- Departamento--------\n";
	cin >> Dep;
	cout << "-------- Empresa--------\n";
	cin >> Emp;

	if (User == "admin" && Pass == "admin" ) {
		system("cls");
		Menu_Admin();
	}
	else {
		//aqui poner el login;
		if (!M->Login(Dep,Emp,User,Pass)) {
			system("cls");
			cout << "Contraseña o Usuario incorrecto\n";
			cin >> Emp;
		}
		else {
			system("cls");
			
			Menu_Principal(User,Emp,Dep);
		}
		system("cls");
		Loguin();
	}
}
void Menu_::Menu_Admin()
{
	int dato ;
	cin.clear();
	do {
		system("cls");
		cout << "--------Menu Principal Administrador--------" << endl;
		cout << "--1.Registrar Usuario-----------------------" << endl;
		cout << "--2.Reporte Matriz Dispersa-----------------" << endl;
		cout << "--3.Reporte Activos Disponibles de un Departamento-------------" << endl;
		cout << "--4.Reporte Activos Disponibles de una Empresa -------------" << endl;
		cout << "--5.Reporte Transacciones------------" << endl;
		cout << "--6.Reporte Activos de un Usuario------------" << endl;
		cout << "--7.Activos rentados por un Usuario------------" << endl;
		cout << "--8.Ordenar Transacciones------------" << endl;
		cout << "--9.Salir------------" << endl << endl;

		cout << ">> elija una opcion:\n";

		cin >> dato;

		if (dato == 9) {
			system("cls");
			Loguin();
		}
		else {
			system("cls");
			Sub_MenuAd(dato);
			cin.clear();
		}

	}while(dato!=9);
}
void Menu_::Menu_Principal(string User,string emp,string de)
{
	int dato = 0;
	
		do {
			system("cls");
			cout << "-----------Menu Principal-----------" << endl;
			cout << "---" << User << "---" << emp << "----" << de << "---" << endl;
			cout << "---1.Agregar Activo-----------------" << endl;
			cout << "---2.Eliminar Activo----------------" << endl;
			cout << "---3.Modificar Activo---------------" << endl;
			cout << "---4.Rentar Activo------------------" << endl;
			cout << "---5.Activos Rentados---------------" << endl;
			cout << "---6.Mis Activos Rentados-----------" << endl;
			cout << "---7.Salir--------------------------\n" << endl;
			cout << "elija una opcion:";
			cin >> dato;
			if (dato == 7) {
				system("cls");
				Loguin();
			}
			else {
				Sub_Menu(dato, User, emp, de);
			}
		} while (dato != 7);

		
	

}
void Menu_::Sub_Menu(int dato1, string User, string emp, string de) {
	int dato = dato1;
	string nombre = "";
	string des = "";
	string id = "";
	string op = "";
	string Ndes = "";
	string estado = "";
	Nodo* d = M->Buscar(User, emp, de);	
	string lista = "";
	string idactvidad;
	string tiempo;
	system("cls");
	switch (dato)
	{
	case 1:
		
		id = IDRandom();
		cout << "-----------Agregar Activo-----------" << endl;
		cout << "--Ingresar Nombre:" << endl;
		cout << "--";
		cin>>nombre;
		cout<<endl;
		cout << "--Ingresar Descripcion:" << endl;
		cout << "--";
		cin>>des;
		d->Activos->Insertar(nombre, des, id);
		break;
	case 2:
		cout << "-----------Eliminar Activo-----------" << endl;
		//saca la lista de los activos
		d->Activos->Inorden();
		cout << "Ingresar el ID de Activo a Eliminar:"<<endl;
		cout << "--";
		cin>>op;
		d->Activos->Eliminar(op);
		//eliminar de la lista
		break;
	case 3:
		cout << "-----------Modificar Activo-----------" << endl;
		//sacar la lista de activos otra vez
		d->Activos->Inorden();
		cout << "Ingresar el ID de Antivo a Modificar" << endl;
		cout << "--";
		cin>>op;
		cout << "Ingresar la descripcion nueva" << endl;
		cout << "--";
		cin>>Ndes;
		cout << "Ingresar el estado nuev" << endl;
		cout << "--";
		cin >> estado;
		d->Activos->Modificar(op,Ndes,estado);
		break;
	case 4:
		cout << "-----------Catalogo de Activos----------" << endl;
		M->Catalogo(d,false);
		cout << "---1. Para rentar activo----------" << endl;
		cout << "---2. Regresar al menuPrincipal----------" << endl;
		cin >> op;
		if (op=="1") {
			idactvidad = IDRandom();
			cout << "Ingresar el id del activo a alquilar" << endl;
			cout << "--";
			cin >> id;
			cout << "Ingresar cuantos dias lo alquilara" << endl;
			cout << "--";
			cin>>tiempo;
			M->BuscarID(id, true);
			Transacciones->Insertar(idactvidad, id, User, emp, de, "Fechahora()",tiempo, "Rentado");
		}

		break;
	case 5:
		cout << "-----------Activos Rentados----------" << endl;
		Transacciones->Mostrar("",User, emp, de,"Rentado");
		// mostrar ya sea la lista de activos o el arbol nose todavia 
		cout << "---1. Para devolver activos activo----------" << endl;
		cout << "---2. Regresar al menuPrincipal----------" << endl;
		cin>> op;
		if (op == "1") {
			idactvidad = IDRandom();
			cout << "Ingresar el id del activo a devolver" << endl;
			cout << "--";
			cin>>id;
			M->BuscarID(id,false);
			Transacciones->Insertar(idactvidad, id, User, emp, de,"Fechahora()", tiempo, "Devuelto");
			//cambiar el estado a activo
		}
		break;
	case 6:
		cout << "-----------Activos en Renta----------" << endl;
		d->Activos->orden();
		cout << "---1. Para regresar----------" << endl;
		cout << "--";
		cin>>id;
		break;

	}
	Menu_Principal(User,emp,de);
}
void Menu_::Sub_MenuAd(int d) {
	int Opcio = d;
	string Usuario = "";
	string contraseña= "";
	string departamento = "";
	string empresa = "";
	string NombreC = "";
	
	string op = "0";
	switch (Opcio)
	{
	case 1:
		cout << "-----------Agregar Usuario-----------" << endl;
		cout << "--Ingresar Nombre Usuario:" << endl;
		cout << "--";
		cin >> Usuario;
		cout << "--Ingresar Contraseña:" << endl;
		cout << "--";
		cin>>contraseña;
		cout << "--Ingresar Departamento:" << endl;
		cout << "--";
		cin>>departamento;
		cout << "--Ingresar empresa:" << endl;
		cout << "--";
		cin>>empresa;
		cout << "--Ingresar Nombre Completo:" << endl;
		cout << "--";
		cin>>NombreC;
		M->InsertarElemento(Usuario,empresa,departamento,contraseña,NombreC);
		cout << "--Operacion completa" << endl;
		cout << "--";
		cin>>op;
		system("cls");
		break;
	case 2:
		cout << "-----------Reporte Matriz Dispersa-----------" << endl;
		//saca el reporte
		M->Catalogo(nullptr,true);
		cout << "Presione cualquier tecla para continuar:" << endl;
		cout << "--";
		cin >> op;
		
		break;
	case 3:
		cout << "-----------Reporte Activos Usuarios por Departamento-----------" << endl;
		//sacar la lista de activos otra vez
		M->Mostrar("Dep");
		cout << "\nIngresar el numero del departamento que quiera ver" << endl;
		cout << "--";
		cin >> departamento;
		M->Reporte("Dep", departamento);
		cout << "Presione cualquier tecla para continuar:" << endl;
		cout << "--";
		cin >> op;
		break;
	case 4:
		cout << "-----------Reporte Activos de Usuarios por Empresa-----------" << endl;
		//sacar la lista de activos otra vez
		M->Mostrar("Emp");
		cout << "\nIngresar el numero de la empresa que quiera ver" << endl;
		cout << "--";
		cin >> empresa;
		M->Reporte("Emp", empresa);
		cout << "Presione cualquier tecla para continuar:" << endl;
		cout << "--";
		cin >> op;
		break;
	case 5:
		cout << "-----------Reporte Transacciones-----------" << endl;
		//sacar la lista de activos otra vez
		Transacciones->Reporte(true);
		cout << "Reporte generado" << endl;
		cout << "--";
		cin >> op;

		break;
	case 6:
		Nodo* nodousuario;
		cout << "-----------Reporte Activos de un Usuarios-----------" << endl;
		M->Mostrar(); 
		cout << "Ingresar el nombre del usuario a elegir" << endl;
		cout << "--";
		cin >> Usuario;
		cout << "Ingresar el nombre del departamento del usuario elegido" << endl;
		cout << "--";
		cin >> departamento;
		cout << "Ingresar el nombre de la empresa del usuario elegido" << endl;
		cout << "--";
		cin >> empresa;
		nodousuario=M->Buscar(Usuario, empresa, departamento);
		nodousuario->Activos->Obtener_Arbol();
		cout << "Reporte Generado presione cualquier tecla para continuar" << endl;
		cout << "--";
		cin>> op;
		break;
	case 7:
		cout << "-----------Reporte Activos rentados de Usuarios-----------" << endl;
		//sacar la lista de activos otra vez
		Transacciones->Mostrar();
		cout << "Ingrese cualquier tecla para continuar" << endl;
		cout << "--";
		cin>>op;
		break;
	case 8:
		cout << "-----------Ordenar Transacciones-----------" << endl;
		//sacar la lista de activos otra vez
		cout << "1. Para ordenar el reporte ascendentemente" << endl;
		cout << "2. Para ordenar el reporte descendentemente" << endl;
		cout << "--";
		cin >> op;
		if (op=="1") {
			Transacciones->Reporte(true);
		}
		else {
			Transacciones->Reporte(false);
		}
		
		break;
	
	}

	Menu_Admin();
}
string Menu_::IDRandom() {

	string id = "";
	string abc[37] = { "0","1","2","3","4","5","6","7","8","9","a","b","c","d",
		"e","f","g","h","i","j","k","l","m","n","ñ","o","p","q",
		"r","s","t","u","v","w","x","y","z" };
	int numero;
	for (int i = 0; i < 15; i++) {
		numero = (rand() % 37);
		if (id == "") {
			id = abc[numero];
		}
		else {
			id += abc[numero];
		}
	}
	//antes de crear el nodo en la lista crear el metodo de buscar si es falso lo ingrese si es verdadero que se llame otra ves
	if (ListaId->Primero!=nullptr) {
		if (!ListaId->BuscarID(id)) {
			ListaId->Insertar(id);
			return id;
		}
		else {
			IDRandom();
			
		}
	}
	else {
		ListaId->Insertar(id);
		return id;
	}
	
	
	//cout << "el id:" << id << endl;

}
string Menu_::Fechahora() {
	/*string fecha;
	time_t ahora = time(0);
	char* dt = ctime(&ahora);
	fecha = dt; 
	return fecha;*/
	time_t     now = time(0);
	struct tm * nose=nullptr;
	char       buf[80];
	localtime_s(nose,&now);
	strftime(buf, sizeof(buf), "%Y-%m-%d", nose);

	return buf;
}
Menu_::~Menu_()
{
}
