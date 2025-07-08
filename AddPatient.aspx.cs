using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;



namespace PatientRegistrationSystem
{


    public partial class AddPatient : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatients();
               
            }
        }

        


        private void LoadPatients()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PatientDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Patients";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                conn.Open();
                da.Fill(dt);
                conn.Close();

                gvPatients.DataSource = dt;
                gvPatients.DataBind();
            }
        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            ExecuteQuery("INSERT");
            LoadPatients();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ExecuteQuery("UPDATE");
            LoadPatients();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ExecuteQuery("DELETE");
            LoadPatients();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ExecuteQuery("SEARCH");
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ExecuteQuery("CLEAR");
        }



        private void ExecuteQuery(string action)
        {

            string connStr = ConfigurationManager.ConnectionStrings["PatientDBConnection"].ConnectionString;


            string name = txtName.Text.Trim();
            string gender = ddlGender.SelectedValue;
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            string notes = txtMedicalNotes.Text.Trim();


            DateTime dob;
            if (!DateTime.TryParse(txtDOB.Text, out dob))
            {
                // Handle invalid date
            }

            int patientId;
            if (!int.TryParse(txtPatientID.Text.Trim(), out patientId))
            {
                patientId = -1;
            }

           

using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;


                if (action == "INSERT")
                {
                    string contact = txtContactNumber.Text.Trim();

                    if (contact.Length != 10 || !contact.All(char.IsDigit))
                    {
                        Response.Write("<script>alert('Please enter a valid 10-digit contact number.');</script>");
                        return;
                    }


                    cmd.CommandText = @"INSERT INTO Patients (Name, Gender, DOB, ContactNumber, Address, Email, MedicalNotes)
                                VALUES (@Name, @Gender, @DOB, @Contact, @Address, @Email, @Notes)";

                    cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@PatientID", txtPatientID.Text.Trim());
                    //cmd.Parameters.AddWithValue("@PatientID", patientId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Notes", notes);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        // Show confirmation message
                        Response.Write("<script>alert('Patient registered successfully!');</script>");


                    }
                    catch (SqlException ex)
                    {
                        Response.Write("insertion failed: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                    // Clear the form


                    txtName.Text = "";
                    ddlGender.SelectedIndex = 0;
                    txtDOB.Text = "";
                    txtContactNumber.Text = "";
                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtMedicalNotes.Text = "";


                }
                else if (action == "UPDATE")
                {
                    string contact = txtContactNumber.Text.Trim();

                    if (contact.Length != 10 || !contact.All(char.IsDigit))
                    {
                        Response.Write("<script>alert('Please enter a valid 10-digit contact number.');</script>");
                        return;
                    }

                    cmd.CommandText = @"UPDATE Patients SET Name=@Name, Gender=@Gender, DOB=@DOB, ContactNumber=@Contact, 
                                Address=@Address, Email=@Email, MedicalNotes=@Notes WHERE PatientID=@PatientID";

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Notes", notes);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        // Show confirmation message
                        Response.Write("<script>alert('Patient updated successfully!');</script>");


                    }
                    catch (SqlException ex)
                    {
                        Response.Write("updation failed: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }


// Clear the form
                    txtPatientID.Text = "";
                    txtName.Text = "";
                    ddlGender.SelectedIndex = 0;
                    txtDOB.Text = "";
                    txtContactNumber.Text = "";
                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtMedicalNotes.Text = "";


                }
                else if (action == "DELETE")
                {
                    string contact = txtContactNumber.Text.Trim();
                    cmd.CommandText = "DELETE FROM Patients WHERE PatientID=@PatientID";
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Notes", notes);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        // Show confirmation message
                        Response.Write("<script>alert('Patient deleted successfully!');</script>");


                    }
                    catch (SqlException ex)
                    {
                        Response.Write("deletion failed: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }


// Clear the form
                    txtPatientID.Text = "";
                    txtName.Text = "";
                    ddlGender.SelectedIndex = 0;
                    txtDOB.Text = "";
                    txtContactNumber.Text = "";
                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtMedicalNotes.Text = "";

                }



                //Search using only PatientID
                //if (action == "SEARCH")
                // {
                //     cmd.CommandText = "SELECT PatientID, Name, Gender, DOB, ContactNumber, Address, Email, MedicalNotes FROM Patients WHERE PatientID = @PatientID";

                //     cmd.Parameters.Clear();
                //     cmd.Parameters.AddWithValue("@PatientID", txtPatientID.Text.Trim());

                //     try
                //     {
                //         conn.Open();

                //         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //         DataTable dt = new DataTable();
                //         adapter.Fill(dt);

                //         if (dt.Rows.Count > 0)
                //         {
                //             // Fill form fields (optional)
                //             DataRow row = dt.Rows[0];
                //             txtName.Text = row["Name"].ToString();
                //             ddlGender.SelectedValue = row["Gender"].ToString();
                //             txtDOB.Text = Convert.ToDateTime(row["DOB"]).ToString("yyyy-MM-dd");
                //             txtContactNumber.Text = row["ContactNumber"].ToString();
                //             txtAddress.Text = row["Address"].ToString();
                //             txtEmail.Text = row["Email"].ToString();
                //             txtMedicalNotes.Text = row["MedicalNotes"].ToString();

                //             // Bind to GridView
                //             gvPatients.DataSource = dt;
                //             gvPatients.DataBind();

                //             txtPatientID.Enabled = true;
                //         }
                //         else
                //         {
                //             // Clear form fields
                //             txtName.Text = "";
                //             ddlGender.SelectedIndex = -1;
                //             txtDOB.Text = "";
                //             txtContactNumber.Text = "";
                //             txtAddress.Text = "";
                //             txtEmail.Text = "";
                //             txtMedicalNotes.Text = "";

                //             gvPatients.DataSource = "";
                //             gvPatients.DataBind();

                //             txtPatientID.Enabled = true;

                //             // Optionally: show message
                //             // lblMessage.Text = "Patient not found.";
                //         }
                //     }
                //     catch (SqlException ex)
                //     {
                //         Response.Write("Search failed: " + ex.Message);
                //     }
                //     finally
                //     {
                //         conn.Close();
                //     }
                // }


                //Search using both PatientID and Patient name
                if (action == "SEARCH")
                {
                    string contact = txtContactNumber.Text.Trim();
                    cmd.CommandText = "SELECT PatientID, Name, Gender, DOB, ContactNumber, Address, Email, MedicalNotes " +
                                      "FROM Patients " +
                                      "WHERE PatientID = @PatientID AND Name = @Name";

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PatientID", txtPatientID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());

                    try
                    {
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            // Fill form fields (optional)
                            DataRow row = dt.Rows[0];
                            txtName.Text = row["Name"].ToString();
                            ddlGender.SelectedValue = row["Gender"].ToString();
                            txtDOB.Text = Convert.ToDateTime(row["DOB"]).ToString("yyyy-MM-dd");
                            txtContactNumber.Text = row["ContactNumber"].ToString();
                            txtAddress.Text = row["Address"].ToString();
                            txtEmail.Text = row["Email"].ToString();
                            txtMedicalNotes.Text = row["MedicalNotes"].ToString();

                            // Fill report labels
                            lblReportPatientID.Text = row["PatientID"].ToString();
                            lblReportName.Text = row["Name"].ToString();
                            lblReportGender.Text = row["Gender"].ToString();
                            lblReportDOB.Text = Convert.ToDateTime(row["DOB"]).ToString("dd-MM-yyyy");
                            lblReportContact.Text = row["ContactNumber"].ToString();
                            lblReportAddress.Text = row["Address"].ToString();

                            pnlReport.Visible = true;

                            // Bind to GridView
                            gvPatients.DataSource = dt;
                            gvPatients.DataBind();

                            txtPatientID.Enabled = true;
                        }
                        else
                        {

                            // Handle "not found"
                            pnlReport.Visible = false; // hide report panel if not found

                            // Clear form fields
                            txtName.Text = "";
                            ddlGender.SelectedIndex = -1;
                            txtDOB.Text = "";
                            txtContactNumber.Text = "";
                            txtAddress.Text = "";
                            txtEmail.Text = "";
                            txtMedicalNotes.Text = "";

                            gvPatients.DataSource = null;
                            gvPatients.DataBind();

                            txtPatientID.Enabled = true;

                            // Optional message
                            // lblMessage.Text = "Patient not found.";
                        }
                    }
                    catch (SqlException ex)
                    {
                        Response.Write("Search failed: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }



                if (action == "CLEAR")
                {
            txtPatientID.Text = "";
            txtName.Text = "";
            ddlGender.SelectedIndex = -1; // Or 0 if you have a default option
            txtDOB.Text = "";
            txtContactNumber.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtMedicalNotes.Text = "";

            // Optional: also clear GridView
            gvPatients.DataSource = "";
            gvPatients.DataBind();
        }

}
}
}
}