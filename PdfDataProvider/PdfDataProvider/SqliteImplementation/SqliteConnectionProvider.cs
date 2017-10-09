using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;

namespace PdfDataProvider.SqliteImplementation
{
    public class SqliteConnectionProvider
    {
        private SQLiteConnection dataBaseConnection;
        private const string connectionString = @"Data Source=E:\Tools\sqlite-tools-win32-x86-3200100\sqlite-tools-win32-x86-3200100\PdfTestData;Version=3;New=False;Compress=True;";
        private ConnectionState currentConnectionState = ConnectionState.Closed;
        private ConnectionState originalConnectionState = ConnectionState.Closed;


        public SqliteConnectionProvider()
        {
            String test = "New string";
            test.Substring(1);
            dataBaseConnection = new SQLiteConnection(connectionString);
            dataBaseConnection.StateChange += this.DataBaseStateChangedHandler;
            dataBaseConnection.Open();
        }

        public void DataBaseStateChangedHandler(Object sender, StateChangeEventArgs args)
        {
            currentConnectionState = args.CurrentState;
            originalConnectionState = args.OriginalState;
         }

        public T SelectExactlyOneItem<T>(string commandString, string tableName)
        {
            SQLiteCommand command = dataBaseConnection.CreateCommand();
            command.CommandText = commandString;
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command.CommandText, dataBaseConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, tableName);
            
            DataTable dataTable = dataSet.Tables[tableName];

            if (dataTable.Rows.Count > 0)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Populate,
                };
                // Serialize the data table
                string json = JsonConvert.SerializeObject(dataTable.Rows[0].Table);
                return JsonConvert.DeserializeObject<T[]>(json, settings)[0];
            }
            return default(T);
        }

        public long InsertRecord(string commandString)
        {
            SQLiteCommand command = dataBaseConnection.CreateCommand();
            command.CommandText = commandString;
            try
            {
                command.ExecuteNonQuery();
                return dataBaseConnection.LastInsertRowId;
            }
            catch (Exception)
            {
               // Do something about it
            }
            return -1;
        }


        public long UpdateRecord(string commandString)
        {
            return InsertRecord(commandString);
        }


        public void CloseConnection()
        {
            if(currentConnectionState == ConnectionState.Open)
            {
                dataBaseConnection.Close();
            }
        }

        ~SqliteConnectionProvider()
        {
            CloseConnection();
        }
    }
}
