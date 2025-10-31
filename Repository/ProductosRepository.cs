using Microsoft.Data.Sqlite;

public class ProductosRepository
{
    string cadenaDeConexion = "Data Source=Tienda.db";
    public void createProduct(Producto producto)
    {
        using var conexion = new SqliteConnection(cadenaDeConexion);
        conexion.Open();
        string sql = "INSERT INTO Productos ( Descripcion, Precio) VALUES (@Descripcion, @Precio)";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
        comando.Parameters.Add(new SqliteParameter("@DNI", producto.Precio));
        comando.ExecuteNonQuery();
    }
    public void modificarProductoViaID(int id, Producto producto)
    {
        using var conexion = new SqliteConnection(cadenaDeConexion);
        conexion.Open();
        string sql = "UPDATE Producto SET Descripcion = @descripcion Precio = @precio WHERE IdProducto = @id";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@descripcion", producto.Descripcion));
        comando.Parameters.Add(new SqliteParameter("@precio", producto.Precio));
        comando.Parameters.Add(new SqliteParameter("@id", id));
        comando.ExecuteNonQuery();
    }
    public List<Producto> GetAll()
    {
        List<Producto> productos = null;
        string Query = "SELECT * FROM Productos";
        using var connection = new SqliteConnection(cadenaDeConexion);
        connection.Open();
        var command = new SqliteCommand(Query, connection);
        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var producto = new Producto
                {
                    IdProducto = Convert.ToInt32(reader["idProducto"]),
                    Descripcion = reader["Descripcion"].ToString(),
                    Precio = Convert.ToInt32(reader["Precio"])
                };
                productos.Add(producto);
            }
        }
        connection.Close();
        return productos;
    }
}