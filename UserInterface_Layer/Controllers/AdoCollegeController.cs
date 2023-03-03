//using DataAccess_Layer.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
//using System.Data;
//using System.Reflection;

//namespace UserInterface_Layer.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AdoCollegeController : ControllerBase
//    {
//         string ConnectionInformation = "Data Source=MLI01139;Initial Catalog=Clg_Dept_Student_Db;User ID=sa;Password=***********;Integrated security=True;Trusted_Connection=True;TrustServerCertificate=True";

//        // string ConnectionInformation= ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
//     //   string ConnectionInformation = Configuration["ConnectionStrings:DefaultConnection"];

//        public SqlConnection MainConnection;
//        public AdoCollegeController()
//        {
//            MainConnection = new SqlConnection(ConnectionInformation);
//            MainConnection.Open();
//        }



//        [HttpGet]
//        public IActionResult GetAllUsers()
//        {

//            DataTable dt = new DataTable();
//            string MyCommand = "Select * from College";
//            SqlCommand myCommand = new SqlCommand(MyCommand, MainConnection);
//            SqlDataAdapter da = new SqlDataAdapter(myCommand);
//            da.Fill(dt);

//            List<College> entities = new List<College>(dt.Rows.Count);
//            if (dt.Rows.Count > 0)
//            {
//                foreach (DataRow record in dt.Rows)
//                {
//                    College item = GetItem<College>(record);
//                    entities.Add(item);
//                }

//            }
//            return Ok(entities);
          
//        }
//        private static College GetItem<T>(DataRow dr)
//        {
//            Type temp = typeof(College);
//            College obj = Activator.CreateInstance<College>();

//            foreach (DataColumn column in dr.Table.Columns)
//            {
//                foreach (PropertyInfo pro in temp.GetProperties())
//                {
//                    if (pro.Name == column.ColumnName)
//                        pro.SetValue(obj, dr[column.ColumnName], null);
//                    else
//                        continue;
//                }
//            }
//            return obj;
//        }

//        [HttpGet("GetById{Id}")]
//        public IActionResult GetCollegeById(int Id)
//        {
//            DataTable dt = new DataTable();
//            string MyCommand = "Select * from College where Cid=" + Id;
//            SqlCommand myCommand = new SqlCommand(MyCommand, MainConnection);
//            SqlDataAdapter da = new SqlDataAdapter(myCommand);
//            da.Fill(dt);

//            List<College> entities = new List<College>(dt.Rows.Count);
//            if (dt.Rows.Count > 0)
//            {
//                College item = GetItem<College>(dt.Rows[0]);
//                entities.Add(item);
//            }
//            else return null;

//            return Ok(entities);
//        }

//        [HttpPost]
//        public IActionResult Add([FromBody] College college)
//        {
//            string InsertCommand = "INSERT INTO College (Cid,Cname,Caddress,Czipcode,ActiveFlag,CreatedDate,CreatedBy,ModifiedBy,ModifiedDate) VALUES(@Cid,@Cname,@Caddress,@Czipcode,@ActiveFlag,@CreatedDate,@Createdby,@ModifiedBy,@ModifiedDate)";
//            try
//            {
//                SqlCommand insertCommand = new SqlCommand(InsertCommand, MainConnection);
//                insertCommand.Parameters.AddWithValue("@Cid", college.Cid);
//                insertCommand.Parameters.AddWithValue("@Cname", college.Cname);
//                insertCommand.Parameters.AddWithValue("@Caddress", college.Caddress);
//                insertCommand.Parameters.AddWithValue("@Czipcode", college.Czipcode);
//                insertCommand.Parameters.AddWithValue("@ActiveFlag", college.ActiveFlag);
//                insertCommand.Parameters.AddWithValue("@CreatedBy", college.CreatedBy);
//                insertCommand.Parameters.AddWithValue("@CreatedDate", college.CreatedDate);
//                insertCommand.Parameters.AddWithValue("@ModifiedBy", college.ModifiedBy);
//                insertCommand.Parameters.AddWithValue("@ModifiedDate", college.ModifiedDate);

//                var result = insertCommand.ExecuteNonQuery();
//                if (result > 0)
//                    return Ok();
//                else
//                    return BadRequest();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                return BadRequest();
//            }
//        }

//    //    [HttpPut]
//    //    public IActionResult Update([FromBody] College college)
//    //    {
//    //        string InsertCommand = "UPDATE Users SET Cname=@Cname,Caddress=@Caddress,Czipcode=@Czipcode WHERE Cid=" + college.Cid;
//    //        try
//    //        {
//    //            SqlCommand insertCommand = new SqlCommand(InsertCommand, MainConnection);
//    //            insertCommand.Parameters.AddWithValue("@Cname", college.Cname);
//    //            insertCommand.Parameters.AddWithValue("@Caddress", college.Caddress);
//    //            insertCommand.Parameters.AddWithValue("@Czipcode", college.Czipcode);

//    //        }
//    //        catch(Exception e)
//    //        {
//    //            throw;
//    //        }
//    //}
//    }
//}

