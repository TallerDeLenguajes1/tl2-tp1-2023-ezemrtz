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
        float jornal = 0;
        ListadoPedidos.ForEach(delegate(Pedido p)
        {
            if(p.Estado == "ENTREGADO")jornal+=500;
        });
        return jornal;
    }

    public void AgregarPedido(Pedido pedido){
        ListadoPedidos.Add(pedido);
    }
}