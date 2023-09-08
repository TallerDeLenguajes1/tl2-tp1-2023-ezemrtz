using cadeteria;

AccesoADatos HelperDatos = new AccesoADatos();
string? pathCadetes = "datos/cadetes.csv", pathCadeteria = "datos/cadeteria.csv";
Cadeteria? Cad = null;
if(HelperDatos.ExisteArchivo(pathCadeteria) && HelperDatos.ExisteArchivo(pathCadetes)){
    Cad = HelperDatos.cargarCadeteria(pathCadeteria);
    HelperDatos.cargarCadetes(pathCadetes, Cad);
}

int op, numPedido = 0;
Pedido nuevoPedido = null, ultimoPedidoAsig = null;
do{
    Console.WriteLine("========== MENU CADETERIA ==========");
    Console.WriteLine("Ingrese que quiere realizar:");
    Console.WriteLine("1- Dar de alta pedido");
    Console.WriteLine("2- Asignar pedido a cadete");
    Console.WriteLine("3- Cambiar estado de pedido");
    Console.WriteLine("4- Reasignar pedido a otro cadete");
    Console.WriteLine("0- SALIR");
    op = Convert.ToInt32(Console.ReadLine());

    switch(op){
        case 1:
            nuevoPedido = Cad.DarAltaPedido(numPedido);
            numPedido++;
        break;
        case 2:
            if(nuevoPedido != null && nuevoPedido != ultimoPedidoAsig){
                ultimoPedidoAsig = nuevoPedido;
                Cad.AsignarPedido(nuevoPedido);
            }else{
                Console.WriteLine("El pedido ya se encuentra asignado");
            }
        break;
        case 3:
            int numPed, op1;
            Estados estado = Estados.pendiente;
            Console.WriteLine("Ingrese el numero de pedido:");
            numPed = Convert.ToInt32(Console.ReadLine());   
            Console.WriteLine("Ingrese el nuevo estado de pedido:");
            Console.WriteLine("1- Entregado");
            Console.WriteLine("2- Cancelado");
            do{
                op1 = Convert.ToInt32(Console.ReadLine());
            } while (op1 != 1 & op != 2);
            if(op1 == 1) estado = Estados.entregado;
            if(op1 == 2) estado = Estados.cancelado;
            Cad.CambiarEstadoPedido(numPed, estado);     
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
Cad.Informe();