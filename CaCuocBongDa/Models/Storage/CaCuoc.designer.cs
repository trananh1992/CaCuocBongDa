﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaCuocBongDa.Models.Storage
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CaCuocBongDa")]
	public partial class CaCuocDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public CaCuocDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["CaCuocBongDaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CaCuocDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CaCuocDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CaCuocDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CaCuocDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.CaCuoc_InsertOrUpdate")]
		public ISingleResult<CaCuoc_InsertOrUpdateResult> CaCuoc_InsertOrUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InputValue", DbType="NVarChar(MAX)")] string inputValue, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Type", DbType="Int")] System.Nullable<int> type)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), inputValue, type);
			return ((ISingleResult<CaCuoc_InsertOrUpdateResult>)(result.ReturnValue));
		}
	}
	
	public partial class CaCuoc_InsertOrUpdateResult
	{
		
		private int _Result;
		
		public CaCuoc_InsertOrUpdateResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Result", DbType="Int NOT NULL")]
		public int Result
		{
			get
			{
				return this._Result;
			}
			set
			{
				if ((this._Result != value))
				{
					this._Result = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
