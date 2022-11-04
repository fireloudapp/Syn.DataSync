using AutoMapper;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemGeneric.DataAccess.MySQL
{
    /// <summary>
    ///     Generic Repository Class.
    ///     <para>
    ///         The below class Inserts, Updates, Deletes and includes certain Get Operations based on the Type Model
    ///     </para>
    /// </summary>
    public class GenericRepository : IGenericRepository
    {
        #region Global Variable
        /// <summary>
        ///  declare connectionstring  variable and assign value in generic repository constructor 
        /// </summary>
        private string _connectionString;
        #endregion

        #region Constructor
        /// <summary>
        /// Generic Repository Constructor
        /// </summary>
        /// <param name="connectionString">connection string input parameter</param>
        public GenericRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Connection Settings
        /// <summary>
        /// Create IDbConnection using connection string
        /// </summary>
        internal IDbConnection Connection => new  MySqlConnection(_connectionString);

        #endregion

        #region Method Implementation

        /// <inheritdoc />
        /// <summary>
        /// Used to execute insert,update,delete sql command
        /// </summary>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        public void ExecuteCommand(GenericParameter parameter)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(parameter.SqlCommand, parameter.InputParameters, commandType: parameter.ExecuteType);
                parameter.Clear();
                dbConnection.Close();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Used to execute sql command and return single element
        /// </summary>
        /// <typeparam name="T">model type</typeparam>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        /// <returns>first element from result set</returns>
        public T ExecuteScalar<T>(GenericParameter parameter) where T : class
        {
            T outValue;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                outValue = dbConnection.QueryFirstOrDefault<T>(parameter.SqlCommand, parameter.InputParameters, commandType: parameter.ExecuteType);
                parameter.Clear();
                dbConnection.Close();
            }
            return outValue;
        }
        /// <inheritdoc />
        /// <summary>
        /// Used to execute sql command and return list of element
        /// </summary>
        /// <typeparam name="T">model type</typeparam>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        /// <returns>list of element from result set</returns>
        public IEnumerable<T> ExecuteQueryList<T>(GenericParameter parameter) where T : class
        {
            IEnumerable<T> outValue;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                outValue = dbConnection.Query<T>(parameter.SqlCommand, parameter.InputParameters, commandType: parameter.ExecuteType);
                parameter.Clear();
                dbConnection.Close();
            }
            return outValue;
        }
        /// <inheritdoc />
        /// <summary>
        /// Used to execute sql command and return multiple list of element
        /// </summary>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        /// <returns>list of element from result set</returns>
        public dynamic ExecuteQueryMultiple(GenericParameter parameter, IEnumerable<MapItem> mapItems = null)
        {
            var data = new ExpandoObject();
            using (IDbConnection dbConnection = Connection)
            {
                var multi = dbConnection.QueryMultiple(parameter.SqlCommand, parameter.InputParameters, commandType: parameter.ExecuteType);
                if (mapItems == null) return data;

                foreach (var item in mapItems)
                {
                    if (item.DataRetriveType == DataRetriveTypeEnum.FirstOrDefault)
                    {
                        var singleItem = multi.Read(item.Type).FirstOrDefault();
                        ((IDictionary<string, object>)data).Add(item.PropertyName, singleItem);
                    }

                    if (item.DataRetriveType == DataRetriveTypeEnum.List)
                    {
                        var listItem = multi.Read(item.Type).ToList();
                        ((IDictionary<string, object>)data).Add(item.PropertyName, listItem);
                    }
                }
                return data;
            }
        }

        #endregion

        #region Async Method Implementation
        /// <inheritdoc />
        /// <summary>
        /// Its async method used to execute insert,update,delete sql command
        /// </summary>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        public async void ExecuteCommandAsync(GenericParameter parameter)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync(parameter.SqlCommand, parameter.InputParameters, commandType: parameter.ExecuteType);
                parameter.Clear();
                dbConnection.Close();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Its async method used to execute sql command and return single element
        /// </summary>
        /// <typeparam name="T">model type</typeparam>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        /// <returns>first element from result set</returns>
        public async Task<T> ExecuteScalarAsync<T>(GenericParameter parameter) where T : class
        {
            T resultData;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                resultData = await dbConnection.QueryFirstOrDefaultAsync<T>(parameter.SqlCommand, parameter.InputParameters, commandType: parameter.ExecuteType);
                parameter.Clear();
                dbConnection.Close();
            }
            return resultData;
        }
        /// <inheritdoc />
        /// <summary>
        /// Its async method used to execute sql command and return list of element
        /// </summary>
        /// <typeparam name="T">model type</typeparam>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        /// <returns>list of element from result set</returns>
        public async Task<IEnumerable<T>> ExecuteQueryListAsync<T>(GenericParameter parameter) where T : class
        {
            IEnumerable<T> outValue;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                outValue = await dbConnection.QueryAsync<T>(parameter.SqlCommand, parameter.InputParameters, commandType: parameter.ExecuteType);
                parameter.Clear();
                dbConnection.Close();
            }
            return outValue;
        }
        /// <inheritdoc />
        /// <summary>
        /// Used to execute sql command and return multiple list of element
        /// </summary>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        /// <returns>list of element from result set</returns>
        public async Task<dynamic> ExecuteQueryMultipleAsync(GenericParameter parameter, IEnumerable<MapItem> mapItems = null)
        {
            var data = new ExpandoObject();
            using (IDbConnection dbConnection = Connection)
            {
                var multi = await dbConnection.QueryMultipleAsync(parameter.SqlCommand, parameter.InputParameters, commandType: parameter.ExecuteType);
                if (mapItems == null) return data;

                foreach (var item in mapItems)
                {
                    if (item.DataRetriveType == DataRetriveTypeEnum.FirstOrDefault)
                    {
                        var singleItem = multi.Read(item.Type).FirstOrDefault();
                        ((IDictionary<string, object>)data).Add(item.PropertyName, singleItem);
                    }

                    if (item.DataRetriveType == DataRetriveTypeEnum.List)
                    {
                        var listItem = multi.Read(item.Type).ToList();
                        ((IDictionary<string, object>)data).Add(item.PropertyName, listItem);
                    }
                }

                return data;
            }
        }

        #endregion

        #region Generic Mapper
        public static T GetMapperConfig<T, S>(S stock, bool microMap = false)
        {
            MapperConfiguration config = null;
            if (microMap)
            {
                config = new MapperConfiguration
                (cfg =>
                {
                    cfg.CreateMap<S, T>(MemberList.Destination);
                });
            }
            else
            {
                config = new MapperConfiguration
                (cfg =>
                {
                    cfg.CreateMap<S, T>();
                });
            }

            IMapper iMapper = config.CreateMapper();
            T destination = iMapper.Map<S, T>(stock);
            return destination;
        }

        /// <summary>
        /// Generic Parameter Binding
        /// </summary>
        /// <typeparam name="Destination"></typeparam>
        /// <typeparam name="Source"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static GenericParameter ConstructParameter<Destination, Source>(Source source, Destination destination, GenericParameter parameter)
        {
            Destination dest = GetMapperConfig<Destination, Source>(source);
            foreach (var prop in dest.GetType().GetProperties())
            {
                parameter.InputParameters.Add("@" + prop.Name, prop.GetValue(dest, null));
                //Generate automatically: genericParameter.InputParameters.Add("@Name", model.Name); 
            }
            return parameter;
        }
        #endregion


        #region IDisposable
        /// <inheritdoc />
        /// <summary>
        /// Disposes the current object
        /// </summary>
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connectionString = null;
            }
        }
        #endregion
    }
}
