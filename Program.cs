using System;
using System.Data;
using System.Data.SqlClient;

public class Program1
{
    private static string connectionString = "Data Source=.;Initial Catalog=CarlosMoralesChimbote;Integrated Security=True";

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Sistema creado por: BRAYAM EDWIN QUISPE APAZA");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Crear Estudiante");
            Console.WriteLine("2. Leer Estudiantes");
            Console.WriteLine("3. Actualizar Estudiante");
            Console.WriteLine("4. Eliminar Estudiante");
            Console.WriteLine("5. Crear Nivel");
            Console.WriteLine("6. Leer Niveles");
            Console.WriteLine("7. Actualizar Nivel");
            Console.WriteLine("8. Eliminar Nivel");
            Console.WriteLine("9. Consultar Estudiante por ID");
            Console.WriteLine("0. Salir");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearEstudiante();
                    break;
                case 2:
                    LeerEstudiantes();
                    break;
                case 3:
                    ActualizarEstudiante();
                    break;
                case 4:
                    EliminarEstudiante();
                    break;
                case 5:
                    CrearNivel();
                    break;
                case 6:
                    LeerNiveles();
                    break;
                case 7:
                    ActualizarNivel();
                    break;
                case 8:
                    EliminarNivel();
                    break;
                case 9:
                    ConsultarEstudiantePorId();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    private static void CrearEstudiante()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            Console.WriteLine("Ingrese el primer nombre:");
            string primerNombre = Console.ReadLine();

            Console.WriteLine("Ingrese el segundo nombre:");
            string segundoNombre = Console.ReadLine();

            Console.WriteLine("Ingrese el primer apellido:");
            string primerApellido = Console.ReadLine();

            Console.WriteLine("Ingrese el segundo apellido:");
            string segundoApellido = Console.ReadLine();

            Console.WriteLine("Ingrese el teléfono:");
            string telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el celular:");
            string celular = Console.ReadLine();

            Console.WriteLine("Ingrese la dirección:");
            string direccion = Console.ReadLine();

            Console.WriteLine("Ingrese el email:");
            string email = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento (YYYY-MM-DD):");
            string fechaNacimientoStr = Console.ReadLine();
            DateTime fechaNacimiento = DateTime.Parse(fechaNacimientoStr);

            Console.WriteLine("Ingrese observaciones:");
            string observaciones = Console.ReadLine();

            Console.WriteLine("Ingrese el ID del nivel del estudiante:");
            int nivelId = int.Parse(Console.ReadLine());

            string query = "INSERT INTO Estudiante (PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Telefono, Celular, Direccion, Email, FechaNacimiento, Observaciones, NivelId) " +
                           "VALUES (@PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @Telefono, @Celular, @Direccion, @Email, @FechaNacimiento, @Observaciones, @NivelId)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PrimerNombre", primerNombre);
            command.Parameters.AddWithValue("@SegundoNombre", segundoNombre);
            command.Parameters.AddWithValue("@PrimerApellido", primerApellido);
            command.Parameters.AddWithValue("@SegundoApellido", segundoApellido);
            command.Parameters.AddWithValue("@Telefono", telefono);
            command.Parameters.AddWithValue("@Celular", celular);
            command.Parameters.AddWithValue("@Direccion", direccion);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
            command.Parameters.AddWithValue("@Observaciones", observaciones);
            command.Parameters.AddWithValue("@NivelId", nivelId);

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Estudiante creado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error al crear el estudiante.");
            }
        }
    }

    private static void LeerEstudiantes()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT e.*, n.Nivel, n.Seccion, n.Grado, n.Aula, n.Tutor, n.Observaciones " +
                           "FROM Estudiante e " +
                           "JOIN Nivel n ON e.NivelId = n.Id";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine($"ID     NOMBRES             APELLIDOS           TELEFONO       CELULAR       DIRECCION           EMAIL                F.NACIMIENTO           OBSERVACIONES       NIVEL       SECCION       GRADO       AULA       TUTOR       OBSERVACIONES");

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}    {reader["PrimerNombre"]} {reader["SegundoNombre"]}        {reader["PrimerApellido"]}  {reader["SegundoApellido"]}      " +
                    $" {reader["Telefono"]}     {reader["Celular"]}      {reader["Direccion"]}    {reader["Email"]}       {reader["FechaNacimiento"]}     {reader["Observaciones"]}    {reader["Nivel"]}    {reader["Seccion"]}    {reader["Grado"]}    {reader["Aula"]}    {reader["Tutor"]}    {reader["Observaciones"]}");
            }
        }
    }

    private static void ActualizarEstudiante()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            Console.WriteLine("Ingrese el ID del estudiante a actualizar:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo primer nombre:");
            string nuevoPrimerNombre = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo segundo nombre:");
            string nuevoSegundoNombre = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo primer apellido:");
            string nuevoPrimerApellido = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo segundo apellido:");
            string nuevoSegundoApellido = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo teléfono:");
            string nuevoTelefono = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo celular:");
            string nuevoCelular = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva dirección:");
            string nuevaDireccion = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo email:");
            string nuevoEmail = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva fecha de nacimiento (YYYY-MM-DD):");
            string nuevaFechaNacimientoStr = Console.ReadLine();
            DateTime nuevaFechaNacimiento = DateTime.Parse(nuevaFechaNacimientoStr);

            Console.WriteLine("Ingrese nuevas observaciones:");
            string nuevasObservaciones = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo ID del nivel del estudiante:");
            int nuevoNivelId = int.Parse(Console.ReadLine());

            string query = "UPDATE Estudiante SET PrimerNombre = @NuevoPrimerNombre, SegundoNombre = @NuevoSegundoNombre, " +
                           "PrimerApellido = @NuevoPrimerApellido, SegundoApellido = @NuevoSegundoApellido, " +
                           "Telefono = @NuevoTelefono, Celular = @NuevoCelular, " +
                           "Direccion = @NuevaDireccion, Email = @NuevoEmail, " +
                           "FechaNacimiento = @NuevaFechaNacimiento, Observaciones = @NuevasObservaciones, " +
                           "NivelId = @NuevoNivelId " +
                           "WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@NuevoPrimerNombre", nuevoPrimerNombre);
            command.Parameters.AddWithValue("@NuevoSegundoNombre", nuevoSegundoNombre);
            command.Parameters.AddWithValue("@NuevoPrimerApellido", nuevoPrimerApellido);
            command.Parameters.AddWithValue("@NuevoSegundoApellido", nuevoSegundoApellido);
            command.Parameters.AddWithValue("@NuevoTelefono", nuevoTelefono);
            command.Parameters.AddWithValue("@NuevoCelular", nuevoCelular);
            command.Parameters.AddWithValue("@NuevaDireccion", nuevaDireccion);
            command.Parameters.AddWithValue("@NuevoEmail", nuevoEmail);
            command.Parameters.AddWithValue("@NuevaFechaNacimiento", nuevaFechaNacimiento);
            command.Parameters.AddWithValue("@NuevasObservaciones", nuevasObservaciones);
            command.Parameters.AddWithValue("@NuevoNivelId", nuevoNivelId);

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Estudiante actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error al actualizar el estudiante. Verifique el ID.");
            }
        }
    }

    private static void EliminarEstudiante()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            Console.WriteLine("Ingrese el ID del estudiante a eliminar:");
            int id = int.Parse(Console.ReadLine());

            string query = "DELETE FROM Estudiante WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Estudiante eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error al eliminar el estudiante. Verifique el ID.");
            }
        }
    }

    private static void CrearNivel()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            Console.WriteLine("Ingrese el ID del nivel:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nivel:");
            string nivel = Console.ReadLine();

            Console.WriteLine("Ingrese la sección:");
            string seccion = Console.ReadLine();

            Console.WriteLine("Ingrese el grado:");
            string grado = Console.ReadLine();

            Console.WriteLine("Ingrese el aula:");
            string aula = Console.ReadLine();

            Console.WriteLine("Ingrese el tutor:");
            string tutor = Console.ReadLine();

            Console.WriteLine("Ingrese observaciones:");
            string observaciones = Console.ReadLine();

            string query = "INSERT INTO Nivel (Id, Nivel, Seccion, Grado, Aula, Tutor, Observaciones) " +
                           "VALUES (@Id, @Nivel, @Seccion, @Grado, @Aula, @Tutor, @Observaciones)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Nivel", nivel);
            command.Parameters.AddWithValue("@Seccion", seccion);
            command.Parameters.AddWithValue("@Grado", grado);
            command.Parameters.AddWithValue("@Aula", aula);
            command.Parameters.AddWithValue("@Tutor", tutor);
            command.Parameters.AddWithValue("@Observaciones", observaciones);

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Nivel creado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error al crear el nivel.");
            }
        }
    }

    private static void LeerNiveles()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Nivel";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine($"ID     NIVEL      SECCION    GRADO    AULA    TUTOR    OBSERVACIONES");

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}    {reader["Nivel"]}   {reader["Seccion"]}   {reader["Grado"]}   {reader["Aula"]}   {reader["Tutor"]}   {reader["Observaciones"]}");
            }
        }
    }

    private static void ActualizarNivel()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            Console.WriteLine("Ingrese el ID del nivel a actualizar:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo nivel:");
            string nuevoNivel = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva sección:");
            string nuevaSeccion = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo grado:");
            string nuevoGrado = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva aula:");
            string nuevaAula = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo tutor:");
            string nuevoTutor = Console.ReadLine();

            Console.WriteLine("Ingrese nuevas observaciones:");
            string nuevasObservaciones = Console.ReadLine();

            string query = "UPDATE Nivel SET Nivel = @NuevoNivel, Seccion = @NuevaSeccion, " +
                           "Grado = @NuevoGrado, Aula = @NuevaAula, " +
                           "Tutor = @NuevoTutor, Observaciones = @NuevasObservaciones " +
                           "WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@NuevoNivel", nuevoNivel);
            command.Parameters.AddWithValue("@NuevaSeccion", nuevaSeccion);
            command.Parameters.AddWithValue("@NuevoGrado", nuevoGrado);
            command.Parameters.AddWithValue("@NuevaAula", nuevaAula);
            command.Parameters.AddWithValue("@NuevoTutor", nuevoTutor);
            command.Parameters.AddWithValue("@NuevasObservaciones", nuevasObservaciones);

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Nivel actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error al actualizar el nivel. Verifique el ID.");
            }
        }
    }



    private static void EliminarNivel()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            Console.WriteLine("Ingrese el ID del nivel a eliminar:");
            int id = int.Parse(Console.ReadLine());

            string query = "DELETE FROM Nivel WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Nivel eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error al eliminar el nivel. Verifique el ID.");
            }
        }
    }

    private static void ConsultarEstudiantePorId()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            Console.WriteLine("Ingrese el ID del estudiante que desea consultar:");
            int id = int.Parse(Console.ReadLine());

            string query = "SELECT e.*, n.Nivel, n.Seccion, n.Grado, n.Aula, n.Tutor, n.Observaciones " +
                           "FROM Estudiante e " +
                           "JOIN Nivel n ON e.NivelId = n.Id " +
                           "WHERE e.Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                Console.WriteLine($"ID: {reader["Id"]}");
                Console.WriteLine($"Primer Nombre: {reader["PrimerNombre"]}");
                Console.WriteLine($"Segundo Nombre: {reader["SegundoNombre"]}");
                Console.WriteLine($"Primer Apellido: {reader["PrimerApellido"]}");
                Console.WriteLine($"Segundo Apellido: {reader["SegundoApellido"]}");
                Console.WriteLine($"Teléfono: {reader["Telefono"]}");
                Console.WriteLine($"Celular: {reader["Celular"]}");
                Console.WriteLine($"Dirección: {reader["Direccion"]}");
                Console.WriteLine($"Email: {reader["Email"]}");
                Console.WriteLine($"Fecha de Nacimiento: {reader["FechaNacimiento"]}");
                Console.WriteLine($"Observaciones: {reader["Observaciones"]}");
                Console.WriteLine($"Nivel: {reader["Nivel"]}");
                Console.WriteLine($"Sección: {reader["Seccion"]}");
                Console.WriteLine($"Grado: {reader["Grado"]}");
                Console.WriteLine($"Aula: {reader["Aula"]}");
                Console.WriteLine($"Tutor: {reader["Tutor"]}");
                
            }
            else
            {
                Console.WriteLine($"No se encontró un estudiante con el ID {id}");
            }
        }
    }

}
