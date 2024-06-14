using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AplicacionDeOrganizacionArchivos.Program;
using System.IO;

namespace AplicacionDeOrganizacionArchivos
{
    internal class Program
    {
        public struct FileFormat
        {
            public string Name;
            public string Advantages;
            public string Disadvantages;
            public string CostBenefit;
        }



        static void Main(string[] args)
        {
            List<FileFormat> formats = new List<FileFormat>
            {
                new FileFormat
            {
                Name = "JSON",
                Advantages = "- Fácil de leer y escribir\n- Formato ligero\n- Compatible con muchas APIs y lenguajes de programación",
                Disadvantages = "- No tan eficiente en almacenamiento como formatos binarios\n- No es adecuado para datos altamente estructurados",
                CostBenefit = "- Bajo costo de implementación y mantenimiento\n- Alta eficiencia en aplicaciones web y móviles debido a su naturaleza ligera y fácil manipulación"
            },

              new FileFormat
            {
                Name = "XML",
                Advantages = "- Altamente estructurado y flexible\n- Auto-descriptivo (incluye metadatos)\n- Amplio soporte y estandarización",
                Disadvantages = "- Verboso y pesado en comparación con JSON y otros formatos\n- Más complejo de leer y escribir manualmente",
                CostBenefit = "- Mayor costo inicial debido a su complejidad\n- Beneficioso en entornos que requieren alta interoperabilidad y estructuras de datos complejas"
            },

               new FileFormat
            {
                Name = "CSV",
                Advantages = "- Muy simple y fácil de usar\n- Altamente compatible con programas de hojas de cálculo y bases de datos",
                Disadvantages = "- Carece de estructura para datos complejos\n- No maneja bien datos jerárquicos o relaciones múltiples",
                CostBenefit = "- Costos muy bajos de implementación y mantenimiento\n- Ideal para datos tabulares simples, pero limitado en aplicaciones que requieren estructura compleja"
            },

                new FileFormat
            {
                Name = "Bases de Datos Relacionales",
                Advantages = "- Soporta transacciones ACID\n- Buena para datos estructurados y relacionales\n- Alta integridad y consistencia",
                Disadvantages = "- Configuración y mantenimiento complejos\n- Costos altos de licencias y hardware",
                CostBenefit = "- Altos costos iniciales y de mantenimiento, pero beneficios significativos para datos críticos y estructurados\n- Rentable para aplicaciones empresariales grandes y complejas"
            },

                new FileFormat
            {
                Name = "NoSQL",
                Advantages = "- Flexible en el manejo de datos no estructurados\n- Alta escalabilidad y rendimiento",
                Disadvantages = "- Falta de estandarización\n- No siempre garantiza la consistencia de datos",
                CostBenefit = "- Costos variables dependiendo de la implementación y el volumen de datos\n- Beneficioso para aplicaciones que manejan grandes volúmenes de datos no estructurados y requieren alta escalabilidad"
            }


            };

            while (true)
            {
                Console.WriteLine("Seleccione un formato de archivo para ver sus ventajas y desventajas:");
                for (int i = 0; i < formats.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {formats[i].Name}");
                }
                Console.WriteLine("0. Salir");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice <= formats.Count)
                {
                    if (choice == 0)
                    {
                        break;
                    }
                    else
                    {
                        FileFormat selectedFormat = formats[choice - 1];
                        Console.WriteLine($"\nFormato: {selectedFormat.Name}");
                        Console.WriteLine($"Ventajas:\n{selectedFormat.Advantages}");
                        Console.WriteLine($"Desventajas:\n{selectedFormat.Disadvantages}");
                        Console.WriteLine($"Costo-Beneficio:\n{selectedFormat.CostBenefit}\n");
                    }
                }
                else
                {
                    Console.WriteLine("Selección no válida. Inténtelo de nuevo.");
                }

                Console.ReadKey();


            }



        }

        static void CreateFile(string format)
        {
            Console.WriteLine("Ingrese el nombre del archivo (sin extensión):");
            string fileName = Console.ReadLine();

            switch (format)
            {
                case "JSON":
                    fileName += ".json";
                    File.WriteAllText(fileName, "{\n  \"example\": \"This is a JSON file\"\n}");
                    Console.WriteLine($"Archivo {fileName} creado con éxito.");
                    break;

                case "XML":
                    fileName += ".xml";
                    File.WriteAllText(fileName, "<root>\n  <example>This is an XML file</example>\n</root>");
                    Console.WriteLine($"Archivo {fileName} creado con éxito.");
                    break;

                case "CSV":
                    fileName += ".csv";
                    File.WriteAllText(fileName, "column1,column2,column3\nvalue1,value2,value3");
                    Console.WriteLine($"Archivo {fileName} creado con éxito.");
                    break;

                case "Bases de Datos Relacionales":
                    Console.WriteLine("Función para crear archivos de bases de datos relacionales no implementada.");
                    break;

                case "NoSQL":
                    fileName += ".json";  // Asumimos JSON para NoSQL
                    File.WriteAllText(fileName, "{\n  \"example\": \"This is a NoSQL file\"\n}");
                    Console.WriteLine($"Archivo {fileName} creado con éxito.");
                    break;

                default:
                    Console.WriteLine("Formato desconocido.");
                    break;
            }
        }
    }
}
