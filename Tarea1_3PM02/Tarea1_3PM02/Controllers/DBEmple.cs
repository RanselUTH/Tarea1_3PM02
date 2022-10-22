using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tarea1_3PM02.Controllers
{
    public class DBEmple
    {
        readonly SQLiteAsyncConnection _connection;


        public DBEmple()
        {
        }

        public DBEmple(String dbpath)
        {
            // Nueva instanacia de Base de datos utilizando el dbpath
            _connection = new SQLiteAsyncConnection(dbpath);
            // creacion de objetos de base de datos
            // 
            _connection.CreateTableAsync<Models.Empleado>().Wait();

        }

        // CRUD
        // Create Empleado
        public Task<int> StoreEmple(Models.Empleado emple)
        {
            if (emple.id != 0)
            {
                return _connection.UpdateAsync(emple);
            }
            else
            {
                return _connection.InsertAsync(emple);
            }
        }

        // Read
        public Task<List<Models.Empleado>> ListaEmpleadosAll()
        {
            return _connection.Table<Models.Empleado>().ToListAsync();
        }

        // Delete
        public Task<int> DeleteEmple(Models.Empleado emple)
        {
            return _connection.DeleteAsync(emple);
        }
    }
}
