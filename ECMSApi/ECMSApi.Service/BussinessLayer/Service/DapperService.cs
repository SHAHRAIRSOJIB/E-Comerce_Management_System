using Dapper;
using ECMSApi.Service.BussinessLayer.Interface;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Service
{
	public class DapperService : IDapperService
	{
		private readonly string connectionString;
		SQLConnectionString _connectionStringService = new SQLConnectionString();
		public DapperService()
		{
			connectionString = _connectionStringService.GetConnectionString("default");
		}

		public virtual IEnumerable<T> GetAllByQuery<T>(string query) where T : class
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				var q = sqlConnection.Query<T>(query).ToList();
				dynamic collectionWrapper = new
				{
					OEBuyerFactName = q
				};
				string output = JsonConvert.SerializeObject(collectionWrapper, Formatting.Indented);
				return q;
			}
		}
		public virtual string GetStringByQuery(string query)
		{

			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				var q = sqlConnection.QueryFirstOrDefault<string>(query);
				return q;
			}
		}

		public IEnumerable<T> GetAllBySP<T>(string procedure, DynamicParameters p) where T : class
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{

				sqlConnection.Open();
				//JsonSerializer jss = new JsonSerializer();
				//jss.MaxJsonLength = Int32.MaxValue;
				var q = sqlConnection.Query<T>(procedure, p, commandType: CommandType.StoredProcedure).ToList();
				dynamic collectionWrapper = new
				{
					OEBuyerFactName = q
				};
				string output = JsonConvert.SerializeObject(collectionWrapper, Formatting.Indented);
				return q;
			}
		}
		public T GetByDynamicSPSingle<T>(string procedure, DynamicParameters p) where T : class
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{

				sqlConnection.Open();
				var q = sqlConnection.Query<T>(procedure, p, commandType: CommandType.StoredProcedure).FirstOrDefault();
				dynamic collectionWrapper = new
				{
					OEBuyerFactName = q
				};
				//string output = JsonSerializer.Serialize(collectionWrapper);
				string output = JsonConvert.SerializeObject(collectionWrapper);
				return q;
			}
		}
		public int Post(string query)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				//JavaScriptSerializer serializer = new JavaScriptSerializer();
				var q = sqlConnection.Execute(query);
				dynamic collectionWrapper = new
				{
					OEBuyerFactName = q
				};
				//serializer.MaxJsonLength = Int32.MaxValue;               
				string output = JsonConvert.SerializeObject(collectionWrapper);
				return q;
			}
		}
		public void GetByMultipleQueryResult(string query, out string ReqQty, out string ActQty)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();

				var q = sqlConnection.QueryMultiple(query);
				ReqQty = q.Read<string>().Single();
				ActQty = q.Read<string>().Single();
			}
		}
		public int UpdateByQuery(string query)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				var q = sqlConnection.Query(query);
				return 1;
			}
		}
	}
}
