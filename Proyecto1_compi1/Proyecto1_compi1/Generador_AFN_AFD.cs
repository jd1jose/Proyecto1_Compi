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

        public void Lista(List<string> Lista_Tokens) {
            tabla_simbolos = Lista_Tokens;
            exp();
            conjunto();
            Console.WriteLine("estas son las expresiones");
            for (int i=0;i<Expresiones.Count();i++) {
                Console.WriteLine(Expresiones[i]);
            }
            Console.WriteLine("estas son los conjuntos");
            for (int i = 0; i < conjuntos.Count(); i++) {
                Console.WriteLine(conjuntos[i]);
            }
            Pol();
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
            for (int i=0; i<Expresiones.Count;i++) {
                
                int max = maximo(i);
                int conta = 0;
             
                while (conta<max) {
                    string[] exprecion ;
                    //un if de cambio de expresion cuando algo haga mach
                    if (etotal == "" &&conta==0)
                    {
                        exprecion = Expresiones[i].Split('@');
                    }
                    else {
                        exprecion = etotal.Split('@');
                    }
                    MessageBox.Show("el conta es:"+conta+" y e tiene:"+e+" y estamos ubicados en la lista con:"+exprecion[contador]);
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
                                //mach
                                MessageBox.Show("lo que tiene e:"+e);
                                etotal = Loquetenia(contador, i);
                                MessageBox.Show("etotal solo es:"+etotal);
                                etotal += e;
                                MessageBox.Show("como queda etotal entonces: "+etotal);
                                e = "";
                                contador = 0;
                                conta++;
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
                            e = "@" + exprecion[contador+2] + exprecion[contador]+ "@tk_cadena";
                            //mach
                            MessageBox.Show("lo que tiene e en else if:" + e);
                            etotal = Loquetenia(contador,i);
                            MessageBox.Show("etotal solo es:" + etotal);
                            etotal += e;
                            MessageBox.Show("como queda etotal  en el else if entonces: " + etotal);
                            e = "";
                            contador = 0;
                            conta++;
                        }


                    }
                    else {
                        contador = contador + 2;
                    }
                }

                Console.WriteLine("la expression es: "+etotal);
                etotal = "";
                contador = 1;
            }
          

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
