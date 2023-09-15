using cadeteria;

AccesoADatos HelperDatos = null;
Console.WriteLine("Ingrese con que opcion quiere cargar los datos: ");
Console.WriteLine("1. CSV");
Console.WriteLine("2. JSON");
int opDatos = Convert.ToInt32(Console.ReadLine());
if(opDatos == 1) HelperDatos = new AccesoCSV();
if(opDatos == 2) HelperDatos = new AccesoJSON();
string? pathCadetes = "datos/cadetes.csv", pathCadeteria = "datos/cadeteria.csv";
Cadeteria? Cad = null;
if(HelperDatos.ExisteArchivo(pathCadeteria) && HelperDatos.ExisteArchivo(pathCadetes)){
    Cad = HelperDatos.leerCadeteria(pathCadeteria);
    CargaInicialCadetes(ref Cad,HelperDatos.leerCadetes(pathCadetes));
}
int op;
do{
    Console.WriteLine("========== MENU CADETERIA ==========");
    Console.WriteLine("Ingrese que quiere realizar:");
    Console.WriteLine("1- Dar de alta pedido");
    Console.WriteLine("2- Asignar cadete a pedido");
    Console.WriteLine("3- Cambiar estado de pedido");
    Console.WriteLine("4- Reasignar pedido a otro cadete");
    Console.WriteLine("0- SALIR");
    op = Convert.ToInt32(Console.ReadLine());

    switch(op){
        case 1:
            DarAltaPedido(ref Cad);
        break;
        case 2:
            Console.WriteLine("Ingrese el numero del pedido: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el id del cadete: ");
            int idC = Convert.ToInt32(Console.ReadLine());
            Cad.AsignarCadeteAPedido(idC, num);   
        break;
        case 3:
            int numPed, op1;
            Console.WriteLine("Ingrese el numero de pedido:");
            numPed = Convert.ToInt32(Console.ReadLine());   
            Console.WriteLine("Ingrese el nuevo estado de pedido:");
            Console.WriteLine("1- Entregado");
            Console.WriteLine("2- Cancelado");
            do{
                op1 = Convert.ToInt32(Console.ReadLine());
            } while (op1 != 1 & op != 2);
            Cad.CambiarEstadoPedido(numPed, op1);     
        break;
        case 4:
            Console.WriteLine("Ingrese el id del cadete:");
            int idCad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el numero del pedido:");
            numPed = Convert.ToInt32(Console.ReadLine());   
            Cad.ReasignarPedido(numPed, idCad);
        break;
        default:
        break;
    }
}while(op != 0);
Informe();

// Defino las funciones
void CargaInicialCadetes(ref Cadeteria cadeteria, List<Cadete>lista){
    cadeteria.ListadoCadetes = lista;
}

void DarAltaPedido(ref Cadeteria cadeteria){
    Console.WriteLine("Ingrese el nombre del cliente: ");
    var nombre = Console.ReadLine();
    Console.WriteLine("Ingrese la direccion del cliente: ");
    var direcc = Console.ReadLine();
    Console.WriteLine("Ingrese una referencia de la direccion del cliente: ");
    var referencia = Console.ReadLine();
    Console.WriteLine("Ingrese el telefono del cliente: ");
    var telefono = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese una observacion del pedido: ");
    var obs = Console.ReadLine();

    cadeteria.DarAltaPedido(obs, nombre, direcc, telefono, referencia);
}

void Informe(){
    float montoTotal = 0;
    int cantPedidosEnvTotal = 0;
    foreach (var cad in Cad.ListadoCadetes)
    {   
        float monto = 0;
        int cantPedidos = 0;
        int cantPedidosEnviados = 0;
        Console.WriteLine("=============");
        Console.WriteLine("ID: {0}", cad.Id);
        Console.WriteLine("Nombre: {0}", cad.Nombre);
        foreach (var ped in Cad.ListadoPedidos)
        {
            if(ped.IdCadete == cad.Id){
                cantPedidos++;
                if(ped.Estado == Estados.entregado){
                    cantPedidosEnviados++;
                    cantPedidosEnvTotal++;
                    monto += 500;
                }
            }
        }
        Console.WriteLine("Cantidad pedidos: {0}", cantPedidos);
        Console.WriteLine("Cantidad pedidos enviados: {0}", cantPedidosEnviados);
        Console.WriteLine("Jornal: ${0}", monto);
        Console.WriteLine("=============");
        montoTotal += monto;
    }
    Console.WriteLine("Monto total recaudado: ${0}", montoTotal);
    float promedio = 0;
    if(Cad.ListadoCadetes.Count != 0){
        promedio = (float)cantPedidosEnvTotal/Cad.ListadoCadetes.Count;
    }
    Console.WriteLine("Promedio de envios por cadete: {0}", promedio);
}
