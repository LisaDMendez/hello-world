using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;


namespace WA_BuildFromSchema
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormTest : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.TextBox txtConnect;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckedListBox clbColumns;
		private System.Windows.Forms.ComboBox cbxTimeStamp;
		private System.Windows.Forms.ComboBox cbxKey;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtStrip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnUse;
		private System.Windows.Forms.ListBox lbxTables;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnOpenFile;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnCreate;

		protected DataSchema oSchema = new DataSchema();
		protected FileStream fsWriteFile;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox chkBoxSP_SelectOne;
		private System.Windows.Forms.CheckBox cbxSP_Update;
		private System.Windows.Forms.CheckBox cbxSP_Insert;
		private System.Windows.Forms.CheckBox cbxSP_Select;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox cbxUpdate;
		private System.Windows.Forms.CheckBox cbxInsert;
		private System.Windows.Forms.CheckBox cbxRtnDS;
		private System.Windows.Forms.CheckBox cbxRtnReader;
		private System.Windows.Forms.CheckBox cbxRtnOne;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox ckbxRtnOneParams;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtStripTable;
		protected StreamWriter swOutput;

		public FormTest()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				try //close objects data connection
				{
					oSchema.CloseObject();
				}
				catch
				{}

				try //close text output file
				{
					//clean up
					swOutput.Flush();
					swOutput.Close();
					fsWriteFile.Close();
				}
				catch{}

				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.txtConnect = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtStripTable = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.clbColumns = new System.Windows.Forms.CheckedListBox();
			this.cbxTimeStamp = new System.Windows.Forms.ComboBox();
			this.cbxKey = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtStrip = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnUse = new System.Windows.Forms.Button();
			this.lbxTables = new System.Windows.Forms.ListBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnCreate = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.chkBoxSP_SelectOne = new System.Windows.Forms.CheckBox();
			this.cbxSP_Update = new System.Windows.Forms.CheckBox();
			this.cbxSP_Insert = new System.Windows.Forms.CheckBox();
			this.cbxSP_Select = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.ckbxRtnOneParams = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbxUpdate = new System.Windows.Forms.CheckBox();
			this.cbxInsert = new System.Windows.Forms.CheckBox();
			this.cbxRtnDS = new System.Windows.Forms.CheckBox();
			this.cbxRtnReader = new System.Windows.Forms.CheckBox();
			this.cbxRtnOne = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnConnect,
																					this.txtConnect,
																					this.label4});
			this.groupBox1.Location = new System.Drawing.Point(16, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(616, 100);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(24, 64);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.TabIndex = 17;
			this.btnConnect.Text = "Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// txtConnect
			// 
			this.txtConnect.Location = new System.Drawing.Point(16, 40);
			this.txtConnect.Name = "txtConnect";
			this.txtConnect.Size = new System.Drawing.Size(568, 20);
			this.txtConnect.TabIndex = 16;
			this.txtConnect.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 23);
			this.label4.TabIndex = 15;
			this.label4.Text = "Provide Connection String";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtStripTable,
																					this.label7,
																					this.clbColumns,
																					this.cbxTimeStamp,
																					this.cbxKey,
																					this.label3,
																					this.label2,
																					this.txtStrip,
																					this.label1,
																					this.btnUse,
																					this.lbxTables});
			this.groupBox2.Location = new System.Drawing.Point(16, 112);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(624, 288);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			// 
			// txtStripTable
			// 
			this.txtStripTable.Enabled = false;
			this.txtStripTable.Location = new System.Drawing.Point(472, 176);
			this.txtStripTable.Name = "txtStripTable";
			this.txtStripTable.TabIndex = 22;
			this.txtStripTable.Tag = "";
			this.txtStripTable.Text = "7";
			// 
			// label7
			// 
			this.label7.Enabled = false;
			this.label7.Location = new System.Drawing.Point(472, 136);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(120, 40);
			this.label7.TabIndex = 21;
			this.label7.Text = "Num of Chars to Strip of common text from each table name";
			// 
			// clbColumns
			// 
			this.clbColumns.Enabled = false;
			this.clbColumns.Location = new System.Drawing.Point(272, 32);
			this.clbColumns.Name = "clbColumns";
			this.clbColumns.Size = new System.Drawing.Size(184, 199);
			this.clbColumns.TabIndex = 20;
			// 
			// cbxTimeStamp
			// 
			this.cbxTimeStamp.Enabled = false;
			this.cbxTimeStamp.Location = new System.Drawing.Point(472, 104);
			this.cbxTimeStamp.Name = "cbxTimeStamp";
			this.cbxTimeStamp.Size = new System.Drawing.Size(121, 21);
			this.cbxTimeStamp.TabIndex = 19;
			this.cbxTimeStamp.Text = "NONE";
			// 
			// cbxKey
			// 
			this.cbxKey.Enabled = false;
			this.cbxKey.Location = new System.Drawing.Point(472, 40);
			this.cbxKey.Name = "cbxKey";
			this.cbxKey.Size = new System.Drawing.Size(121, 21);
			this.cbxKey.TabIndex = 18;
			this.cbxKey.Text = "NONE";
			// 
			// label3
			// 
			this.label3.Enabled = false;
			this.label3.Location = new System.Drawing.Point(472, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 24);
			this.label3.TabIndex = 17;
			this.label3.Text = "Indicate Column to receive Current TimeStamp";
			// 
			// label2
			// 
			this.label2.Enabled = false;
			this.label2.Location = new System.Drawing.Point(472, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.TabIndex = 16;
			this.label2.Text = "Indicate Key Column";
			// 
			// txtStrip
			// 
			this.txtStrip.Enabled = false;
			this.txtStrip.Location = new System.Drawing.Point(472, 248);
			this.txtStrip.Name = "txtStrip";
			this.txtStrip.TabIndex = 15;
			this.txtStrip.Tag = "";
			this.txtStrip.Text = "3";
			// 
			// label1
			// 
			this.label1.Enabled = false;
			this.label1.Location = new System.Drawing.Point(472, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 40);
			this.label1.TabIndex = 14;
			this.label1.Text = "Num of Chars to Strip of common text from each field name";
			// 
			// btnUse
			// 
			this.btnUse.Enabled = false;
			this.btnUse.Location = new System.Drawing.Point(8, 249);
			this.btnUse.Name = "btnUse";
			this.btnUse.Size = new System.Drawing.Size(248, 23);
			this.btnUse.TabIndex = 13;
			this.btnUse.Text = "Use This Table";
			this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
			// 
			// lbxTables
			// 
			this.lbxTables.Enabled = false;
			this.lbxTables.Location = new System.Drawing.Point(8, 33);
			this.lbxTables.Name = "lbxTables";
			this.lbxTables.Size = new System.Drawing.Size(248, 199);
			this.lbxTables.TabIndex = 12;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnOpenFile,
																					this.txtFileName,
																					this.label5});
			this.groupBox3.Location = new System.Drawing.Point(16, 408);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(624, 80);
			this.groupBox3.TabIndex = 17;
			this.groupBox3.TabStop = false;
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.Location = new System.Drawing.Point(32, 56);
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.TabIndex = 20;
			this.btnOpenFile.Text = "Open File";
			this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(28, 32);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(568, 20);
			this.txtFileName.TabIndex = 19;
			this.txtFileName.Text = "C:\\temp\\Lisatemp.txt";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(28, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(152, 23);
			this.label5.TabIndex = 18;
			this.label5.Text = "File to Write Text to:";
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(560, 712);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.TabIndex = 27;
			this.btnCreate.Text = "Create";
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.chkBoxSP_SelectOne,
																					this.cbxSP_Update,
																					this.cbxSP_Insert,
																					this.cbxSP_Select});
			this.groupBox4.Location = new System.Drawing.Point(16, 504);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(176, 160);
			this.groupBox4.TabIndex = 29;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Stored Procs To Write";
			// 
			// chkBoxSP_SelectOne
			// 
			this.chkBoxSP_SelectOne.Location = new System.Drawing.Point(24, 56);
			this.chkBoxSP_SelectOne.Name = "chkBoxSP_SelectOne";
			this.chkBoxSP_SelectOne.Size = new System.Drawing.Size(120, 24);
			this.chkBoxSP_SelectOne.TabIndex = 32;
			this.chkBoxSP_SelectOne.Text = "SP_Select_ONE";
			// 
			// cbxSP_Update
			// 
			this.cbxSP_Update.Location = new System.Drawing.Point(24, 120);
			this.cbxSP_Update.Name = "cbxSP_Update";
			this.cbxSP_Update.TabIndex = 31;
			this.cbxSP_Update.Text = "SP_Update";
			// 
			// cbxSP_Insert
			// 
			this.cbxSP_Insert.Location = new System.Drawing.Point(24, 88);
			this.cbxSP_Insert.Name = "cbxSP_Insert";
			this.cbxSP_Insert.TabIndex = 30;
			this.cbxSP_Insert.Text = "SP_Insert";
			// 
			// cbxSP_Select
			// 
			this.cbxSP_Select.Location = new System.Drawing.Point(24, 24);
			this.cbxSP_Select.Name = "cbxSP_Select";
			this.cbxSP_Select.TabIndex = 29;
			this.cbxSP_Select.Text = "SP_Select_ALL";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.ckbxRtnOneParams,
																					this.label6,
																					this.cbxUpdate,
																					this.cbxInsert,
																					this.cbxRtnDS,
																					this.cbxRtnReader,
																					this.cbxRtnOne});
			this.groupBox5.Location = new System.Drawing.Point(208, 504);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(424, 160);
			this.groupBox5.TabIndex = 30;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Methods to Write";
			// 
			// ckbxRtnOneParams
			// 
			this.ckbxRtnOneParams.Location = new System.Drawing.Point(24, 48);
			this.ckbxRtnOneParams.Name = "ckbxRtnOneParams";
			this.ckbxRtnOneParams.Size = new System.Drawing.Size(168, 24);
			this.ckbxRtnOneParams.TabIndex = 34;
			this.ckbxRtnOneParams.Text = "Rtn One OutParams Routine";
			this.ckbxRtnOneParams.Visible = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(400, 23);
			this.label6.TabIndex = 33;
			this.label6.Text = "You must add own connection and means to open.  This takes care of params.";
			// 
			// cbxUpdate
			// 
			this.cbxUpdate.Location = new System.Drawing.Point(272, 56);
			this.cbxUpdate.Name = "cbxUpdate";
			this.cbxUpdate.TabIndex = 31;
			this.cbxUpdate.Text = "Update Routine";
			// 
			// cbxInsert
			// 
			this.cbxInsert.Location = new System.Drawing.Point(272, 24);
			this.cbxInsert.Name = "cbxInsert";
			this.cbxInsert.TabIndex = 30;
			this.cbxInsert.Text = "Insert Routine";
			// 
			// cbxRtnDS
			// 
			this.cbxRtnDS.Location = new System.Drawing.Point(24, 96);
			this.cbxRtnDS.Name = "cbxRtnDS";
			this.cbxRtnDS.Size = new System.Drawing.Size(152, 24);
			this.cbxRtnDS.TabIndex = 29;
			this.cbxRtnDS.Text = "RtnAll_DataSet Routine";
			// 
			// cbxRtnReader
			// 
			this.cbxRtnReader.Location = new System.Drawing.Point(24, 72);
			this.cbxRtnReader.Name = "cbxRtnReader";
			this.cbxRtnReader.Size = new System.Drawing.Size(152, 24);
			this.cbxRtnReader.TabIndex = 28;
			this.cbxRtnReader.Text = "RtnAll_Reader Routine";
			// 
			// cbxRtnOne
			// 
			this.cbxRtnOne.Location = new System.Drawing.Point(24, 24);
			this.cbxRtnOne.Name = "cbxRtnOne";
			this.cbxRtnOne.Size = new System.Drawing.Size(160, 24);
			this.cbxRtnOne.TabIndex = 27;
			this.cbxRtnOne.Text = "Rtn One Reader Routine";
			// 
			// FormTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 757);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox5,
																		  this.groupBox4,
																		  this.btnCreate,
																		  this.groupBox3,
																		  this.groupBox2,
																		  this.groupBox1});
			this.Name = "FormTest";
			this.Text = "TEST";
			this.Load += new System.EventHandler(this.FormTest_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormTest());
		}

		private void FormTest_Load(object sender, System.EventArgs e)
		{
			txtConnect.Text = "server=pscnt5;User ID=sa;password=dbadmin;database=Inspection_Master";
            txtConnect.Text = "server=psc2150\\sqlexpress,14330;User ID=web_usr;password=w3bu5r!;database=PSC_IRS;Application Name=SchemaBuild";


		}

		private void btnUse_Click(object sender, System.EventArgs e)
		{

			//clear out current columns
			clbColumns.Items.Clear();
			cbxKey.Items.Clear();
			cbxTimeStamp.Items.Clear();

			//get the selected table name
			string TableName = lbxTables.Text;

			//get this tables columns
			SqlDataReader sdr = oSchema.RtnColumns(TableName);
			clbColumns.Items.Add("ALL");

			while (sdr.Read())
			{
				clbColumns.Items.Add(sdr["Column_NAME"].ToString());
				cbxKey.Items.Add(sdr["Column_NAME"].ToString());
				cbxTimeStamp.Items.Add(sdr["Column_NAME"].ToString());
			}
			sdr.Close();

			clbColumns.Enabled = true;
			cbxKey.Enabled = true;
			cbxTimeStamp.Enabled = true;
			txtStrip.Enabled = true;
			label1.Enabled = true;
			label2.Enabled = true;
			label3.Enabled = true;
			label7.Enabled = true;
			txtStripTable.Enabled = true;
		}

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			try
			{
				oSchema.ConnectionString = txtConnect.Text;
				SqlDataReader sdr = oSchema.RtnTables();
				while (sdr.Read())
				{
					lbxTables.Items.Add(sdr["TABLE_NAME"].ToString());
				}
				sdr.Close();

				lbxTables.Enabled = true;
				btnUse.Enabled = true;
			}
			catch(Exception Err)
			{
				MessageBox.Show("Check Connection String.  " + Err.Message,"Error Connecting", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void btnOpenFile_Click(object sender, System.EventArgs e)
		{
			//alternate means
			string sFileName = txtFileName.Text;
			bool bcontinue = true;
			//open a file or create a new one for writing
			try
			{
				fsWriteFile = new FileStream( sFileName,FileMode.OpenOrCreate,FileAccess.Write);
			}
			catch(Exception err)
			{
				bcontinue = false;
				MessageBox.Show(err.Message);
			}
			
			if (bcontinue)
			{
				// open stream writer or reader
				swOutput = new StreamWriter(fsWriteFile);
				// find the end of the file
				swOutput.BaseStream.Seek(0, SeekOrigin.End);

				//start writing stuff
				swOutput.WriteLine();
				swOutput.Write(" File Write Operation Starts : ");
				swOutput.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString());
				swOutput.WriteLine();
				swOutput.Flush();
			}
		}

		private void btnCreate_Click(object sender, System.EventArgs e)
		{
			

			//Determine if should strip some common chars from each field...ie "RD_fieldname" .... "RD_" might be nice to remove
			int NumToStrip = 0;
			if (txtStrip.Text != string.Empty)
			{
				NumToStrip = int.Parse( txtStrip.Text);
			}

			string key = cbxKey.Text;

			string keyDataType = string.Empty;
			string keyDataLength = string.Empty;
			RtnKeyFieldInfo(key, ref keyDataType,ref keyDataLength);

			if (swOutput != null)
			{
				if (chkBoxSP_SelectOne.Checked) CreateSelectOne_SP(NumToStrip,key,keyDataType,keyDataLength);
				if (cbxSP_Select.Checked) CreateSelectALL_SP();
				if (cbxSP_Insert.Checked)CreateINSERT_SP(NumToStrip,key);
				if (cbxSP_Update.Checked)CreateUPDATE_SP(NumToStrip,key);

				if (cbxInsert.Checked)CreateINSERT_Routine(NumToStrip,key,keyDataType,keyDataLength);
				if (cbxUpdate.Checked)CreateUPDATE_Routine(NumToStrip,key,keyDataType,keyDataLength);
				if (cbxRtnOne.Checked)CreateSelectOne_Routine(NumToStrip,key,keyDataType,keyDataLength);
				if (cbxRtnReader.Checked)CreateSelectALL_Routine(NumToStrip);
				if(cbxRtnDS.Checked) CreateSelectAllDataSet_Routine(NumToStrip);

			}
			else
			{
				MessageBox.Show("Open the file");
			}
		}
	
		private void RtnKeyFieldInfo(string key, ref string DataType, ref string DataLength)
		{
			SqlDataReader sdr = oSchema.RtnColumns(lbxTables.Text);

			StringBuilder SP_SelectFields = new StringBuilder();

			while (sdr.Read())
			{
				string ColName = sdr["Column_NAME"].ToString();
				if (key == ColName)
				{
					DataType = sdr["TYPE_NAME"].ToString();
					DataLength = sdr["LENGTH"].ToString();
				}
			}
			sdr.Close();
			
		}
		private void CreateSelectOne_SP(int NumToStrip,string KeyField,string KeyDataType,string KeyDataLength)
		{

			StringBuilder ParamName = new StringBuilder("@i_");
			ParamName.Append(RtnParamName(KeyField,NumToStrip));

			//strip any prelim chars  like TUFR_ off table name if needed to make more readable
			string shortname = lbxTables.Text;
			if(txtStripTable.Text != string.Empty)
			{
				try
				{
					int numstrip = int.Parse(txtStripTable.Text);
					shortname = lbxTables.Text.Substring(numstrip);
				}
				catch{}
			}


			swOutput.WriteLine();
			swOutput.WriteLine("--WCode");
			swOutput.Write("--");
			swOutput.WriteLine(DateTime.Today.ToShortDateString());
			swOutput.Write("CREATE PROCEDURE usp_SELECTone_");
			swOutput.WriteLine(shortname);
			swOutput.Write("( ");
			swOutput.Write(ParamName.ToString());
			swOutput.Write(" ");
			swOutput.Write(KeyDataType);
			swOutput.WriteLine(")");
			swOutput.WriteLine("AS ");
			swOutput.Write(" SELECT ");
			swOutput.WriteLine(CreateSelectFieldsList());
			swOutput.Write(" FROM ");
			swOutput.WriteLine(lbxTables.Text);
			swOutput.Write(" WHERE ");
			swOutput.Write(KeyField);
			swOutput.Write(" = ");
			swOutput.Write(ParamName.ToString());
			swOutput.WriteLine();

			swOutput.Flush();
		}
		private void CreateSelectALL_SP()
		{
			swOutput.WriteLine();
			swOutput.WriteLine("--WCode");
			swOutput.Write("--");
			swOutput.WriteLine(DateTime.Today.ToShortDateString());
			swOutput.Write("CREATE PROCEDURE usp_SELECT_");
			swOutput.WriteLine(lbxTables.Text.Substring(int.Parse(txtStripTable.Text)));
			swOutput.WriteLine("AS ");
			swOutput.Write(" SELECT ");
			swOutput.WriteLine(CreateSelectFieldsList());
			swOutput.Write(" FROM ");
			swOutput.WriteLine(lbxTables.Text);
			swOutput.WriteLine();

			swOutput.Flush();
		}
		private void CreateINSERT_SP(int NumToStrip,string KeyField)
		{
			//re get a list of columns
			SqlDataReader sdr = oSchema.RtnColumns(lbxTables.Text);
			StringBuilder SP_Params = new StringBuilder();
			StringBuilder SP_InsertFields = new StringBuilder();
			StringBuilder SP_InsertValues = new StringBuilder();
			StringBuilder SP_RtnIdentity = new StringBuilder("SELECT ");

			bool nonIncrID = false;

			while (sdr.Read())
			{
				string ColName = sdr["Column_NAME"].ToString();
				string DataType = sdr["TYPE_NAME"].ToString();
				string DataLength = sdr["LENGTH"].ToString();
				
				if (ColName == KeyField)
				{
					string ParamName = ColName.Substring(int.Parse(txtStrip.Text));
					string OutPutParamName = "@o_" + RtnParamName(ColName,NumToStrip);

					SP_Params.Append(OutPutParamName);
					SP_Params.Append(" ");
					//strip word Identity from the datatype if needed
					string cleanDataType = CleanOutIdentityExcess(DataType);


					SP_Params.Append(cleanDataType);
					SP_Params.Append(" output,");

					
					if(DataType != "uniqueidentifier") //doesnt work with guids
					{
						SP_RtnIdentity.Append(OutPutParamName);
						SP_RtnIdentity.Append(" = @@IDENTITY ");
					}
					else //going to have to reselect all items based upon this criteria
					{
						nonIncrID = true;
						SP_RtnIdentity.Append(OutPutParamName);
						SP_RtnIdentity.Append(" = ");
						SP_RtnIdentity.Append(ColName);
						SP_RtnIdentity.Append(" FROM ");
						SP_RtnIdentity.Append(lbxTables.Text);
						SP_RtnIdentity.Append(" WHERE ");
						//have to rebuild the columns and find an order by

					}
				}
				else
				{
					string paramname = RtnSPInputParamName(ColName,NumToStrip);

					//dont want last time stamp in param list
					if(ColName != cbxTimeStamp.Text)
					{
						SP_Params.Append(paramname);
						SP_Params.Append(" ");
						SP_Params.Append(DataType);
						if ((DataType == "varchar") || (DataType == "char"))
						{
							SP_Params.Append("(");
							SP_Params.Append(DataLength);
							SP_Params.Append(")");
						}
						SP_Params.Append(",");
					}

					SP_InsertFields.Append(ColName);
					SP_InsertFields.Append(",");

					if (ColName != cbxTimeStamp.Text)
					{
						SP_InsertValues.Append(paramname);
						SP_InsertValues.Append(",");
					}
					else
					{
						SP_InsertValues.Append("CURRENT_TIMESTAMP,");
					}
				}


			}
			sdr.Close();

			//for the non incrementing ID - ie GUID
			if(nonIncrID) //finish the where clause on returning the Identity
			{
				sdr = oSchema.RtnColumns(lbxTables.Text);
				while (sdr.Read())
				{
					string ColName = sdr["Column_NAME"].ToString();
				
					if (ColName != KeyField)
					{
						string paramname = RtnSPInputParamName(ColName,NumToStrip);
						SP_RtnIdentity.Append(ColName);
						SP_RtnIdentity.Append(" = ");
						SP_RtnIdentity.Append(paramname);
						SP_RtnIdentity.Append(" AND ");
					}
				}
				sdr.Close();
				//remove excess AND
				SP_RtnIdentity.Remove(SP_RtnIdentity.Length -5,5);
				if(cbxTimeStamp.Text != "NONE")
				{
					SP_RtnIdentity.Append(" ORDER BY ");
					SP_RtnIdentity.Append(cbxTimeStamp.Text);
					SP_RtnIdentity.Append(" DESC\n");
					SP_RtnIdentity.Append("--this wont work if in mid-transaction/n");

				}
			}

			//remove excess commas
			SP_Params.Remove(SP_Params.Length -1,1);
			SP_InsertFields.Remove(SP_InsertFields.Length -1,1);
			SP_InsertValues.Remove(SP_InsertValues.Length -1,1);


            swOutput.WriteLine("USE [databaseName]");  //add updated language  3-3-2015
            swOutput.WriteLine("GO");                  //
            swOutput.WriteLine("SET ANSI_NULLS ON");   //
            swOutput.WriteLine("GO");                  //
            swOutput.WriteLine("SET QUOTED_IDENTIFIER ON");
            swOutput.WriteLine("GO");                 //add updated language
			swOutput.WriteLine();
			swOutput.WriteLine("--WCode");
			swOutput.Write("--");
			swOutput.WriteLine(DateTime.Today.ToShortDateString());
			swOutput.Write("CREATE PROCEDURE usp_INSERT_");
			swOutput.WriteLine(lbxTables.Text.Substring(int.Parse(txtStripTable.Text)));
			swOutput.Write("(");
			swOutput.Write(SP_Params.ToString());
			swOutput.WriteLine(")");
			swOutput.WriteLine("AS ");
            swOutput.WriteLine("BEGIN");              //add updated language  3-3-2015
            swOutput.WriteLine("SET NOCOUNT ON;");    //add updated language
			swOutput.Write(" INSERT INTO ");
			swOutput.WriteLine(lbxTables.Text);
			swOutput.Write("(");
			swOutput.Write(SP_InsertFields.ToString());
			swOutput.WriteLine(")");
			swOutput.Write(" VALUES (");
			swOutput.WriteLine(SP_InsertValues.ToString());
			swOutput.WriteLine(");"); // 3-3-2015 update routine to always end with semicolons for newer SQL requirements
			swOutput.WriteLine();
			swOutput.WriteLine(SP_RtnIdentity.ToString());
            swOutput.WriteLine(";"); // 3-3-2015 update routine to end actions with semicolons for newer SQL requirements
			swOutput.WriteLine();
            swOutput.WriteLine("END");              //add updated language  3-3-2015
            swOutput.WriteLine("GO");               //add updated language  
			swOutput.Flush();
		}

		private string CleanOutIdentityExcess(string DataType)
		{
			string cleanDataType = string.Empty;
			int npos = DataType.IndexOf("identity",0);
			if(npos >0)
			{
				cleanDataType = DataType.Substring(0,npos-1);
				cleanDataType = cleanDataType.Trim();
			}
			cleanDataType = cleanDataType.Replace("(","");
			cleanDataType = cleanDataType.Replace(")","");
			cleanDataType = cleanDataType.Trim();
			return cleanDataType;
		}
		private void CreateUPDATE_SP(int NumToStrip,string KeyField)
		{
			//re get a list of columns
			SqlDataReader sdr = oSchema.RtnColumns(lbxTables.Text);
			StringBuilder SP_Params = new StringBuilder();
			StringBuilder SP_UpdateFields = new StringBuilder();


			while (sdr.Read())
			{
				string ColName = sdr["Column_NAME"].ToString();
				string DataType = sdr["TYPE_NAME"].ToString();
				string DataLength = sdr["LENGTH"].ToString();

				string paramname = RtnSPInputParamName(ColName,NumToStrip);

				//dont want last time stamp in param list
				if(ColName != cbxTimeStamp.Text)
				{

					SP_Params.Append(paramname);
					SP_Params.Append(" ");
					if(ColName != cbxKey.Text)
					{
						SP_Params.Append(DataType);
					}
					else
					{
						//strip word Identity from the datatype if needed
						string cleanDataType = CleanOutIdentityExcess(DataType);
						SP_Params.Append(cleanDataType);
					}
					if ((DataType == "varchar") || (DataType == "char"))
					{
						SP_Params.Append("(");
						SP_Params.Append(DataLength);
						SP_Params.Append(")");
					}
					SP_Params.Append(",");
				}
				if (ColName != KeyField)
				{
					SP_UpdateFields.Append(ColName);
					SP_UpdateFields.Append(" = ");
					if (ColName != cbxTimeStamp.Text)
					{
						SP_UpdateFields.Append(paramname);
						SP_UpdateFields.Append(",");
					}
					else
					{
						SP_UpdateFields.Append("CURRENT_TIMESTAMP,");
					}

				}
			}
			sdr.Close();

			//remove excess commas
			SP_Params.Remove(SP_Params.Length -1,1);
			SP_UpdateFields.Remove(SP_UpdateFields.Length -1,1);

			//strip any prelim chars  like TUFR_ off table name if needed to make more readable
			string shortname = lbxTables.Text;
			if(txtStripTable.Text != string.Empty)
			{
				try
				{
					int numstrip = int.Parse(txtStripTable.Text);
					shortname = lbxTables.Text.Substring(numstrip);
				}
				catch{}
			}


			swOutput.WriteLine();
			swOutput.WriteLine("--WCode");
			swOutput.Write("--");
			swOutput.WriteLine(DateTime.Today.ToShortDateString());
			swOutput.Write("CREATE PROCEDURE usp_UPDATE_");
			swOutput.WriteLine(shortname);
			swOutput.Write("(");
			swOutput.Write(SP_Params.ToString());
			swOutput.WriteLine(")");
			swOutput.WriteLine("AS ");
			swOutput.Write(" UPDATE ");
			swOutput.WriteLine(lbxTables.Text);
			swOutput.Write(" SET ");
			swOutput.WriteLine(SP_UpdateFields.ToString());
			swOutput.Write(" WHERE ");
			swOutput.Write( KeyField );
			swOutput.Write(" = ");
			swOutput.WriteLine(RtnSPInputParamName(KeyField,NumToStrip));
			swOutput.WriteLine();
			swOutput.Flush();
		}
		private void CreateINSERT_Routine(int NumToStrip,string KeyField,string KeyDataType,string KeyDataLength)
		{
			//re get a list of columns
			SqlDataReader sdr = oSchema.RtnColumns(lbxTables.Text);
			StringBuilder FunctionParams = new StringBuilder();
			StringBuilder CommandParams = new StringBuilder();

			while (sdr.Read())
			{
				string ColName = sdr["Column_NAME"].ToString();
				string DataType = sdr["TYPE_NAME"].ToString();
				string DataLength = sdr["LENGTH"].ToString();

				//Write out params for function declaration
				if ((ColName == KeyField)|| (ColName == cbxTimeStamp.Text))
				{
					//skip these two for params
				}
				else
				{
					string paramname = RtnFunctionParamName(ColName,NumToStrip); 
					FunctionParams.Append(RtnCSharpDataType(DataType));
					FunctionParams.Append(" ");
					FunctionParams.Append(paramname);
					FunctionParams.Append(",");
				}


				//Write out command params
				if (ColName == KeyField) 
				{
					//make this one an output param

					//LINE ONE DELARE NEW COMMAND PARAM
					string paramname = RtnFunctionParamName(ColName,NumToStrip);
					CommandParams.Append("\tSqlParameter pm");
					CommandParams.Append(paramname);
					CommandParams.Append("= new SqlParameter(\"");
					CommandParams.Append(RtnSPOutputParamName(ColName,NumToStrip));
					CommandParams.Append("\", SqlDbType.");
					CommandParams.Append( RtnSQLDBDataType(KeyDataType));
					CommandParams.Append("); \n");

					//LINE TWO SET VALUE 
					CommandParams.Append(" \tpm");
					CommandParams.Append(paramname);
					CommandParams.Append(".Value = ");
					CommandParams.Append(paramname);
					CommandParams.Append("; \n");

					//LINE THREE SET DIRECTION
					CommandParams.Append(" \tpm");
					CommandParams.Append(paramname);
					CommandParams.Append(".Direction = ParameterDirection.Output; \n");

					//LINE FOUR ADD TO COMMAND OBJECT
					CommandParams.Append(" \tInsertCmd.Parameters.Add(pm");
					CommandParams.Append(paramname);
					CommandParams.Append(");\n\n");
				}
				else
				{
					if (ColName == cbxTimeStamp.Text)
					{
						//skip this one completely
					}
					else
					{
						//LINE ONE DELARE NEW COMMAND PARAM
						string paramname = RtnFunctionParamName(ColName,NumToStrip);
						CommandParams.Append("\tSqlParameter pm");
						CommandParams.Append(paramname);
						CommandParams.Append("= new SqlParameter(\"");
						CommandParams.Append(RtnSPInputParamName(ColName,NumToStrip));
						CommandParams.Append("\", SqlDbType.");
						CommandParams.Append(RtnSQLDBDataType(DataType));
						if ((DataType == "char") || (DataType == "varchar")||(DataType == "nchar"))
						{
							CommandParams.Append(",");
							CommandParams.Append(DataLength);
						}
						CommandParams.Append("); \n");

						//LINE TWO SET VALUE 
						CommandParams.Append("\tpm");
						CommandParams.Append(paramname);
						CommandParams.Append(".Value = ");
						CommandParams.Append(paramname);
						CommandParams.Append("; \n");

						//DIRECTION - DEFAULTS TO INPUT

						//LINE THREE ADD TO COMMAND OBJECT
						CommandParams.Append("\tInsertCmd.Parameters.Add(pm");
						CommandParams.Append(paramname);
						CommandParams.Append(");\n\n");
					}
				}

			}
			sdr.Close();

			//remove excess commas
			FunctionParams.Remove(FunctionParams.Length -1,1);

			string aTab = "\t";

			//Comment
			swOutput.WriteLine();
			swOutput.WriteLine("/// <summary>");
			swOutput.Write("/// Insert Data into ");
			swOutput.WriteLine(lbxTables.Text);
			swOutput.Write("/// Created by WCode ");
			swOutput.WriteLine(DateTime.Today.ToShortDateString());
			swOutput.WriteLine("/// </summary>");

			//strip any prelim chars  like TUFR_ off table name if needed to make more readable
			string shortname = lbxTables.Text;
			if(txtStripTable.Text != string.Empty)
			{
				try
				{
					int numstrip = int.Parse(txtStripTable.Text);
					shortname = lbxTables.Text.Substring(numstrip);
				}
				catch{}
			}


			//Declare function
			swOutput.Write("public ");
			string OutputDataType = RtnCSharpDataType(KeyDataType);
			swOutput.Write(OutputDataType);
			swOutput.Write(" INSERT_");
			swOutput.WriteLine(shortname);
			swOutput.Write("(");
			swOutput.Write(FunctionParams.ToString());
			swOutput.WriteLine(")");
			swOutput.WriteLine("{");
			swOutput.WriteLine();

			swOutput.Write(aTab);
			swOutput.WriteLine("//make sure m_connstr is declared");
			swOutput.Write(aTab);
			swOutput.WriteLine("SqlConnection CmnConn = new SqlConnection(m_connstr);");

			//declare new command object
			swOutput.Write(aTab);
			swOutput.Write("SqlCommand InsertCmd = new SqlCommand(\"USP_Insert_");
			swOutput.Write(shortname);
			swOutput.WriteLine("\", CmnConn);");

			//mark command as stored proc object
			swOutput.Write(aTab);
			swOutput.WriteLine("InsertCmd.CommandType = CommandType.StoredProcedure;");
			swOutput.WriteLine();

			//declare A RETURN TYPE
			swOutput.Write(aTab);
			swOutput.WriteLine(" //CHECK THAT INITIALIZED RETURN TYPE IS CORRECT (ie GUID)");

			swOutput.Write(aTab);
			swOutput.Write(OutputDataType);
			swOutput.WriteLine(" PKID = 0;");
			swOutput.WriteLine("");

			//WRite out ALL command params
			swOutput.WriteLine(CommandParams.ToString());

			//OPEN and EXECUTE
			swOutput.Write(aTab);
			swOutput.WriteLine("//THIS METHOD WORKS GREAT FOR WEB -- CHECK MEANS OF OPEN AND CLOSE FOR OTHER OPTIMiZATIONS");
			swOutput.Write(aTab);
			swOutput.WriteLine(" try {");

			swOutput.Write(aTab);
			swOutput.Write(aTab);
			swOutput.WriteLine("CmnConn.Open();");
			swOutput.Write(aTab);
			swOutput.Write(aTab);
			swOutput.WriteLine("InsertCmd.ExecuteNonQuery();");
			swOutput.Write(aTab);
			swOutput.Write(aTab);
			swOutput.WriteLine("CmnConn.Close();}");
			swOutput.Write(aTab);
			swOutput.WriteLine("catch(Exception e){throw e;}");
			swOutput.Write(aTab);
			swOutput.WriteLine("finally {if(CmnConn.State == ConnectionState.Open)CmnConn.Close();}");
			swOutput.WriteLine();

			//return OUTPUT PARAM
			swOutput.Write(aTab);
			swOutput.WriteLine ("// AGAIN CHECK RETURN TYPE");
			swOutput.Write(aTab);
			swOutput.Write("PKID = (");
			swOutput.Write(OutputDataType);
			swOutput.Write(") pm");
			swOutput.Write(RtnFunctionParamName(KeyField,NumToStrip));
			swOutput.WriteLine(".Value;");
			swOutput.Write(aTab);
			swOutput.WriteLine("return PKID;");
			swOutput.WriteLine("}");
			swOutput.WriteLine();
			swOutput.Flush();
		}

		private void CreateUPDATE_Routine(int NumToStrip,string KeyField,string KeyDataType,string KeyDataLength)
		{
			//re get a list of columns
			SqlDataReader sdr = oSchema.RtnColumns(lbxTables.Text);
			StringBuilder FunctionParams = new StringBuilder();
			StringBuilder CommandParams = new StringBuilder();

			while (sdr.Read())
			{
				string ColName = sdr["Column_NAME"].ToString();
				string DataType = sdr["TYPE_NAME"].ToString();
				string DataLength = sdr["LENGTH"].ToString();

				//Write out params for function declaration
				if (ColName == cbxTimeStamp.Text)
				{
					//skip this one for params
				}
				else
				{

					string paramname = RtnFunctionParamName(ColName,NumToStrip); 
					FunctionParams.Append(RtnCSharpDataType(DataType));
					FunctionParams.Append(" ");
					FunctionParams.Append(paramname);
					FunctionParams.Append(",");
				}


				//Write out command params

				if (ColName == cbxTimeStamp.Text)
				{
					//skip this one completely
				}
				else
				{
					//LINE ONE DELARE NEW COMMAND PARAM
					string paramname = RtnFunctionParamName(ColName,NumToStrip);
					CommandParams.Append("\tSqlParameter pm");
					CommandParams.Append(paramname);
					CommandParams.Append("= new SqlParameter(\"");
					CommandParams.Append(RtnSPInputParamName(ColName,NumToStrip));
					CommandParams.Append("\", SqlDbType.");
					CommandParams.Append(RtnSQLDBDataType(DataType));
					if ((DataType == "char") || (DataType == "varchar")||(DataType == "nchar"))
					{
						CommandParams.Append(",");
						CommandParams.Append(DataLength);
					}
					CommandParams.Append("); \n");

					if(DataType == "guid") //make that string a GUID then set the value
					{
						CommandParams.Append("\t Guid ");
						CommandParams.Append(paramname);
						CommandParams.Append("GUID = new Guid(");
						CommandParams.Append(paramname);
						CommandParams.Append("); \n \tpm");
						CommandParams.Append(paramname);
						CommandParams.Append(".Value = ");
						CommandParams.Append(paramname);
						CommandParams.Append("GUID; \n");

					}
					else
					{
						//LINE TWO SET VALUE 
						CommandParams.Append("\tpm");
						CommandParams.Append(paramname);
						CommandParams.Append(".Value = ");
						CommandParams.Append(paramname);
						CommandParams.Append("; \n");
					}

					//DIRECTION - DEFAULTS TO INPUT

					//LINE THREE ADD TO COMMAND OBJECT
					CommandParams.Append("\tUpdateCmd.Parameters.Add(pm");
					CommandParams.Append(paramname);
					CommandParams.Append(");\n\n");
				}
			

			}
			sdr.Close();

			//remove excess commas
			FunctionParams.Remove(FunctionParams.Length -1,1);

			string aTab = "\t";

			//Comment
			swOutput.WriteLine();
			swOutput.WriteLine("/// <summary>");
			swOutput.Write("/// Update Data in ");
			swOutput.WriteLine(lbxTables.Text);
			swOutput.Write("/// Created by WCode ");
			swOutput.WriteLine(DateTime.Today.ToShortDateString());
			swOutput.WriteLine("/// </summary>");

			//Declare function
			swOutput.Write("public void ");

			//strip any prelim chars  like TUFR_ off table name if needed to make more readable
			string shortname = lbxTables.Text;
			if(txtStripTable.Text != string.Empty)
			{
				try
				{
					int numstrip = int.Parse(txtStripTable.Text);
					shortname = lbxTables.Text.Substring(numstrip);
				}
				catch{}
			}
			swOutput.Write(" UPDATE_");

			swOutput.WriteLine(shortname);
			swOutput.Write("(");
			swOutput.Write(FunctionParams.ToString());
			swOutput.WriteLine(")");
			swOutput.WriteLine("{");
			swOutput.WriteLine();

			swOutput.Write(aTab);
			swOutput.WriteLine("//make sure m_connstr is declared");
			swOutput.Write(aTab);
			swOutput.WriteLine("SqlConnection CmnConn = new SqlConnection(m_connstr);");

			//declare new command object
			swOutput.Write(aTab);
			swOutput.Write("SqlCommand UpdateCmd = new SqlCommand(\"USP_Update_");
			swOutput.Write(shortname);
			swOutput.WriteLine("\", CmnConn);");

			//mark command as stored proc object
			swOutput.Write(aTab);
			swOutput.WriteLine("UpdateCmd.CommandType = CommandType.StoredProcedure;");
			swOutput.WriteLine();


			//WRite out ALL command params
			swOutput.WriteLine(CommandParams.ToString());

			//OPEN and EXECUTE
			swOutput.Write(aTab);
			swOutput.WriteLine("//THIS METHOD WORKS GREAT FOR WEB -- CHECK MEANS OF OPEN AND CLOSE FOR OTHER OPTIMiZATIONS");
			swOutput.Write(aTab);
			swOutput.WriteLine(" try {");

			swOutput.Write(aTab);
			swOutput.Write(aTab);
			swOutput.WriteLine("CmnConn.Open();");
			swOutput.Write(aTab);
			swOutput.Write(aTab);
			swOutput.WriteLine("UpdateCmd.ExecuteNonQuery();");
			swOutput.Write(aTab);
			swOutput.Write(aTab);
			swOutput.WriteLine("CmnConn.Close();}");
			swOutput.Write(aTab);
			swOutput.WriteLine("catch(Exception e){throw e;}");
			swOutput.Write(aTab);
			swOutput.WriteLine("finally {if(CmnConn.State == ConnectionState.Open)CmnConn.Close();}");
			swOutput.WriteLine();

			swOutput.WriteLine("}");
			swOutput.WriteLine();
			swOutput.Flush();
		}

		 private void CreateSelectALL_Routine(int NumToStrip)
		{

			string aTab = "\t";

			//Comment
			swOutput.WriteLine();
			swOutput.WriteLine("/// <summary>");
			swOutput.Write("/// Select All Records From ");
			swOutput.WriteLine(lbxTables.Text);
			swOutput.Write("/// Created by WCode ");
			swOutput.WriteLine(DateTime.Today.ToShortDateString());
			swOutput.WriteLine("/// </summary>");

			//strip any prelim chars  like TUFR_ off table name if needed to make more readable
			string shortname = lbxTables.Text;
			if(txtStripTable.Text != string.Empty)
			{
				try
				{
					int numstrip = int.Parse(txtStripTable.Text);
					shortname = lbxTables.Text.Substring(numstrip);
				}
				catch{}
			}

			//Declare function
			swOutput.Write("public SqlDataReader ");

			swOutput.Write(" SelectAll_");
			swOutput.Write(shortname);
			swOutput.Write("(");
			swOutput.WriteLine(")");
			swOutput.WriteLine("{");
			swOutput.WriteLine();

			swOutput.Write(aTab);
			swOutput.WriteLine("//make sure m_connstr is declared");
			swOutput.Write(aTab);
			swOutput.WriteLine("SqlConnection CmnConn = new SqlConnection(m_connstr);");

			//declare new command object
			swOutput.Write(aTab);
			swOutput.Write("SqlCommand SelectCmd = new SqlCommand(\"USP_Select_");
			swOutput.Write(shortname);
			swOutput.WriteLine("\", CmnConn);");

			//mark command as stored proc object
			swOutput.Write(aTab);
			swOutput.WriteLine("SelectCmd.CommandType = CommandType.StoredProcedure;");
			swOutput.WriteLine();

			//OPEN and EXECUTE
			swOutput.Write(aTab);
			swOutput.WriteLine("CmnConn.Open();");
			swOutput.Write(aTab);
			swOutput.WriteLine("return SelectCmd.ExecuteReader(CommandBehavior.CloseConnection)");

			swOutput.WriteLine("}");
			swOutput.WriteLine();
			swOutput.Flush();
		}


		/// <summary>
		/// Return a reader for the selected table of the current record
		/// </summary>
		/// <param name="NumToStrip"></param>
		/// <param name="KeyField"></param>
		/// <param name="KeyDataType"></param>
		/// <param name="KeyDataLength"></param>
		private void CreateSelectOne_Routine(int NumToStrip,string KeyField,string KeyDataType,string KeyDataLength)
		{
	
			//re get a list of columns
			SqlDataReader sdr = oSchema.RtnColumns(lbxTables.Text);

			StringBuilder FunctionParams = new StringBuilder();
			StringBuilder CommandParams = new StringBuilder();

			string aTab = "\t";


			string paramname = RtnFunctionParamName(KeyField,NumToStrip); 
			FunctionParams.Append(RtnCSharpDataType(KeyDataType));
			FunctionParams.Append(" ");
			FunctionParams.Append(paramname);
			FunctionParams.Append(",");


			//LINE ONE DELARE NEW COMMAND PARAM
			CommandParams.Append("\tSqlParameter pm");
			CommandParams.Append(paramname);
			CommandParams.Append("= new SqlParameter(\"");
			CommandParams.Append(RtnSPInputParamName(KeyField,NumToStrip));
			CommandParams.Append("\", SqlDbType.");
			CommandParams.Append(RtnSQLDBDataType(KeyDataType));
			if ((KeyDataType == "char") || (KeyDataType == "varchar")||(KeyDataType == "nchar"))
			{
				CommandParams.Append(",");
				CommandParams.Append(KeyDataLength);
			}
			CommandParams.Append("); \n");

			if(KeyDataType == "guid") //make that string a GUID then set the value
			{
				CommandParams.Append("\t Guid ");
				CommandParams.Append(paramname);
				CommandParams.Append("GUID = new Guid(");
				CommandParams.Append(paramname);
				CommandParams.Append("); \n \tpm");
				CommandParams.Append(paramname);
				CommandParams.Append(".Value = ");
				CommandParams.Append(paramname);
				CommandParams.Append("GUID; \n");

			}
			else
			{
				//LINE TWO SET VALUE 
				CommandParams.Append("\tpm");
				CommandParams.Append(paramname);
				CommandParams.Append(".Value = ");
				CommandParams.Append(paramname);
				CommandParams.Append("; \n");
			}

			//DIRECTION - DEFAULTS TO INPUT

			//LINE THREE ADD TO COMMAND OBJECT
			CommandParams.Append("\tSelectCmd.Parameters.Add(pm");
			CommandParams.Append(paramname);
			CommandParams.Append(");\n\n");

			//Comment
			swOutput.WriteLine();
			swOutput.WriteLine("/// <summary>");
			swOutput.Write("/// Select One Record From ");
			swOutput.WriteLine(lbxTables.Text);
			swOutput.Write("/// based upon the given Primary Key:  ");
			swOutput.WriteLine(cbxKey.Text);
			swOutput.Write("/// Created by WCode ");
			swOutput.WriteLine(DateTime.Today.ToShortDateString());
			swOutput.WriteLine("/// </summary>");

			//strip any prelim chars  like TUFR_ off table name if needed to make more readable
			string shortname = lbxTables.Text;
			if(txtStripTable.Text != string.Empty)
			{
				try
				{
					int numstrip = int.Parse(txtStripTable.Text);
					shortname = lbxTables.Text.Substring(numstrip);
				}
				catch{}
			}

			//Declare function
			swOutput.Write("public SqlDataReader ");

			swOutput.Write(" SelectOne_");
			swOutput.Write(shortname);
			swOutput.Write("(");
			swOutput.Write(FunctionParams.ToString());
			swOutput.WriteLine(")");
			
			//param name
			swOutput.WriteLine("{");
			swOutput.WriteLine();

			swOutput.Write(aTab);
			swOutput.WriteLine("//make sure m_connstr is declared");
			swOutput.Write(aTab);
			swOutput.WriteLine("SqlConnection CmnConn = new SqlConnection(m_connstr);");

			//declare new command object
			swOutput.Write(aTab);
			swOutput.Write("SqlCommand SelectCmd = new SqlCommand(\"USP_SelectOne_");
			swOutput.Write(shortname);
			swOutput.WriteLine("\", CmnConn);");

			//mark command as stored proc object
			swOutput.Write(aTab);
			swOutput.WriteLine("SelectCmd.CommandType = CommandType.StoredProcedure;");
			swOutput.WriteLine();

			//WRite out ALL command params
			swOutput.WriteLine(CommandParams.ToString());

			//OPEN and EXECUTE
			swOutput.Write(aTab);
			swOutput.WriteLine("CmnConn.Open();");
			swOutput.Write(aTab);
			swOutput.WriteLine("return SelectCmd.ExecuteReader(CommandBehavior.CloseConnection)");

			swOutput.WriteLine("}");
			swOutput.WriteLine();
			swOutput.Flush();
		}

		/// <summary>
		/// Return a DATASET for the selected table of all records
		/// </summary>
		/// <param name="NumToStrip"></param>
		/// <param name="KeyField"></param>
		/// <param name="KeyDataType"></param>
		/// <param name="KeyDataLength"></param>
		private void CreateSelectAllDataSet_Routine(int NumToStrip)
		{
	
			//re get a list of columns
			SqlDataReader sdr = oSchema.RtnColumns(lbxTables.Text);

			string aTab = "\t";

			//Comment
			swOutput.WriteLine();
			swOutput.WriteLine("/// <summary>");
			swOutput.Write("/// Select All Records From ");
			swOutput.WriteLine(lbxTables.Text);
			swOutput.Write("/// Created by WCode ");
			swOutput.WriteLine(DateTime.Today.ToShortDateString());
			swOutput.WriteLine("/// </summary>");

			//strip any prelim chars  like TUFR_ off table name if needed to make more readable
			string shortname = lbxTables.Text;
			if(txtStripTable.Text != string.Empty)
			{
				try
				{
					int numstrip = int.Parse(txtStripTable.Text);
					shortname = lbxTables.Text.Substring(numstrip);
				}
				catch{}
			}

			//Declare function
			swOutput.Write("public DataSet ");

			swOutput.Write(" SelectALLDS_");
			swOutput.Write(shortname);
			swOutput.Write("(");
			swOutput.WriteLine(")");
			
			//param name
			swOutput.WriteLine("{");
			swOutput.WriteLine();

			swOutput.Write(aTab);
			swOutput.WriteLine("//make sure m_connstr is declared");
			swOutput.Write(aTab);
			swOutput.WriteLine("SqlConnection CmnConn = new SqlConnection(m_connstr);");

			//declare new command object
			swOutput.Write(aTab);
			swOutput.Write("SqlCommand SelectCmd = new SqlCommand(\"USP_Select_");
			swOutput.Write(shortname);
			swOutput.WriteLine("\", CmnConn);");

			//mark command as stored proc object
			swOutput.Write(aTab);
			swOutput.WriteLine("SelectCmd.CommandType = CommandType.StoredProcedure;");
			swOutput.WriteLine();

			swOutput.Write(aTab);
			swOutput.WriteLine("DataSet dstmp = new DataSet();");
			swOutput.Write(aTab);
			swOutput.WriteLine("SqlDataAdapter sda = new SqlDataAdapter();");
			swOutput.Write(aTab);
			swOutput.WriteLine("sda.SelectCommand = SelectCmd;");

			//OPEN and EXECUTE
			swOutput.Write(aTab);
			swOutput.WriteLine("CmnConn.Open();");
			swOutput.Write(aTab);
			swOutput.WriteLine("sda.Fill(dstmp);");

			swOutput.WriteLine("return dstmp");

			swOutput.WriteLine("}");
			swOutput.WriteLine();
			swOutput.Flush();
		}


		/// <summary>
		/// just getting one record - but instead of sending a 
		/// reader - the params are by REF
		/// WIP
		/// </summary>
		/// <param name="NumToStrip"></param>
		/// <param name="KeyField"></param>
		/// <param name="KeyDataType"></param>
		/// <param name="KeyDataLength"></param>
		private void CreateSelectOne_Params(int NumToStrip,string KeyField,string KeyDataType,string KeyDataLength)
		{
	
			//re get a list of columns
			SqlDataReader sdr = oSchema.RtnColumns(lbxTables.Text);

			StringBuilder FunctionParams = new StringBuilder();
			StringBuilder CommandParams = new StringBuilder();

			string aTab = "\t";


			string paramname = RtnFunctionParamName(KeyField,NumToStrip); 
			FunctionParams.Append(RtnCSharpDataType(KeyDataType));
			FunctionParams.Append(" ");
			FunctionParams.Append(paramname);
			FunctionParams.Append(",");


			//LINE ONE DELARE NEW COMMAND PARAM
			CommandParams.Append("\tSqlParameter pm");
			CommandParams.Append(paramname);
			CommandParams.Append("= new SqlParameter(\"");
			CommandParams.Append(RtnSPInputParamName(KeyField,NumToStrip));
			CommandParams.Append("\", SqlDbType.");
			CommandParams.Append(RtnSQLDBDataType(KeyDataType));
			if ((KeyDataType == "char") || (KeyDataType == "varchar")||(KeyDataType == "nchar"))
			{
				CommandParams.Append(",");
				CommandParams.Append(KeyDataLength);
			}
			CommandParams.Append("); \n");

			if(KeyDataType == "guid") //make that string a GUID then set the value
			{
				CommandParams.Append("\t Guid ");
				CommandParams.Append(paramname);
				CommandParams.Append("GUID = new Guid(");
				CommandParams.Append(paramname);
				CommandParams.Append("); \n \tpm");
				CommandParams.Append(paramname);
				CommandParams.Append(".Value = ");
				CommandParams.Append(paramname);
				CommandParams.Append("GUID; \n");

			}
			else
			{
				//LINE TWO SET VALUE 
				CommandParams.Append("\tpm");
				CommandParams.Append(paramname);
				CommandParams.Append(".Value = ");
				CommandParams.Append(paramname);
				CommandParams.Append("; \n");
			}

			//DIRECTION - DEFAULTS TO INPUT

			//LINE THREE ADD TO COMMAND OBJECT
			CommandParams.Append("\tSelectCmd.Parameters.Add(pm");
			CommandParams.Append(paramname);
			CommandParams.Append(");\n\n");

			//Comment
			swOutput.WriteLine();
			swOutput.WriteLine("/// <summary>");
			swOutput.Write("/// Select One Record From ");
			swOutput.WriteLine(lbxTables.Text);
			swOutput.Write("/// based upon the given Primary Key:  ");
			swOutput.WriteLine(cbxKey.Text);
			swOutput.Write("/// Created by WCode ");
			swOutput.WriteLine(DateTime.Today.ToShortDateString());
			swOutput.WriteLine("/// </summary>");

			//strip any prelim chars  like TUFR_ off table name if needed to make more readable
			string shortname = lbxTables.Text;
			if(txtStripTable.Text != string.Empty)
			{
				try
				{
					int numstrip = int.Parse(txtStripTable.Text);
					shortname = lbxTables.Text.Substring(numstrip);
				}
				catch{}
			}

			//Declare function
			swOutput.Write("public SqlDataReader ");

			swOutput.Write(" SelectOne_");
			swOutput.Write(shortname);
			swOutput.Write("(");
			swOutput.Write(FunctionParams.ToString());
			swOutput.WriteLine(")");
			
			//param name
			swOutput.WriteLine("{");
			swOutput.WriteLine();

			swOutput.Write(aTab);
			swOutput.WriteLine("//make sure m_connstr is declared");
			swOutput.Write(aTab);
			swOutput.WriteLine("SqlConnection CmnConn = new SqlConnection(m_connstr);");

			//declare new command object
			swOutput.Write(aTab);
			swOutput.Write("SqlCommand SelectCmd = new SqlCommand(\"USP_SelectOne_");
			swOutput.Write(shortname);
			swOutput.WriteLine("\", CmnConn);");

			//mark command as stored proc object
			swOutput.Write(aTab);
			swOutput.WriteLine("SelectCmd.CommandType = CommandType.StoredProcedure;");
			swOutput.WriteLine();

			//WRite out ALL command params
			swOutput.WriteLine(CommandParams.ToString());

			//OPEN and EXECUTE
			swOutput.Write(aTab);
			swOutput.WriteLine("CmnConn.Open();");
			swOutput.Write(aTab);
			swOutput.WriteLine("return SelectCmd.ExecuteReader(CommandBehavior.CloseConnection)");

			swOutput.WriteLine("}");
			swOutput.WriteLine();
			swOutput.Flush();
		}
		private string RtnCSharpDataType(string SQLDataType)
		{
			string tmp = string.Empty;
			if (SQLDataType.IndexOf(" identity") >0)
			{
				int PosSpace = SQLDataType.IndexOf(" identity");
				SQLDataType = SQLDataType.Substring(0,PosSpace);
			}
			if (SQLDataType.IndexOf("(") >0)
			{
				int PosSpace = SQLDataType.IndexOf("(");
				SQLDataType = SQLDataType.Substring(0,PosSpace);
			}

			switch(SQLDataType)
			{
				case "varchar":
				case "nchar":
				case "char":
					tmp = "string";
					break;

				case "money":
				case "decimal":
					tmp = "decimal";
					break;

				case "float":
				case "real":
					tmp = "double";
					break;

				case "int":
				case "numeric":
					tmp = "int";
					break;

				case "datetime":
					tmp = "DateTime";
					break;

				case "uniqueidentifier":
					//tmp = "Guid";  //try replacing at param level
					tmp = "string";
					break;

				case "bit":
					tmp = "bool";
					break;
					
				

			}
			return tmp;



		}

		private string RtnSQLDBDataType(string SQLDataType)
		{
			string tmp = string.Empty;

			if (SQLDataType.IndexOf(" identity") >0)
			{
				int PosSpace = SQLDataType.IndexOf(" identity");
				SQLDataType = SQLDataType.Substring(0,PosSpace);
			}
			if (SQLDataType.IndexOf("(") >0)
			{
				int PosSpace = SQLDataType.IndexOf("(");
				SQLDataType = SQLDataType.Substring(0,PosSpace);
			}
			 switch(SQLDataType)
			{
				case "varchar":
					tmp = "VarChar";
					break;
				case "nchar":
					tmp = "NChar";
					break;
				case "char":
					tmp = "Char";
					break;

				case "money":
					tmp = "Money";
					break;
				case "decimal":
					tmp = "Decimal";
					break;

				case "float":
					tmp = "Float";
					break;
				case "real":
					tmp = "Real";
					break;

				case "int":
					tmp = "Int";
					break;

				case "datetime":
					tmp = "DateTime";
					break;

				case "uniqueidentifier":
					tmp = "UniqueIdentifier";
					break;

				case "bit":
					tmp = "Bit";
					break;

				 case "image":
					 tmp = "Image";
					 break;

				 case "numeric":
					 tmp = "Int";
					 break;

			}
			return tmp;
		}
		private string RtnParamName(string Field, int NumToStrip)
		{
			string Param = Field;
			if (NumToStrip != 0)
			{
				Param = Field.Substring(NumToStrip);
			}
			return Param;
		}
		private string RtnSPInputParamName(string Field, int NumToStrip)
		{
			string Param = Field;
			if (NumToStrip != 0)
			{
				Param = "@i_" + Field.Substring(NumToStrip);
			}
			else
			{
				Param = "@i_" + Field;
			}
			return Param;
		}
		private string RtnSPOutputParamName(string Field, int NumToStrip)
		{
			string Param = Field;
			if (NumToStrip != 0)
			{
				Param = "@o_" + Field.Substring(NumToStrip);
			}
			else
			{
				Param = "@o_" + Field;
			}
			return Param;
		}
		private string RtnFunctionParamName(string Field, int NumToStrip)
		{
			string Param = Field;
			if (NumToStrip != 0)
			{
				Param =  Field.Substring(NumToStrip);
			}
			else
			{
				Param =  Field;
			}
			return Param;
		}
		private string CreateSelectFieldsList()
		{
			//re get a list of columns
			SqlDataReader sdr = oSchema.RtnColumns(lbxTables.Text);

			StringBuilder SP_SelectFields = new StringBuilder();

			while (sdr.Read())
			{
				string ColName = sdr["Column_NAME"].ToString();
				string ParamName = ColName;
//				string ColDataType = sdr["TYPE_NAME"].ToString();
//				string ColDataSize = sdr["LENGTH"].ToString();

				//Build comma delimted string of fields to select
				SP_SelectFields.Append(ColName);
				SP_SelectFields.Append(",");

			}
			sdr.Close();

			//remove excess commas
			SP_SelectFields.Remove(SP_SelectFields.Length -1,1);
			
			return SP_SelectFields.ToString();
		}









	}
}
