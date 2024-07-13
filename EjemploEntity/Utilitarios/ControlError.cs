using System.Data;

namespace EjemploEntity.Utilitarios
{
    public class ControlError
    {
        public void LogErrorMethods(string clase, string metodo, string error)
        {
            var ruta = string.Empty;
            var archivo = string.Empty;
            var mensaje = string.Empty;
            DateTime Fecha = DateTime.Now;

            try
            {
                ruta = "C:\\Users\\bryan\\Desktop\\Bootcamp\\Archivos\\EntityFramework\\ProyectoIntegrador\\logs";
                archivo = $"Log_{Fecha.ToString("dd-MM-yy")}";

                if (!Directory.Exists(ruta)) 
                {
                    Directory.CreateDirectory(ruta);
                }

                StreamWriter writ = new StreamWriter($"{ruta}\\{archivo}");
                writ.WriteLine($"Se presento una novedad en la clase: {clase} en el metodo: {metodo}, con el sigiente error: {error}");
                writ.Close();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
