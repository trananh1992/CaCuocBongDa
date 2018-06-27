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
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.CaCuoc_GetTaiKhoan")]
		public ISingleResult<CaCuoc_GetTaiKhoanResult> CaCuoc_GetTaiKhoan([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="VarChar(10)")] string userName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Type", DbType="Int")] System.Nullable<int> type)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD, userName, type);
			return ((ISingleResult<CaCuoc_GetTaiKhoanResult>)(result.ReturnValue));
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
	
	public partial class CaCuoc_GetTaiKhoanResult
	{
		
		private int _ID;
		
		private string _UserName;
		
		private string _Password;
		
		private string _Email;
		
		private string _FullName;
		
		private int _IsActive;
		
		private System.Nullable<System.DateTime> _DateCreated;
		
		private System.Nullable<System.DateTime> _DateUpdate;
		
		private System.Nullable<decimal> _MoneyExchange;
		
		private System.Nullable<decimal> _Deposits;
		
		private System.Nullable<decimal> _Withdraw;
		
		private System.Nullable<System.DateTime> _DateDeposits;
		
		private System.Nullable<System.DateTime> _DateWithdraw;
		
		public CaCuoc_GetTaiKhoanResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NChar(50)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this._UserName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NChar(200)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this._Password = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NChar(100)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this._Email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullName", DbType="NVarChar(100)")]
		public string FullName
		{
			get
			{
				return this._FullName;
			}
			set
			{
				if ((this._FullName != value))
				{
					this._FullName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="Int NOT NULL")]
		public int IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this._IsActive = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this._DateCreated = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateUpdate", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateUpdate
		{
			get
			{
				return this._DateUpdate;
			}
			set
			{
				if ((this._DateUpdate != value))
				{
					this._DateUpdate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MoneyExchange", DbType="Money")]
		public System.Nullable<decimal> MoneyExchange
		{
			get
			{
				return this._MoneyExchange;
			}
			set
			{
				if ((this._MoneyExchange != value))
				{
					this._MoneyExchange = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Deposits", DbType="Money")]
		public System.Nullable<decimal> Deposits
		{
			get
			{
				return this._Deposits;
			}
			set
			{
				if ((this._Deposits != value))
				{
					this._Deposits = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Withdraw", DbType="Money")]
		public System.Nullable<decimal> Withdraw
		{
			get
			{
				return this._Withdraw;
			}
			set
			{
				if ((this._Withdraw != value))
				{
					this._Withdraw = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateDeposits", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateDeposits
		{
			get
			{
				return this._DateDeposits;
			}
			set
			{
				if ((this._DateDeposits != value))
				{
					this._DateDeposits = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateWithdraw", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateWithdraw
		{
			get
			{
				return this._DateWithdraw;
			}
			set
			{
				if ((this._DateWithdraw != value))
				{
					this._DateWithdraw = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
