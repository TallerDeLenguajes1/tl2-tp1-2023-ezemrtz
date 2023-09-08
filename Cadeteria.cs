namespace cadeteria;

public class Cadeteria{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    

    public Cadeteria(string nombre, int telefono){
        Nombre = nombre;
        Telefono = telefono;
    }

    public void CargaInicialCadetes(List<Cadete> lista){
        listadoCadetes = lista;
    }

    public void AgregarCadete(Cadete cadete){
        listadoCadetes.Add(cadete);
    }

    public void DarAltaPedido(){
        Pedido miPedido;
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

        miPedido = new Pedido(listadoPedidos.Count+1, obs, Estados.pendiente, nombre, direcc, telefono, referencia);

        listadoPedidos.Add(miPedido);
    }
    public void AsignarCadeteAPedido(int idCadete, int numPedido){
        Pedido pedido = listadoPedidos.Find(ped => ped.Numero == numPedido);
        if(pedido != null){
            pedido.IdCadete = idCadete;
        }
    }

    public void ReasignarPedido(int numPedido, int idCadeteNuevo){
        Pedido pedido = listadoPedidos.Find(ped => ped.Numero == numPedido);
        if(pedido != null){
            pedido.IdCadete = idCadeteNuevo;
        }

        
    }

    public void CambiarEstadoPedido(int numPedido, Estados estado){
        Pedido pedido;
        foreach (var item in listadoPedidos){
            if(item.Numero == numPedido){
                item.CambiarEstado(estado);
            }
        }
    }

    public float JornalACobrar(int id){
        float jornal = 0;
        foreach (var pedido in listadoPedidos)
        {
            if(pedido.IdCadete == id && pedido.Estado == Estados.entregado){
                jornal += 500;
            }
        }
        return jornal;
    }

public int CantidadPedidos(){
        int cant = 0;
        foreach (var item in listadoPedidos)
        {
            cant++;
        }
        return cant;
    }

    public int CantidadPedidosEnviados(){
        int cant = 0;
        foreach (var item in listadoPedidos)
        {
            if(item.Estado == Estados.entregado){
                cant++;
            }
        }
        return cant;

    }
    public void Informe(){
        var infoCadetes = listadoCadetes.Select(cad => new{
            nombre = cad.Nombre,
            cantPedidos = CantidadPedidos(),
            cantPedidosEntregados = CantidadPedidosEnviados(),
            //monto = cad.JornalACobrar()
        }).ToList();
       // var montoTotal = infoCadetes.Sum(cad => cad.monto);
        var cantPedidosTotal = infoCadetes.Sum(cad => cad.cantPedidos);
        var cantEnvios = infoCadetes.Sum(cad => cad.cantPedidosEntregados);
        float promedioPedidosEnviados;
        int cantCadetes=0;
        foreach(var cad in infoCadetes){
            cantCadetes++;
        }
        if(cantPedidosTotal == 0){
            promedioPedidosEnviados = 0;
        }else{
            promedioPedidosEnviados = (float)cantEnvios/cantCadetes;
        }

        foreach (var cad in infoCadetes)
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Nombre: {0}", cad.nombre);
            Console.WriteLine("Cantidad pedidos: {0}",cad.cantPedidos);
            Console.WriteLine("Pedidos enviados: {0}", cad.cantPedidosEntregados);
        }
        Console.WriteLine("---------------");
        //Console.WriteLine("\nTotal recaudado: {0}", montoTotal);
        Console.WriteLine("Total pedidos: {0}", cantPedidosTotal);
        Console.WriteLine("Total pedidos entregados: {0}", cantEnvios);
        Console.WriteLine("Promedio pedidos entregados por cadete: {0}", promedioPedidosEnviados);
        
    }


    
}