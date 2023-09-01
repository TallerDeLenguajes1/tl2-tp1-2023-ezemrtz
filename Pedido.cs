// See https://aka.ms/new-console-template for more information
namespace cadeteria;

public enum Estados{
    pendiente,
    entregado,
    cancelado
}
public class Pedido{
    private int numero;
    private string observacion;
    private Cliente client;
    private Estados estado;
    private Cadete icadete;

    public Pedido(int numero, string observacion, Estados estado, string nombre, string direccion, int telefono, string referencia){
        Client = new Cliente(nombre, direccion, telefono, referencia);
        Numero = numero;
        Observacion = observacion;
        Estado = estado;
    }

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Client { get => client; set => client = value; }
    public Estados Estado { get => estado; set => estado = value; }
    public Cadete Icadete { get => icadete; set => icadete = value; }

    public void VerDireccionCliente(){
        Console.WriteLine("Direccion: {0}", this.Client.Direccion);
        Console.WriteLine("Referencias: {0}", this.Client.Referencia);
    }

    public void VerDatosCliente(){
        Console.WriteLine("Nombre: {0}", Client.Nombre);
        Console.WriteLine("Telefono: {0}", Client.Telefono);
    }

    public void CambiarEstado(Estados estado){
        if(this.estado == Estados.pendiente){
            this.estado = estado;
        }
    }
}