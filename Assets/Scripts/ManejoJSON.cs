using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ManejoJSON : MonoBehaviour
{
    // Ruta del archivo JSON
    private string rutaArchivo = "Assets/datos.json";

    void Start()
    {
        // Leer datos desde el archivo JSON
        string json = File.ReadAllText(rutaArchivo);
        DatosJuego datos = JsonUtility.FromJson<DatosJuego>(json);

        // Mostrar información de cada personaje
        foreach (var personaje in datos.personajes)
        {
            Debug.Log($"Nombre: {personaje.nombre}, Nivel: {personaje.nivel}, Clase: {personaje.clase}");
        }

        // Modificar datos (por ejemplo, incrementar el nivel del aventurero)
        foreach (var personaje in datos.personajes)
        {
            if (personaje.nombre == "Aventurero")
            {
                personaje.nivel++;
            }
        }

        // Escribir de nuevo en el archivo JSON
        string nuevoJson = JsonUtility.ToJson(datos, true);
        File.WriteAllText(rutaArchivo, nuevoJson);
    }
}

[System.Serializable]
public class Personaje
{
    public string nombre;
    public int nivel;
    public string clase;
}

[System.Serializable]
public class DatosJuego
{
    public List<Personaje> personajes;
}