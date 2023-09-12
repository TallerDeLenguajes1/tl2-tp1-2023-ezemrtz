using System.Text.Json;
using System.Text.Json.Serialization;
namespace cadeteria;
public abstract class AccesoADatos{
    public bool ExisteArchivo(string path){
        if(File.Exists(path)){
            return true;
        }else{
            return false;
        }
    }
    public abstract Cadeteria leerCadeteria(string path);
    public abstract List<Cadete> leerCadetes(string path);
}

public class AccesoCSV : AccesoADatos{
    public override Cadeteria leerCadeteria(string path){
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
    public override List<Cadete> leerCadetes(string path){
        List<Cadete> lisCad = new List<Cadete>();
        var archivo = new StreamReader(path);
        string texto = archivo.ReadLine();
        string[] textoSeparado;
        while(texto != null){
            textoSeparado = texto.Split(";");
            Cadete cadete = new Cadete(Convert.ToInt32(textoSeparado[0]),textoSeparado[1],textoSeparado[2],Convert.ToInt32(textoSeparado[3]));
            lisCad.Add(cadete);
            texto = archivo.ReadLine();
        }
        archivo.Close();
        return lisCad;
    }
}
public class AccesoJSON : AccesoADatos{
    public override Cadeteria leerCadeteria(string path){
        var archivo = new StreamReader(path);
        string texto = archivo.ReadLine();
        Cadeteria cadeteria = null;
        while(texto != null){
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(texto);
            texto = archivo.ReadLine();
        }
        archivo.Close();
        return cadeteria;
    }
    public override List<Cadete> leerCadetes(string path){
        List<Cadete> lisCad = new List<Cadete>();
        var archivo = new StreamReader(path);
        string texto = archivo.ReadToEnd();
        lisCad = JsonSerializer.Deserialize<List<Cadete>>(texto);
        archivo.Close();
        return lisCad;
    }
}