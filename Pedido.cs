// See https://aka.ms/new-console-template for more information
namespace cadeteria;
public class Pedido{
    private int numero;
    private string observacion;
    private Cliente client;
    private string estado;

    public Pedido(int numero, string observacion, string estado, string nombre, string direccion, int telefono, string referencia){
        Client = new Cliente(nombre, direccion, telefono, referencia);
        Numero = numero;
        Observacion = observacion;
        Estado = estado;
    }

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Client { get => client; set => client = value; }
    public string Estado { get => estado; set => estado = value; }
}