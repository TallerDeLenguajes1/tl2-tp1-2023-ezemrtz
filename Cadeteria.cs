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

    
    public void AsignarPedido(int id, int numero, string observacion, Estados estado, string nombre, string direccion, int telefono, string referencia){
        Pedido nuevoPedido = new Pedido(numero,observacion,estado, nombre, direccion, telefono, referencia);
        Cadete cadet = ListadoCadetes.Find(cad => cad.Id == id);
        cadet.AgregarPedido(nuevoPedido);
    }

    public void ReasignarPedido(Pedido pedido, int id){
        foreach (var item in ListadoCadetes)
        {
            if((item.ListadoPedidos.Find(p => p.Numero == pedido.Numero )!= null)){
                item.ListadoPedidos.Remove(pedido);
                break;
            }
        }
        Cadete cadet = ListadoCadetes.Find(cad => cad.Id == id);
        cadet.AgregarPedido(pedido);
    }

    
}