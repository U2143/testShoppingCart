using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Common 的摘要描述
/// </summary>
public class Common
{
	public static string DBConnectionString
	{
        get
        {
            return System.Web.Configuration.
                WebConfigurationManager.ConnectionStrings["MyDBConnectionString1"].
                ConnectionString;
        }		
	}


}