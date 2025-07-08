<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="PatientRegistrationSystem.AddPatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <html lang="en">

<head runat="server">
    <title>CRUD OPERATION</title>

    

    <%-- Background code --%>
    <style>
    body {
        background: linear-gradient(to right, #e6f0f9, #ffffff);
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        margin: 0;
        padding: 0;
    }

    .container {
        background-color: #ffffff;
        padding: 30px;
        border-radius: 10px;
        box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        margin-top: 50px;
    }

    h1, h2, h3, label {
        color: #004080; /* Deep healthcare blue */
    }

    .btn {
        margin-right: 10px;
    }
</style>



    <%-- for providing space between entries --%>
    <style>
  /* Stack columns on small screens */
  @media (max-width: 768px) {
    .split-table td {
      display: block;
      width: 100% !important;
    }
  }
</style>
    



    <%-- Bootstrap Background requirement --%>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Bootstrap Icons CDN -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />

    
   

</head>
<body>
    <form id="form1" runat="server">


<%-- for top navigation bar --%>
<nav class="navbar navbar-expand-lg navbar-dark bg-primary">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">🏥 Healthcare System</a>


      <%-- for tabs of navigation bar --%>
    <div class="d-flex">
      <button id="btnHome" class="btn btn-light me-2 active" type="button" onclick="setMode('btnHome')">Home</button>
      <button id="btnInsert" class="btn btn-outline-light me-2" type="button" onclick="setMode('btnInsert')">Insert</button>
      <button id="btnUpdate" class="btn btn-outline-light me-2" type="button" onclick="setMode('btnUpdate')">Update</button>
      <button id="btnDelete" class="btn btn-outline-light me-2" type="button" onclick="setMode('btnDelete')">Delete</button>
      <button id="btnSearch" class="btn btn-outline-light" type="button" onclick="setMode('btnSearch')">Search</button>
    </div>
  </div>
</nav>





<div class="container">

        
   <h2>Create Retrieve Update and Delete Operation</h2>

        
       
       <%-- for entries --%>
<table class="w-100 split-table">
  <tr>
    <!-- Left Column -->
    <td style="vertical-align: top; width: 50%; padding-right: 20px;">
      <table class="table table-borderless">
        <tr class="mb-4">
          <td class="pb-3">Enter Patient ID:</td>
          <td class="pb-3">
            <asp:TextBox ID="txtPatientID" runat="server"  placeholder="Patient ID" CssClass="form-control" />
          </td>
        </tr>
        <tr class="mb-4">
          <td class="pb-3">Enter Patient Name:</td>
          <td class="pb-3">
            <asp:TextBox ID="txtName" runat="server" placeholder="Name" CssClass="form-control" />
          </td>
        </tr>
        <tr class="mb-4">
          <td class="pb-3">Enter Gender:</td>
          <td class="pb-3">
            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-select">
              <asp:ListItem Text="Select Gender" Value="" />
              <asp:ListItem Text="Male" Value="Male" />
              <asp:ListItem Text="Female" Value="Female" />
              <asp:ListItem Text="Other" Value="Other" />
            </asp:DropDownList>
          </td>
        </tr>
        <tr class="mb-4">
          <td class="pb-3">Date of Birth:</td>
          <td class="pb-3">
            <div class="input-group">
              <span class="input-group-text">
                <i class="bi bi-calendar-event"></i>
              </span>
              <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
          </td>
        </tr>
      </table>
    </td>

    <!-- Right Column -->
    <td style="vertical-align: top; width: 50%; padding-left: 20px;">
      <table class="table table-borderless">
        <tr class="mb-4">
          <td class="pb-3">Contact Number:</td>
          <td class="pb-3">
            
              <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" 
    MaxLength="10" 
    onkeypress="return isNumberKey(event);" 
    placeholder="Enter 10-digit contact number" />

             


          </td>
        </tr>
        <tr class="mb-4">
          <td class="pb-3">Residential Address:</td>
          <td class="pb-3">
            <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" CssClass="form-control" />
          </td>
        </tr>
        <tr class="mb-4">
          <td class="pb-3">Email:</td>
          <td class="pb-3">
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control" />
          </td>
        </tr>
        <tr class="mb-4">
          <td class="pb-3">Medical Notes:</td>
          <td class="pb-3">
            <asp:TextBox ID="txtMedicalNotes" runat="server" placeholder="Notes" TextMode="MultiLine" Rows="3" CssClass="form-control" />
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>


    <%-- for buttons --%>

            <div class="d-flex justify-content-center flex-wrap gap-3 my-4">
    <asp:Button ID="btnInsertAction" runat="server" Text="Insert" CssClass="btn btn-success" OnClick="btnInsert_Click" />
    <asp:Button ID="btnUpdateAction" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnDeleteAction" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
    <asp:Button ID="btnSearchAction" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
</div>


    <%-- for report printout --%>
    <asp:Panel ID="pnlReport" runat="server" CssClass="border p-3 my-3" Visible="false">
    <h4 class="text-center">🩺 Patient Report</h4>
    <hr />
    <p><strong>Patient ID:</strong> <asp:Label ID="lblReportPatientID" runat="server" /></p>
    <p><strong>Name:</strong> <asp:Label ID="lblReportName" runat="server" /></p>
    <p><strong>Gender:</strong> <asp:Label ID="lblReportGender" runat="server" /></p>
    <p><strong>Date of Birth:</strong> <asp:Label ID="lblReportDOB" runat="server" /></p>
    <p><strong>Contact Number:</strong> <asp:Label ID="lblReportContact" runat="server" /></p>
    <p><strong>Address:</strong> <asp:Label ID="lblReportAddress" runat="server" /></p>

    <div class="text-center mt-3">
        <button type="button" class="btn btn-outline-primary" onclick="printReport()">🖨️ Print Report</button>
    </div>
</asp:Panel>




<h2>view</h2>


<tr>
  <td colspan="2">
    <div class="d-flex justify-content-center my-4">
      <div style="min-width: 80%; max-width: 1000px;">
        <asp:GridView
          ID="gvPatients"
          runat="server"
          AutoGenerateColumns="False"
          EmptyDataText="No records found."
          CssClass="table table-bordered table-striped text-center"
          GridLines="None">
          
          <Columns>
            <asp:BoundField DataField="PatientID" HeaderText="Patient ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="DOB" HeaderText="Date of Birth"
                            DataFormatString="{0:MM-dd-yyyy}" HtmlEncode="False" />
            <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
              

            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="MedicalNotes" HeaderText="Medical Notes" />
          </Columns>
        </asp:GridView>
      </div>
    </div>
  </td>
</tr>


</table>


</div>


 



        <script>
  // Map tab ID to action button ID
  const tabToButtonMap = {
    btnHome: null,
    btnInsert: 'btnInsertAction',
    btnUpdate: 'btnUpdateAction',
    btnDelete: 'btnDeleteAction',
    btnSearch: 'btnSearchAction'
  };

  function setMode(tabId) {
    // Disable/Enable PatientID based on tab
    const patientId = document.getElementById('<%= txtPatientID.ClientID %>');
    patientId.disabled = (tabId === 'btnHome' || tabId === 'btnInsert');

    // Highlight selected tab
    document.querySelectorAll('.navbar .btn').forEach(btn => {
      btn.classList.remove('btn-light', 'active');
      btn.classList.add('btn-outline-light');
    });
    document.getElementById(tabId).classList.remove('btn-outline-light');
    document.getElementById(tabId).classList.add('btn-light', 'active');

    // Disable all action buttons except the one that matches the tab
    ['btnInsertAction', 'btnUpdateAction', 'btnDeleteAction', 'btnSearchAction'].forEach(actionId => {
      document.getElementById(actionId).disabled = (tabToButtonMap[tabId] !== actionId);
    });

    // Clear button always enabled
    document.getElementById('btnClear').disabled = false;
  }

  // Call this on page load to activate Home tab
  window.onload = function () {
    setMode('btnHome');
  };
</script>



        <%-- ContactNumber --%>
<script>
  function isNumberKey(evt) {
    var charCode = evt.which || evt.keyCode;
    return charCode >= 48 && charCode <= 57; // allows only 0–9
  }
</script>


</form>


    <script>
  function printReport() {
    var printContents = document.getElementById('<%= pnlReport.ClientID %>').innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;
    window.print();
    document.body.innerHTML = originalContents;
    location.reload(); // Refresh to restore event handlers if needed
  }
</script>

    

   </body>
</html>