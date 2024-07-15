
using EFconASPyMVC;
using EFconASPyMVC.Context;
using EFconASPyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EFconASPyMVC
{
    // Clase que inicializa la base de datos
    public static class DbInitializer
    {
        public static void Initialize(MyContext context)
        {
            context.Database.EnsureCreated(); //este método nos crea automáticamente la base de datos sin necesidad de migraciones

            // Comprueba si hay algún Director
            if (context.CentrosDeportivos.Any())
            {
                return;   // BD ya ha sido inicializada
            }
            //Añado Centros deportivos
            var centros = new CentroDeportivo[]
            {
            new CentroDeportivo{Nombre="Fontanar",Direccion="C/ Fontanar"},
            new CentroDeportivo{Nombre="Vistalegre",Direccion="Plaza Vistalegre"},
            new CentroDeportivo{Nombre="Arcangel", Direccion = "Avd Campo"  },
            new CentroDeportivo{Nombre="Figueroa", Direccion = "Plaza Fifueroa"}
            };
            foreach (CentroDeportivo i in centros)
            {
                context.CentrosDeportivos.Add(i);
            }
            context.SaveChanges();
            //Añado directores
            var direc = new Director[]
            {
            new Director{DniDirector = "123456789J", Nombre="Antonio García",Empleados=5,CentroDeportivoId=1},
            new Director{DniDirector = "987654321L", Nombre="María Deportiva",Empleados=4,CentroDeportivoId=2},
            new Director{DniDirector = "123455432M", Nombre="Juana la Loca", Empleados = 6, CentroDeportivoId=3},
            new Director{DniDirector = "985676789N", Nombre="Felipe Gonzalez", Empleados = 4, CentroDeportivoId=4}

            };
            foreach (Director a in direc)
            {
                context.Directores.Add(a);
            }
            context.SaveChanges();
            

            //Añado usuarios
            var usu = new Usuario[]
            {
            new Usuario{DniUsuario = "12345678Y", Nombre="Antonio Pérez",Direccion="C/ Fontanar"},
            new Usuario{DniUsuario = "12245678J", Nombre="Jose García",Direccion="C/ Fontaner"},
            new Usuario{DniUsuario = "12333678K", Nombre="María García",Direccion="C/ Fontanir"},
            new Usuario{DniUsuario = "12344678L", Nombre="Julia Gómez",Direccion="C/ Fontanor"},
            new Usuario{DniUsuario = "12355678M", Nombre="Marcos Polos",Direccion="C/ Fontanur"},
            new Usuario{DniUsuario = "12366678N", Nombre="Laura Villafuerte",Direccion="C/ Angel"},
            new Usuario{DniUsuario = "12377679O", Nombre="Ana Séseamo",Direccion="C/ Ángeles"},
            new Usuario{DniUsuario = "12388679P", Nombre="Thor Valhalla",Direccion="C/ Ángela"},
            };


            foreach (Usuario d in usu)
            {
                context.Usuarios.Add(d);
            }
            context.SaveChanges();

            //Añado CentroDeportivoUsuario
            var cu = new CentroDeportivoUsuario[]
            {
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioDniUsuario = "12345678Y"},
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioDniUsuario = "12245678J"},
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioDniUsuario = "12333678K"},
            new CentroDeportivoUsuario{CentroDeportivoId=1,UsuarioDniUsuario = "12355678M"}
            
            };
            foreach (CentroDeportivoUsuario esC in cu)
            {
                context.CentrosUsuarios.Add(esC);
            }
            context.SaveChanges();
            //Añado pistas
            var pistas = new Pista[]
            {
            new Pista{PistaNombre= "Atletismo",Aforo=10,CentroDeportivoId=1},
            new Pista{PistaNombre= "Tenis",Aforo=4,CentroDeportivoId=1},
            new Pista{PistaNombre= "Baloncesto",Aforo=20,CentroDeportivoId=2},
            new Pista{PistaNombre= "Fútbol",Aforo=30,CentroDeportivoId=2},
            new Pista{PistaNombre= "Paddel",Aforo=4,CentroDeportivoId=3},
            new Pista{PistaNombre= "Petanca2",Aforo=8,CentroDeportivoId=2},
            new Pista{PistaNombre= "Atletismo2",Aforo=10,CentroDeportivoId=1},
            new Pista{PistaNombre= "Salto2",Aforo=10,CentroDeportivoId=3},
            new Pista{PistaNombre= "Petanca",Aforo=8,CentroDeportivoId=3},
            new Pista{PistaNombre= "Atletismo3",Aforo=10,CentroDeportivoId=4},
            new Pista{PistaNombre= "Salto",Aforo=10,CentroDeportivoId=4}
            };
            foreach (Pista s in pistas)
            {
                context.Pistas.Add(s);
            }
            context.SaveChanges();
        }


    }

}
