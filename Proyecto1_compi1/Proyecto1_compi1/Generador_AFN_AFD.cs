using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_compi1
{
    class Generador_AFN_AFD
    {

        public List<string> Expresiones = new List<string>();
        public List<string> Expresionesnormal = new List<string>();
        public List<string> conjuntos = new List<string>();
        public List<string> tabla_simbolos = new List<string>();
        public List<string> d = new List<string>();
        private int rep=-1;
        private string loq ="";
        public string nombres;
        public void Lista(List<string> Lista_Tokens) {
            tabla_simbolos = Lista_Tokens;
            exp();
            conjunto();
            Console.WriteLine("estas son las expresiones");
            for (int i = 0; i < Expresiones.Count(); i++) {
                Console.WriteLine(Expresiones[i]);
                string[] der = Expresiones[i].Split('@');
                if (nombres == "")
                {
                   
                    nombres = der[0];
                }
                else { nombres += ","+ der[0]; }
            }
            Console.WriteLine("estas son los conjuntos");
            for (int i = 0; i < conjuntos.Count(); i++) {
                Console.WriteLine(conjuntos[i]);
            }
            Pol();
        }
        public string getname() {
            return nombres;
        }
        public void exp() {
            string er = "";
            int sigue=0;
            int con = 0;
            for (int i = 0; i < tabla_simbolos.Count; i++)
            {
                string[] lista = tabla_simbolos[i].Split('@');
                if (lista[1] == "tk_conjunto")
                {
                    con = 1;
                }
                else if (lista[1] == "tk_puntocoma")
                {
                    con = 0;
                }
                if (lista[1] == "tk_cadena")
                {
                    er = lista[0];
                    sigue = 1;
                } else if (lista[1] == "tk_indicador" && sigue == 1 && con == 0) {
                    for (int m = i+1; m < tabla_simbolos.Count; m++)
                    {
                        lista = tabla_simbolos[m].Split('@');
                        if (lista[1]== "tk_puntocoma")
                        {
                            sigue = 0;
                            con = 0;
                            break;
                        }
                        else if(lista[1] == "tk_comilladoble")
                        {

                        }
                        else {
                            er += "@" + lista[0]+"@"+lista[1];
                        }
                    }
                    Expresiones.Add(er);
                 
                }
                
            }
        }
        public void conjunto()
        {
            string er = "";
            int sigue = 0;
            for (int i = 0; i < tabla_simbolos.Count; i++)
            {
                string[] lista = tabla_simbolos[i].Split('@');
                if (lista[1] == "tk_conjunto")
                {
                   
                    sigue = 1;
                }
                if (lista[1] == "tk_cadena" && sigue == 1)
                {
                    er = lista[0];
                    sigue++; 
                }
                if (lista[1]=="tk_indicador"&&sigue==2) {
                    int comas = 0;
                    int virgulia = 0;
                    for (int m = i+1; m < tabla_simbolos.Count; m++)
                    {
                        lista = tabla_simbolos[m].Split('@');
                        if (lista[1] == "tk_puntocoma")
                        {
                            break;
                        }
                        else
                        {
                            if (lista[1] == "tk_coma") {
                                comas++;
                            }
                            if (lista[1] == "tk_virgulia") {
                                virgulia++;
                            }
                            er += "@" + lista[0];
                        }
                    }

                    if (comas > 0) {

                        conjuntoex(er,0);
                    } else if (virgulia>0) {
                        conjuntoex(er, 1);
                    }
                }

            }
        }
        private void  conjuntoex(string datos,int tipo) {
            string[] dato = datos.Split('@');
            string expandido = "";
            int max = dato.Length-1;
            if (tipo == 0)
            {
                conjuntos.Add(datos);
            }
            else {
                expandido = dato[0];
                for (int i= Encoding.ASCII.GetBytes(dato[1])[0];i<= Encoding.ASCII.GetBytes(dato[max])[0];i++) {
                    expandido+="@"+Convert.ToChar(i).ToString();
                }
                conjuntos.Add(expandido);
            }
        }

        private void Pol() {
            int contador = 1;
            string etotal = "";
            string e = "";
            string exp2 = "";
            int bandera = 0;
            string nombre = "";
            for (int i=0; i<Expresiones.Count;i++) {
                
                int max = maximo(i);
                int conta = 0;
             
                while (conta<max) {
                    string[] exprecion ;
                    //un if de cambio de expresion cuando algo haga mach
                    if (etotal == "" &&conta==0)
                    {
                        exprecion = Expresiones[i].Split('@');
                        nombre = exprecion[0];
                    }
                    else {
                      
                        exprecion = etotal.Split('@');
                        exp2 = etotal;
                    }
              
                    if (exprecion[contador + 1] == "tk_concatenacion" || exprecion[contador + 1] == "tk_or")
                    {
                                              
                        if (exprecion[contador + 3] == "tk_concatenacion" || exprecion[contador + 3] == "tk_or" ||
                            exprecion[contador + 3] == "tk_masveces" || exprecion[contador + 3] == "tk_ceromasveces" ||
                            exprecion[contador + 3] == "tk_interrogacion")
                        {
                            
                            contador=contador+2;
                        }
                        else
                        {
                        

                            if (exprecion[contador + 5] == "tk_concatenacion" || exprecion[contador + 5] == "tk_or" ||
                                exprecion[contador + 5] == "tk_masveces" || exprecion[contador + 5] == "tk_ceromasveces" ||
                                exprecion[contador + 5] == "tk_interrogacion")
                            {
                                
                                contador = contador + 2;
                            }
                            else
                            {

                                e = "@" + exprecion[contador + 2] + exprecion[contador]+ exprecion[contador + 4]+"@tk_cadena";
                              
                             
                                // mach
                                if (contador + 6 < exprecion.Length)
                                {
                                    bandera = 1;
                                    if (etotal == "")
                                    {
                                        etotal = Loquetenia(contador, i);
                                    }
                                    else { 
                                
                                        etotal = Loquetenia3(contador,etotal);
                                    }
                                
                                    etotal += e;
                                    if (exp2 == "")
                                    {
                                  
                                        etotal += Loquetenia2(contador + 6, i, exprecion.Length,"");
                                    }
                                    else {
                               
                                        etotal += Loquetenia2(contador + 6, i, exprecion.Length, exp2);
                                    }
                                   
                             
                               
                                    e = "";
                                    contador = 0;
                                    conta++;
                                }
                                else
                                {
                                    etotal = Loquetenia(contador, i);
                                    etotal += e;
                        
                                    e = "";
                                    contador = 0;
                                    conta++;
                                }
                                
                            }
                        }

                    }
                    else if (exprecion[contador + 1] == "tk_masveces" || exprecion[contador + 1] == "tk_ceromasveces" ||
                    exprecion[contador + 1] == "tk_interrogacion")
                    {
                        
                        if (exprecion[contador + 3] == "tk_concatenacion" || exprecion[contador + 3] == "tk_or" ||
                            exprecion[contador + 3] == "tk_masveces" || exprecion[contador + 3] == "tk_ceromasveces" ||
                            exprecion[contador + 3] == "tk_interrogacion")
                        {
                                  
                            contador = contador + 2;
                        }
                        else
                        {

                            e = "@(" + exprecion[contador + 2] +")"+ exprecion[contador]+ "@tk_cadena";
                           
                       
                            if (contador + 6 < exprecion.Length)
                            {
                                if (etotal=="") {
                                    etotal = Loquetenia(contador, i);
                                } else {
                                    etotal = Loquetenia3(contador, etotal);
                                }
                                
                                etotal += e;
                                if (exp2 == "")
                                {
                                    etotal += Loquetenia2(contador + 4, i, exprecion.Length,"");
                                }
                                else
                                {
                                    etotal += Loquetenia2(contador + 4, i, exprecion.Length,exp2);
                                }
                      
                                e = "";
                                contador = 0;
                                conta++;
                                bandera = 1;
                            }
                            else
                            {

                                if (bandera == 0)
                                {
                                       etotal = Loquetenia(contador, i);
                                }
                                else {
                                    etotal = Loquetenia3(contador, exp2);
                                }
                               
                                etotal += e;
                           

                                e = "";
                                contador = 0;
                                conta++;
                            }
                        }


                    }
                    else {
                        contador = contador + 2;
                    }
                }
                //miremos como queda porque tenes que hacer que el nach realice las cosas esas
                Console.WriteLine("la expression es: "+etotal);
                Expresionesnormal.Add(etotal);
                etotal = "";
                e = "";
                exp2 = "";
                contador = 1;
                bandera = 0;
                rep = -1;
                AFN(nombre);
            }
            

        }
        private void AFN(string name) {
            for (int i=0; i<Expresionesnormal.Count; i++) {
                string[] datos = Expresionesnormal[i].Split('@');
                char[] exp = datos[1].ToCharArray();
              
                List<string> letras = new List<string>();
                string d = "";
                int bandera = 0;
                int inicio0 = 0,fin0=0;
                for (int j=0;j< exp.Length;j++) {
                    if (exp[j]=='|' || exp[j] == '+'|| exp[j] == '.'|| exp[j] == '*'
                        || exp[j] == '?' || exp[j] == '(' || exp[j] == ')') {

                        if (d=="") {
                            letras.Add(exp[j]+"");
                        } else {
                            if (exp[j] == '(' || exp[j] == ')')
                            {
                            
                                letras.Add(d);
                                letras.Add(exp[j] + "");
                                d = "";
                            }
                            else {
                          
                                letras.Add(d);
                                letras.Add(exp[j] + "");
                                d = "";
                            }
                           
                        }

                        if (exp[j] == '|') { bandera++; }
                    } else {
                        d += exp[j];
                    }

                }
             
                string dibujo = "";
           
                int contador = 1;
                int inicio = 0, fin=0 ;
                int rep = 1;
                int m2 = 0;
                for (int m = 0; m < letras.Count; m++) {
                    if (letras[m] == "." || letras[m] == "|")
                    {
                        if (letras[m] == ".")
                        {
                            if (dibujo == "")
                            {
                               
                                dibujo = "\""+contador + "\"->\"" + (contador + 1) + "\"[label=\""+ verificar(letras, letras[m - 1], (m - 1), '-') + "\"] \n";
                                dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 2) + "\"[label=\"" + verificar(letras, letras[m + 1], (m + 1), '+') + "\"]  \n";
                                inicio = contador + 2;
                                fin = contador + 2;
                            }
                            else
                            {
                                contador = fin;
                                dibujo += "\"" + contador + "\"->\"" + (contador + 1) + "\"[label=\"" + verificar(letras, letras[m - 1], (m - 1), '-') + "\"] \n";
                                dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 2) + "\"[label=\"" + verificar(letras, letras[m + 1], (m + 1), '+') + "\"] \n";
                                inicio = contador + 1;
                                fin = contador + 2;
                            }

                        }
                        else if(letras[m] == "|")
                        {
                            if (bandera == 1)
                            {
                                if (dibujo == "")
                                {
                                    contador = inicio;

                                    dibujo = "\"" + contador + "\"->\"" + (contador + 1) + "\"[label=\"E\"] \n";
                                    dibujo += "\"" + contador + "\"->\"" + (contador + 5) + "\"[label=\"E\"] \n";
                                    dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 2) + "\"[label=\"" + verificar(letras, letras[m - 1], (m - 1), '-') + "\"] \n";
                                    dibujo += "\"" + (contador + 3) + "\"->\"" + (contador + 4) + "\"[label=\"E\"] \n";
                                    dibujo += "\"" + (contador + 5) + "\"->\"" + (contador + 6) + "\"[label=\"" + verificar(letras, letras[m + 1], (m + 1), '+') + "\"] \n";
                                    dibujo += "\"" + (contador + 6) + "\"->\"" + (contador + 4) + "\"[label=\"E\"] \n";
                                    fin = contador + 6;
                                    inicio = contador + 4;
                                    contador = fin;
                                }
                                else
                                {
                                    contador = inicio;

                                    dibujo += "\"" + contador + "\"->\"" + (contador + 1) + "\"[label=\"E\"] \n";
                                    dibujo += "\"" + contador + "\"->\"" + (contador + 5) + "\"[label=\"E\"] \n";
                                    dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 2) + "\"[label=\"" + verificar(letras, letras[m - 1], (m - 1), '-') + "\"] \n";
                                    dibujo += "\"" + (contador + 3) + "\"->\"" + (contador + 4) + "\"[label=\"E\"] \n";
                                    dibujo += "\"" + (contador + 5) + "\"->\"" + (contador + 6) + "\"[label=\"" + verificar(letras, letras[m + 1], (m + 1), '+') + "\"] \n";
                                    dibujo += "\"" + (contador + 6) + "\"->\"" + (contador + 4) + "\"[label=\"E\"] \n";
                                    fin = contador + 6;
                                    inicio = contador + 4;
                                    contador = fin;
                                }
                            }
                            else if (bandera == 2)
                            {
                                if (dibujo == "")
                                {
                                    if (rep == 1)
                                    {
                                        contador = inicio;

                                        dibujo = "\"" + contador + "\"->\"" + (contador + 1) + "\"[label=\"E\"]\n";
                                        dibujo += "\"" + contador + "\"->\"" + (contador + 7) + "\"[label=\"E\"]\n";
                                        dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 2) + "\"[label=\"E\"]\n";
                                        dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 5) + "\"[label=\"E\"]\n";
                                        dibujo += "\"" + (contador + 2) + "\"->\"" + (contador + 3) + "\"[label=\"" + verificar(letras, letras[m - 1], (m - 1), '-') + "\"]\n";
                                        dibujo += "\"" + (contador + 3) + "\"->\"" + (contador + 4) + "\"[label=\"E\"]\n";
                                        dibujo += "\"" + (contador + 5) + "\"->\"" + (contador + 6) + "\"[label=\"" + verificar(letras, letras[m + 1], (m + 1), '+') + "\"]\n";
                                        dibujo += "\"" + (contador + 6) + "\"->\"" + (contador + 4) + "\"[label=\"E\"]\n";
                                        rep++;

                                    }
                                    else
                                    {
                                        dibujo += "\"" + (contador + 4) + "\"->\"" + (contador + 9) + "\"[label=\"E\"] \n";
                                        dibujo += "\"" + (contador + 7) + "\"->\"" + (contador + 8) + "\"[label=\"" + verificar(letras, letras[m + 1], (m + 1), '+') + "\"]\n";
                                        dibujo += "\"" + (contador + 8) + "\"->\"" + (contador + 9) + "\"[label=\"E\"]\n";

                                        inicio = contador + 9;
                                        fin = contador + 9;
                                    }

                                }
                                else
                                {
                                    if (rep == 1)
                                    {
                                        contador = inicio;

                                        dibujo += "\"" + contador + "\"->\"" + (contador + 1) + "\"[label=\"E\"]\n";
                                        dibujo += "\"" + contador + "\"->\"" + (contador + 7) + "\"[label=\"E\"]\n";
                                        dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 2) + "\"[label=\"E\"]\n";
                                        dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 5) + "\"[label=\"E\"]\n";
                                        dibujo += "\"" + (contador + 2) + "\"->\"" + (contador + 3) + "\"[label=\"" + verificar(letras, letras[m - 1], (m - 1), '-') + "\"]\n";
                                        dibujo += "\"" + (contador + 3) + "\"->\"" + (contador + 4) + "\"[label=\"E\"]\n";
                                        dibujo += "\"" + (contador + 5) + "\"->\"" + (contador + 6) + "\"[label=\"" + verificar(letras, letras[m + 1], (m + 1), '+') + "\"]\n";
                                        dibujo += "\"" + (contador + 6) + "\"->\"" + (contador + 4) + "\"[label=\"E\"]\n";
                                        rep++;

                                    }
                                    else
                                    {
                                        dibujo += "\"" + (contador + 4) + "\"->\"" + (contador + 9) + "\"[label=\"E\"] \n";
                                        dibujo += "\"" + (contador + 7) + "\"->\"" + (contador + 8) + "\"[label=\"" + verificar(letras, letras[m + 1], (m + 1), '+') + "\"]\n";
                                        dibujo += "\"" + (contador + 8) + "\"->\"" + (contador + 9) + "\"[label=\"E\"]\n";

                                        inicio = contador + 9;
                                        fin = contador + 9;
                                    }

                                }

                            }

                            }
                      
                    }
                    else if (letras[m] == "*")
                    {
                        if (dibujo == "")
                        {
                            contador = fin;
             
                            dibujo = "\"" + contador + "\"->\"" + (contador + 1) + "\"[label=\"E\"] \n";
                            dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 2) + "\"[label=\""+ verificar(letras, letras[m-1],(m-1),'-')+"\"] \n";
                            dibujo += "\"" + (contador + 2) + "\"->\"" + (contador + 1) + "\"[label=\"E\"] \n";
                            dibujo += "\"" + (contador + 2) + "\"->\"" + (contador + 3) + "\"[label=\"E\"] \n";
                            dibujo += "\""+contador + "\"->\"" + (contador + 3) + "\"[label=\"E\"] \n";

                        }
                        else
                        {
                            contador = fin;

                            dibujo += "\"" + contador + "\"->\"" + (contador + 1) + "\"[label=\"E\"] \n";
                            dibujo += "\"" + contador + "\"->\"" + inicio0 + "\"[label=\""+ verificar(letras, letras[m-1],(m-1),'-')+"\"] \n";
                            dibujo += "\"" + (inicio0-1) + "\"->\"" + (contador + 1) + "\"[label=\"E\"] \n";
                            if (inicio0==1) {
                                dibujo += "\"" + (inicio0-1) + "\"->\"" + (inicio0) + "\"[label=\"E\"] \n";
                            }
                           // 
                            inicio = contador + 1;
                            fin = contador+1;
                           
                        }
                      
                    } else if (letras[m] == "+") {
                        if (dibujo == "")
                        {
                            contador = inicio;
                   
                            dibujo = "\""+contador + "\"->\"" + (contador + 1) + "\"[label=\"E\"] \n";
                            dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 2) + "\"[label=\"" + verificar(letras, letras[m - 1], (m - 1), '-') + "\"] \n";
                            dibujo += "\"" + (contador + 2) + "\"->\"" + (contador + 1) + "\"[label=\"E\"] \n";
                            dibujo += "\"" + (contador + 2) + "\"->\"" + (contador + 3) + "\"[label=\"E\"] \n";
                          

                        }
                        else
                        {
                            contador = inicio;
                       
                            dibujo += "\"" + (contador+1) + "\"->\"" + (contador+2) + "\"[label=\""+ verificar(letras, letras[m-1],(m-1),'-')+"\"] \n";
                            dibujo += "\"" + (contador-1) + "\"->\"" + (contador+2) + "\"[label=\"E\"] \n";
                            dibujo += "\"" +  (inicio0 +1)+ "\"->\"" + contador + "\"[label=\"E\"] \n";
                            //dibujo += "\"" + (contador+1) + "\"->\"" + inicio0 + "\"\n";
                        }
                    }
                    else if (letras[m] == "(") { inicio0 = inicio;
                        
                        if (letras[m+2]=="."&& letras[m + 4] == "|" && letras[m + 6] == ".") {
                            if (dibujo == "")
                            {
                                inicio0 = contador;
                                dibujo = "\"" + contador + "\"->\"" + (contador + 1) + "\"[label=\"E\"] \n";
                                dibujo += "\"" + contador + "\"->\"" + (contador + 4) + "\"[label=\"E\"] \n";
                                dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 2) + "\"[label=\"" + verificar(letras, letras[m + 1], (m + 1), '+') + "\"] \n";
                                dibujo += "\"" + (contador + 4) + "\"->\"" + (contador + 5) + "\"[label=\"" + verificar(letras, letras[m + 5], (m + 5), '+') + "\"] \n";
                                dibujo += "\"" + (contador + 5) + "\"->\"" + (contador + 6) + "\"[label=\"" + verificar(letras, letras[m + 7], (m + 7), '+') + "\"] \n";
                                dibujo += "\"" + (contador + 2) + "\"->\"" + (contador + 3) + "\"[label=\"" + verificar(letras, letras[m + 3], (m + 3), '+') + "\"] \n";
                                dibujo += "\"" + (contador + 6) + "\"->\"" + (contador + 7) + "\"[label=\"E\"] \n";
                                dibujo += "\"" + (contador + 3) + "\"->\"" + (contador + 7) + "\"[label=\"E\"] \n";
                                fin = contador + 7;
                                inicio = contador;
                                contador = fin;
                                m += 6;
                            }
                            else {
                                dibujo += "\"" + contador + "\"->\"" + (contador + 1) + "\"[label=\"E\"] \n";
                                dibujo += "\"" + contador + "\"->\"" + (contador + 4) + "\"[label=\"E\"] \n";
                                dibujo += "\"" + (contador + 1) + "\"->\"" + (contador + 2) + "\"[label=\"" + verificar(letras, letras[m + 1],(m+1),'+' )+ "\"] \n";
                                dibujo += "\"" + (contador + 4) + "\"->\"" + (contador + 5) + "\"[label=\"" + verificar(letras, letras[m + 5],(m+5),'+' )+ "\"] \n";
                                dibujo += "\"" + (contador + 5) + "\"->\"" + (contador + 6) + "\"[label=\"" + verificar(letras, letras[m + 7],(m+7),'+') + "\"] \n";
                                dibujo += "\"" + (contador + 2) + "\"->\"" + (contador + 3) + "\"[label=\"" + verificar(letras,letras[m + 3],(m+3),'+')+ "\"] \n";
                                dibujo += "\"" + (contador + 6) + "\"->\"" + (contador + 7) + "\"[label=\"E\"] \n";
                                dibujo += "\"" + (contador + 3) + "\"->\"" + (contador + 7) + "\"[label=\"E\"] \n";
                                fin = contador + 7;
                                inicio = contador;
                                contador = fin;
                                m += 6;
                            }
                        }
                    }
                    else if (letras[m] == ")") { fin0 = fin;  }
                    m2++;
                }
                Console.WriteLine(name+"vamos a probar  \n"+dibujo);
                Dibujo_Dot archivod = new Dibujo_Dot();
                archivod.Archivo(dibujo, name);
            }

        }
        private string verificar(List<string> letras,string l,int i, Char p) {
            //aqui necesito el listado, el contador el caracter y para donde me dirijo
            string letra=l;

            
                if (l == "(" || l == ")" || l == "|" || l == "+" || l == "*" || l == "?" || l == ".")
                {

                letra = "E";

                }
                else {
                    
                }
              
            
           
            return letra;
        }
        private string Loquetenia3(int contador, string lista)
        {
            string e = "";
            string[] datos = lista.Split('@');
            e = datos[0];
            for (int j = 1; j < contador; j++)
            {
                if (j == contador)
                {
                    if (datos[j] == "tk_concatenacion" || datos[j] == "tk_or" ||
                            datos[j] == "tk_masveces" || datos[j] == "tk_ceromasveces" ||
                           datos[j] == "tk_interrogacion" || datos[j] == "tk_cadena")
                    {
                        e += "@" + datos[j];
                    }
                    else { break; }

                }
                else
                {
                    e += "@" + datos[j];
                }

            }
         
            return e;
        }
        private string Loquetenia2(int contador, int i,int hasta,string exp) {
            string e = "";
            string[] datos;
           
            //cambiar Expresiones
            if (exp=="") {  datos = Expresiones[i].Split('@'); } else {  datos = exp.Split('@'); }
         
            
            for (int j = contador; j <datos.Length ; j++)
            {
                if (j == hasta)
                {
                    if (datos[j] == "tk_concatenacion" || datos[j] == "tk_or" ||
                            datos[j] == "tk_masveces" || datos[j] == "tk_ceromasveces" ||
                           datos[j] == "tk_interrogacion" || datos[j] == "tk_cadena")
                    {
                        e += "@" + datos[j];
                    }
                    else { break; }

                }
                else
                {
                     e += "@" + datos[j]; 
                  
                }

            }
           
            return e;
        }
        private string Loquetenia(int contador,int i)
        {
            string e="";
            string[] datos = Expresiones[i].Split('@');
            e = datos[1];
            for (int j = 2; j <= contador; j++) {
                if (j == contador) {
                    if (datos[j] == "tk_concatenacion" || datos[j] == "tk_or" ||
                            datos[j] == "tk_masveces" || datos[j] == "tk_ceromasveces" ||
                           datos[j] == "tk_interrogacion" || datos[j]== "tk_cadena")
                    {
                        e += "@" + datos[j];
                    }
                    else { break; }

                } else {
                    e += "@" + datos[j];
                }
                
            }
          
            return e;
        }

        private int maximo(int i) {
            int m = 0;
            int contador = i;
            string[] d = Expresiones[i].Split('@');
            for (int j=0; j<d.Length;j++) {
                
                if (d[j] == "tk_concatenacion" || d[j] == "tk_or" ||
                            d[j] == "tk_masveces" || d[j] == "tk_ceromasveces" ||
                            d[j] == "tk_interrogacion")
                {
                    m++;
                }
            }
            return m;
        }
    }
}
