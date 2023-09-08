namespace cadeteria;

public class Cadeteria{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public Cadeteria(string nombre, int telefono){
        Nombre = nombre;
        Telefono = telefono;
        ListadoCadetes = new List<Cadete>();
    }

    public void AgregarCadete(Cadete cadete){
        ListadoCadetes.Add(cadete);
    }

    public Pedido DarAltaPedido(int numero){
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
        miPedido = new Pedido(numero, obs, Estados.pendiente, nombre, direcc, telefono, referencia);

        return miPedido;
    }

    
    public void AsignarPedido(Pedido pedido){
        Console.WriteLine("Ingrese el ID del cadete al que quiere asignar el pedido: ");
        var id = Convert.ToInt32(Console.ReadLine());
        Cadete cadet = ListadoCadetes.Find(cad => cad.Id == id);
        if(cadet != null){
            cadet.AgregarPedido(pedido);
        }else{
            Console.WriteLine("No se encontro el cadete");
        }
    }

    public void ReasignarPedido(int numPedido, int id){
        Pedido pedido;
        foreach (var item in ListadoCadetes)
        {
            pedido = item.ListadoPedidos.Find(p => p.Numero == numPedido );
            if(pedido!= null){
                item.BorrarPedido(pedido);
                Cadete cadet = ListadoCadetes.Find(cad => cad.Id == id);
                if(cadet != null){
                    cadet.AgregarPedido(pedido);    
                }else{
                    Console.WriteLine("No se encontro al cadete");
                }
                break;
            }
        }
    }

    public void CambiarEstadoPedido(int numPedido, Estados estado){
        Pedido pedido;
        foreach (var item in ListadoCadetes){
            item.CambiarEstado(numPedido, estado);
        }
    }

    public void MostrarInfo(){
        Console.WriteLine("==================");
        Console.WriteLine("Nombre Cadeteria: {0}", nombre);
        Console.WriteLine("Telefono: {0}", telefono);
        Console.WriteLine("==================");
    }

    public void Informe(){
        var infoCadetes = ListadoCadetes.Select(cad => new{
            nombre = cad.Nombre,
            cantPedidos = cad.CantidadPedidos(),
            cantPedidosEntregados = cad.CantidadPedidosEnviados(),
            monto = cad.JornalACobrar()
        }).ToList();
        var montoTotal = infoCadetes.Sum(cad => cad.monto);
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
        Console.WriteLine("\nTotal recaudado: {0}", montoTotal);
        Console.WriteLine("Total pedidos: {0}", cantPedidosTotal);
        Console.WriteLine("Total pedidos entregados: {0}", cantEnvios);
        Console.WriteLine("Promedio pedidos entregados por cadete: {0}", promedioPedidosEnviados);
        
    }


    
}