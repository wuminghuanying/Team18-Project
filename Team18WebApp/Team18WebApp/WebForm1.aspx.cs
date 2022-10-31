using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Team18WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection team18connection = new SqlConnection("Server=tcp:team18projectms-server.database.windows.net,1433;Initial Catalog=team18projectms-database;Persist Security Info=False;User ID=team18projectms-server-admin;Password=C4734SM3F76MA575$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            {
                SqlCommand insert = new SqlCommand("EXEC");
            }
        }
    }
}