namespace cadeteria;

public class Cadeteria{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value;}
    public List<Pedido> ListadoPedidos { get => listadoPedidos;}
    

    public Cadeteria(string nombre, int telefono){
        Nombre = nombre;
        Telefono = telefono;
        listadoPedidos = new List<Pedido>();
    }

    public void DarAltaPedido(string obs, string nomCliente, string direccion, int telefono, string referencia){
        Pedido miPedido = new Pedido(listadoPedidos.Count+1, obs, Estados.pendiente, nomCliente, direccion, telefono, referencia);
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

    public void CambiarEstadoPedido(int numPedido, int estado){
        Pedido pedido;
        Estados nuevoEstado = Estados.entregado;
        if(estado == 2) nuevoEstado = Estados.cancelado;
        foreach (var item in listadoPedidos){
            if(item.Numero == numPedido){
                item.CambiarEstado(nuevoEstado);
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
        float montoTotal = 0;
        int cantPedidosEnvTotal = 0;
        foreach (var cad in listadoCadetes)
        {   
            float monto = 0;
            int cantPedidos = 0;
            int cantPedidosEnviados = 0;
            Console.WriteLine("=============");
            Console.WriteLine("ID: {0}", cad.Id);
            Console.WriteLine("Nombre: {0}", cad.Nombre);
            foreach (var ped in listadoPedidos)
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
        if(listadoCadetes.Count != 0){
            promedio = (float)cantPedidosEnvTotal/listadoCadetes.Count;
        }
        Console.WriteLine("Promedio de envios por cadete: {0}", promedio);
    }


    
}