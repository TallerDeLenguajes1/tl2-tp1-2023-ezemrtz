namespace cadeteria;
public class AccesoADatos{
    public bool ExisteArchivo(string path){
        if(File.Exists(path)){
            return true;
        }else{
            return false;
        }
    }
    public Cadeteria cargarCadeteria(string path){
        var archivo = new StreamReader(path);
        string texto = archivo.ReadLine();
        string[] textoSeparado;
        Cadeteria cadeteria = null;
        while(texto != null){
            textoSeparado = texto.Split(";");
            cadeteria = new Cadeteria(textoSeparado[0],Convert.ToInt32(textoSeparado[1]));
            texto = archivo.ReadLine();
        }
        archivo.Close();
        return cadeteria;
    }
    public void cargarCadetes(string path, Cadeteria cad){
        var archivo = new StreamReader(path);
        string texto = archivo.ReadLine();
        string[] textoSeparado;
        while(texto != null){
            textoSeparado = texto.Split(";");
            Cadete cadete = new Cadete(Convert.ToInt32(textoSeparado[0]),textoSeparado[1],textoSeparado[2],Convert.ToInt32(textoSeparado[3]));
            cad.AgregarCadete(cadete);
            texto = archivo.ReadLine();
        }
        archivo.Close();
    }
}