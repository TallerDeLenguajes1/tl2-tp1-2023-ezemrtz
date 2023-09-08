namespace cadeteria;

public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> listadoPedidos;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadete(int id, string nombre, string direccion, int telefono){
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        ListadoPedidos = new List<Pedido>();
    }

    public float JornalACobrar(){
        float jornal = 500;
        jornal *= CantidadPedidosEnviados();
        return jornal;
    }

    public int CantidadPedidos(){
        int cant = 0;
        foreach (var item in ListadoPedidos)
        {
            cant++;
        }
        return cant;
    }

    public int CantidadPedidosEnviados(){
        int cant = 0;
        foreach (var item in ListadoPedidos)
        {
            if(item.Estado == Estados.entregado){
                cant++;
            }
        }
        return cant;

    }
    public void AgregarPedido(Pedido pedido){
        ListadoPedidos.Add(pedido);
    }
    public void BorrarPedido(Pedido pedido){
        ListadoPedidos.Remove(pedido);
    }

    public void CambiarEstado(int numPedido, Estados estado){
        foreach (var item in ListadoPedidos)
        {
            if(item.Numero == numPedido){
                item.CambiarEstado(estado);
                break;
            }
        }
    }

    public void MostrarInfo(){
        Console.WriteLine("==================");
        Console.WriteLine("ID: {0}", id);
        Console.WriteLine("Nombre: {0}", nombre);
        Console.WriteLine("Direccion: {0}", direccion);
        Console.WriteLine("------ Pedidos ------");
        foreach (var item in listadoPedidos)
        {
            item.MostrarInfo();
        }
        Console.WriteLine("==================");
    }
}