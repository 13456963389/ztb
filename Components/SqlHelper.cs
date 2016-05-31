using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ZtbSoft
{
    /// <summary>
    /// SqlServer数据访问帮助类   
    /// </summary>
    public sealed class SqlHelper
    {
        #region 私有构造函数和方法
        private SqlHelper() { }

        /// <summary>   
        /// 将SqlParameter参数数组(参数值)分配给SqlCommand命令.   
        /// 这个方法将给任何一个参数分配DBNull.Value;   
        /// 该操作将阻止默认值的使用.   
        /// </summary>   
        /// <param name="command">命令名</param>   
        /// <param name="commandParameters">SqlParameters数组</param>   
        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.   
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }
        /// <summary>   
        /// 预处理用户提供的命令,数据库连接/事务/命令类型/参数   
        /// </summary>   
        /// <param name="command">要处理的SqlCommand</param>   
        /// <param name="connection">数据库连接</param>   
        /// <param name="transaction">一个有效的事务或者是null值</param>   
        /// <param name="commandType">命令类型 (存储过程,命令文本, 其它.)</param>   
        /// <param name="commandText">存储过程名或都T-SQL命令文本</param>   
        /// <param name="commandParameters">和命令相关联的SqlParameter参数数组,如果没有参数为'null'</param>   
        /// <param name="mustCloseConnection"><c>true</c> 如果连接是打开的,则为true,其它情况下为false.</param>   
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType,
            string commandText, SqlParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it   
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // 给命令分配一个数据库连接.   
            command.Connection = connection;

            // 设置命令文本(存储过程名或SQL语句)   
            command.CommandText = commandText;

            // 分配事务   
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // 设置命令类型.   
            command.CommandType = commandType;

            // 分配命令参数   
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        #endregion

        #region 数据库连接
        /// <summary>   
        /// 一个有效的数据库连接字符串   
        /// </summary>   
        /// <returns></returns>   
        public static string GetConnSting()
        {
            return ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
        /// <summary>   
        /// 一个有效的数据库连接对象   
        /// </summary>   
        /// <returns></returns>   
        public static SqlConnection GetConnection()
        {
            SqlConnection Connection = new SqlConnection(SqlHelper.GetConnSting());
            return Connection;
        }
        #endregion

        #region 返回命令影响的行数


        /// <summary>
        /// 返回命令影响的行数
        /// </summary>
        /// <param name="commandType">命令类型 (存储过程,命令文本, 其它.)</param> 
        /// <param name="commandText">存储过程名称或SQL语句</param> 
        /// <param name="commandParameters">SqlParameter参数数组</param> 
        /// <returns>返回命令影响的行数</returns> 
        public static int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                if (connection == null) throw new ArgumentNullException("connection");

                // 创建SqlCommand命令,并进行预处理 
                SqlCommand cmd = new SqlCommand();
                bool mustCloseConnection = false;
                PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

                // Finally, execute the command 
                int retval = cmd.ExecuteNonQuery();

                // 清除参数,以便再次使用. 
                cmd.Parameters.Clear();
                if (mustCloseConnection)
                    connection.Close();
                return retval;
            }
        }
        /// <summary>
        /// 返回命令影响的行数
        /// </summary>
        /// <param name="commandType">命令类型 (存储过程,命令文本, 其它.)</param> 
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <returns>返回命令影响的行数</returns> 
        public static int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(commandType, commandText, (SqlParameter[])null);
        }
        /// <summary>
        /// 返回命令影响的行数
        /// </summary>        
        /// <param name="commandText">SQL语句</param>
        /// <returns>返回命令影响的行数</returns> 
        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, (SqlParameter[])null);
        }

        /// <summary>
        /// 返回命令影响的行数
        /// </summary>        
        /// <param name="commandText">SQL语句</param> 
        /// <param name="commandParameters">SqlParameter参数数组</param> 
        /// <returns>返回命令影响的行数</returns> 
        public static int ExecuteNonQuery(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, commandParameters);
        }

        #endregion

        #region 返回DataSet或DataTable

        /// <summary> 
        /// 执行指定数据库连接对象的命令,指定存储过程参数,返回DataSet. 
        /// </summary> 
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param> 
        /// <param name="commandText">存储过程名或T-SQL语句</param> 
        /// <param name="commandParameters">SqlParamter参数数组</param> 
        /// <returns>返回一个包含结果集的DataSet</returns> 
        public static DataSet ExecuteDataSet(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                if (connection == null) throw new ArgumentNullException("connection");

                // 预处理 
                SqlCommand cmd = new SqlCommand();
                bool mustCloseConnection = false;
                PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

                // 创建SqlDataAdapter和DataSet. 
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();

                    // 填充DataSet. 
                    da.Fill(ds);

                    cmd.Parameters.Clear();

                    if (mustCloseConnection)
                        connection.Close();

                    return ds;
                }

            }
        }
        /// <summary> 
        /// 执行指定数据库连接对象的命令,指定存储过程参数,返回DataTable. 
        /// </summary> 
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param> 
        /// <param name="commandText">存储过程名或T-SQL语句</param> 
        /// <param name="commandParameters">SqlParamter参数数组</param> 
        /// <returns>返回一个包含结果集的DataTable</returns> 
        public static DataTable ExecuteDataTable(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(commandType, commandText, commandParameters).Tables[0];
        }
        /// <summary> 
        /// 执行指定数据库连接对象的命令,指定存储过程参数,返回DataTable. 
        /// </summary> 
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param> 
        /// <param name="commandText">存储过程名或T-SQL语句</param> 
        /// <returns>返回一个包含结果集的DataTable</returns> 
        public static DataTable ExecuteDataTable(CommandType commandType, string commandText)
        {
            return ExecuteDataSet(commandType, commandText, (SqlParameter[])null).Tables[0];
        }

        /// <summary> 
        /// 执行指定数据库连接对象的命令,指定SQL语句
        /// </summary>         
        /// <param name="commandText">T-SQL语句</param> 
        /// <returns>返回一个包含结果集的DataTable</returns> 
        public static DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataSet(CommandType.Text, commandText, (SqlParameter[])null).Tables[0];
        }
        /// <summary> 
        /// 指定SQL语句,返回DataTable. 
        /// </summary> 
        /// <param name="commandText">T-SQL语句</param> 
        /// <param name="commandParameters">SqlParamter参数数组</param> 
        /// <returns>返回一个包含结果集的DataTable</returns> 
        public static DataTable ExecuteDataTable(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(CommandType.Text, commandText, commandParameters).Tables[0];
        }

        #endregion

        #region ExecuteScalar 返回结果集中的第一行第一列

        /// <summary>
        /// 返回结果集中的第一行第一列
        /// </summary>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param> 
        /// <param name="commandText">存储过程名称或T-SQL语句</param> 
        /// <returns></returns>
        public static object ExecuteScalar(CommandType commandType, string commandText)
        {
            // 执行参数为空的方法 
            return ExecuteScalar(commandType, commandText, (SqlParameter[])null);
        }

        /// <summary>
        /// 返回结果集中的第一行第一列
        /// </summary>
        /// <param name="commandText">T-SQL语句</param> 
        /// <returns></returns>
        public static object ExecuteScalar(string commandText)
        {
            // 执行参数为空的方法 
            return ExecuteScalar(CommandType.Text, commandText, (SqlParameter[])null);
        }
        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回结果集中的第一行第一列. 
        /// </summary>        
        /// <param name="commandText">T-SQL语句</param> 
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param> 
        /// <returns>返回结果集中的第一行第一列</returns> 
        public static object ExecuteScalar(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回结果集中的第一行第一列. 
        /// </summary>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param> 
        /// <param name="commandText">存储过程名称或T-SQL语句</param> 
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param> 
        /// <returns>返回结果集中的第一行第一列</returns> 
        public static object ExecuteScalar(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            // 创建并打开数据库连接对象,操作完成释放对象. 
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                // 调用指定数据库连接字符串重载方法. 
                if (connection == null) throw new ArgumentNullException("connection");

                // 创建SqlCommand命令,并进行预处理 
                SqlCommand cmd = new SqlCommand();

                bool mustCloseConnection = false;
                PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

                // 执行SqlCommand命令,并返回结果. 
                object retval = cmd.ExecuteScalar();

                // 清除参数,以便再次使用. 
                cmd.Parameters.Clear();

                if (mustCloseConnection)
                    connection.Close();

                return retval;
            }
        }

        #endregion


        #region 得到存在过程返回值(return)
        /// <summary>
        /// 得到 Return 返回值
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="commandParameters">参数  不用带 @ReturnValue 参数</param>
        /// <returns>Return 返回值</returns>
        public static int ExecutReturnValue(string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                if (connection == null) throw new ArgumentNullException("connection");

                // 创建SqlCommand命令,并进行预处理 
                SqlCommand cmd = new SqlCommand();
                bool mustCloseConnection = false;


                //添加 返回值参数
                List<SqlParameter> list = new List<SqlParameter>(commandParameters);
                SqlParameter returnPar = new SqlParameter("@ReturnValue", SqlDbType.Int);
                returnPar.Direction = ParameterDirection.ReturnValue;
                list.Add(returnPar);
                commandParameters = list.ToArray();


                PrepareCommand(cmd, connection, (SqlTransaction)null, CommandType.StoredProcedure,
                    commandText, commandParameters, out mustCloseConnection);

                // Finally, execute the command 
                cmd.ExecuteNonQuery();
                int retval = int.Parse(cmd.Parameters["@ReturnValue"].Value.ToString());
                // 清除参数,以便再次使用. 
                cmd.Parameters.Clear();
                if (mustCloseConnection)
                    connection.Close();
                return retval;
            }
        }

        #endregion


        public static object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

    }
}
