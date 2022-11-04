using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace SystemGeneric.DataAccess.MySQL
{
    /// <summary>
    ///     Generic Repository interface.
    /// </summary>
    public interface IGenericRepository : IDisposable
    {
        #region Methods implementation
        /// <summary>
        /// Used to execute insert,update,delete sql command
        /// </summary>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        void ExecuteCommand(GenericParameter parameter);
        /// <summary>
        /// Used to execute sql command and return single element
        /// </summary>
        /// <typeparam name="T">model type</typeparam>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        /// <returns>first element from result set</returns>
        T ExecuteScalar<T>(GenericParameter parameter) where T : class;
        /// <summary>
        /// Used to execute sql command and return list of element
        /// </summary>
        /// <typeparam name="T">model type</typeparam>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        /// <returns>list of element from result set</returns>
        IEnumerable<T> ExecuteQueryList<T>(GenericParameter parameter) where T : class;
        /// <summary>
        /// Used to execute sql command and return multiple list of element
        /// </summary>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        dynamic ExecuteQueryMultiple(GenericParameter parameter, IEnumerable<MapItem> mapItems = null);
        #endregion

        #region Async Methods  implementation
        /// <summary>
        /// Its async method used to execute insert,update,delete sql command
        /// </summary>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        void ExecuteCommandAsync(GenericParameter parameter);
        /// <summary>
        /// Its async method used to execute sql command and return single element
        /// </summary>
        /// <typeparam name="T">model type</typeparam>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        /// <returns>first element from result set</returns>
        Task<T> ExecuteScalarAsync<T>(GenericParameter parameter) where T : class;
        /// <summary>
        /// Its async method used to execute sql command and return list of element
        /// </summary>
        /// <typeparam name="T">model type</typeparam>
        /// <param name="parameter">contains sqlcommand,executetype and input parameters</param>
        /// <returns>list of element from result set</returns>
        Task<IEnumerable<T>> ExecuteQueryListAsync<T>(GenericParameter parameter) where T : class;
        Task<dynamic> ExecuteQueryMultipleAsync(GenericParameter parameter, IEnumerable<MapItem> mapItems = null);
        #endregion

        #region Linq Methods
        //Task<IEnumerable<T>> GetListAsync<T>(IFieldPredicate predicate) where T : class;
        #endregion
    }
}
