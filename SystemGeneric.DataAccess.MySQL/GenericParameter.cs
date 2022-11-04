using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SystemGeneric.DataAccess.MySQL
{
    /// <summary>
    /// Class contains generic input parameters
    /// </summary>
    public class GenericParameter
    {
        DynamicParameters _inputParameters;

        /// <summary>
        /// Initialize sql query 
        /// </summary>
        public string SqlCommand
        {
            get; set;
        }

        /// <summary>
        /// Execute type text or stored procedure
        /// </summary>
        public CommandType ExecuteType { get; set; }

        /// <summary>
        /// create instance for dynamic parameters
        /// </summary>
        public DynamicParameters InputParameters => _inputParameters ?? (_inputParameters = new DynamicParameters());

        /// <summary>
        /// Clear objects after assigned
        /// </summary>
        public void Clear()
        {
            _inputParameters = null;
        }

        public Task<IEnumerable<T>> ExecuteQueryListAsync<T>(GenericParameter genericParameter)
        {
            throw new NotImplementedException();
        }
    }
}
