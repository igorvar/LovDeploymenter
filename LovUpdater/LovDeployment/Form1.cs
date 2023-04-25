using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LovDeployment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFromClipboard_Click(object sender, EventArgs e)
        {


            //MessageBox.Show(Clipboard.GetText());
            string[] rowDelimeter = { "\r\n" };
            string[] rows = Clipboard.GetText().Split(rowDelimeter, StringSplitOptions.RemoveEmptyEntries);
            int gridRowNumber = 0;

            string[][] cells = new string[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
                cells[i] = rows[i].Split('\t');

            int[] showedColumns = new int[dgMainGrid.ColumnCount];

            foreach (DataGridViewColumn item in dgMainGrid.Columns)
                showedColumns[item.DisplayIndex] = item.Index;

            for (int i = 0; i < cells.Length; i++)
            {
                gridRowNumber = dgMainGrid.Rows.Add();
                SetDefaultsForString(dgMainGrid.Rows[gridRowNumber]);


                for (int j = 0; j < cells[i].Length && j < dgMainGrid.ColumnCount; j++)
                {
                    int cellIndex = showedColumns[j];
                    switch (dgMainGrid.Columns[cellIndex].Name)
                    {
                        case "clmnActive":
                        case "clmnTranslate":
                        case "clmnMultilingual":
                            dgMainGrid.Rows[gridRowNumber].Cells[cellIndex].Value = cells[i][j] == "N" || cells[i][j] == "n" || cells[i][j].ToUpper() == "FALSE" ? "N" : "Y";
                            break;
                        case "clmnLanguageCode":
                            if (String.IsNullOrEmpty(cells[i][j]))
                                dgMainGrid.Rows[gridRowNumber].Cells[cellIndex].Value = "HEB";
                            else
                                dgMainGrid.Rows[gridRowNumber].Cells[cellIndex].Value = cells[i][j];
                            break;

                        default:
                            dgMainGrid.Rows[gridRowNumber].Cells[cellIndex].Value = cells[i][j];
                            break;

                    }
                    IsSingleRowValid(gridRowNumber);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgMainGrid.Rows.Count; i++)
                if (!IsSingleRowValid(i))
                {
                    MessageBox.Show("Please fix all errors before", "Saving...", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            saveFileDialog1.FileName = Environment.UserName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm_LOV");
            if (DialogResult.OK != saveFileDialog1.ShowDialog()) return;
            DataTable tblParents = CreateTableOfTypes();
            DataTable tblRecords = CreateTableOfRecords();
            XmlDocument doc = mainXmlCreateXml(tblParents, tblRecords);
            doc.PreserveWhitespace = true;
            doc.Save(saveFileDialog1.FileName);

        }

        private DataTable CreateTableOfRecords()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Order_spcBy");
            tbl.Columns.Add("Value");
            tbl.Columns.Add("Translate");
            tbl.Columns.Add("Parent_spcLanguage");
            tbl.Columns.Add("Language");
            tbl.Columns.Add("High");
            tbl.Columns.Add("Default_spcLIC_spcFlag");
            tbl.Columns.Add("Multilingual");
            tbl.Columns.Add("Modifiable");
            //tbl.Columns.Add("Parent_spcValue");
            tbl.Columns.Add("Parent");
            tbl.Columns.Add("Parent_spcType");
            tbl.Columns.Add("Target_spcLow");
            tbl.Columns.Add("Class_spcCode");
            tbl.Columns.Add("Type");
            tbl.Columns.Add("Low");
            tbl.Columns.Add("Parent_spcSub_spcType");
            tbl.Columns.Add("Target_spcHigh");
            tbl.Columns.Add("Parent_spcOrganization");
            tbl.Columns.Add("Sub_spcType");
            tbl.Columns.Add("Weighting_spcFactor");
            tbl.Columns.Add("Active");
            tbl.Columns.Add("Replication_spcLevel");
            tbl.Columns.Add("Organization");
            tbl.Columns.Add("Name");
            tbl.Columns.Add("Description");

            for (int i = 0; i < dgMainGrid.Rows.Count; i++)
            {
                if (dgMainGrid.Rows[i].IsNewRow) continue;
                if (dgMainGrid.Rows[i].Cells["clmnLic"].Value.ToString() == "LOV_TYPE") continue;
                DataRow newRow;
                newRow = tbl.NewRow();
                newRow["Order_spcBy"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnOrder"]);// (dgMainGrid.Rows[i].Cells["clmnOrder"].Value ?? "").ToString();
                newRow["Value"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnValue"]);//dgMainGrid.Rows[i].Cells["clmnValue"].Value ?? string.Empty;
                newRow["Translate"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnTranslate"]);// dgMainGrid.Rows[i].Cells["clmnTranslate"].Value ?? string.Empty;
                //newRow["Parent_spcLanguage"] = (dgMainGrid.Rows[i].Cells["clmnLanguageCode"].Value ?? "").ToString();
                newRow["Language"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnLanguageCode"]);// dgMainGrid.Rows[i].Cells["clmnLanguageCode"].Value ?? string.Empty;
                newRow["High"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnHigh"]);//dgMainGrid.Rows[i].Cells["clmnHigh"].Value ?? string.Empty;
                newRow["Default_spcLIC_spcFlag"] = "N";
                newRow["Multilingual"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnMultilingual"]);//dgMainGrid.Rows[i].Cells["clmnMultilingual"].Value ?? string.Empty;
                newRow["Modifiable"] = "N";
                //newRow["Parent_spcValue"]
                newRow["Parent"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnParent"]);// dgMainGrid.Rows[i].Cells["clmnParent"].Value ?? string.Empty;
                newRow["Parent_spcType"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnParentType"]);// dgMainGrid.Rows[i].Cells["clmnParentType"].Value ?? string.Empty;
                newRow["Target_spcLow"] = "";
                newRow["Class_spcCode"] = "";
                newRow["Type"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnType"]);// dgMainGrid.Rows[i].Cells["clmnType"].Value ?? string.Empty;
                newRow["Low"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnLow"]);// dgMainGrid.Rows[i].Cells["clmnLow"].Value ?? string.Empty;
                newRow["Parent_spcSub_spcType"] = "";
                newRow["Target_spcHigh"] = "";
                newRow["Parent_spcOrganization"] = "";
                newRow["Sub_spcType"] = newRow["Parent"];
                newRow["Weighting_spcFactor"] = "";
                newRow["Active"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnActive"]);// dgMainGrid.Rows[i].Cells["clmnActive"].Value ?? string.Empty;
                newRow["Replication_spcLevel"] = "All";
                //newRow["Organization"]
                newRow["Name"] = CellValueToString(dgMainGrid.Rows[i].Cells["clmnLic"]);// dgMainGrid.Rows[i].Cells["clmnLic"].Value ?? string.Empty;
                newRow["Description"] = dgMainGrid.Rows[i].Cells["clmnComment"].Value;//?? Environment.UserName.ToUpperInvariant() + ". " + DateTime.Today.ToString("dd.MM.yy");

                if (!string.IsNullOrWhiteSpace(newRow["Parent"].ToString()))
                    newRow["Parent_spcLanguage"] = newRow["Language"];

                tbl.Rows.Add(newRow);
            }
            return tbl;

        }
        private DataTable CreateTableOfTypes()
        {
            string lovType = "";
            DataRow[] dr = null;
            string nameVal = "";

            DataTable tblParents = new DataTable();
            tblParents.Columns.Add("Type");
            tblParents.Columns.Add("Name");
            tblParents.Columns.Add("Active");
            tblParents.Columns.Add("Replication_spcLevel");
            tblParents.Columns.Add("Order_spcBy");
            tblParents.Columns.Add("Value");
            tblParents.Columns.Add("Translate");
            tblParents.Columns.Add("High");
            tblParents.Columns.Add("Multilingual");
            tblParents.Columns.Add("Modifiable");
            tblParents.Columns.Add("Class_spcCode");
            tblParents.Columns.Add("Low");

            for (int i = 0; i < dgMainGrid.RowCount; i++)
            {
                if (dgMainGrid.Rows[i].IsNewRow) continue;
                lovType = dgMainGrid.Rows[i].Cells["clmnType"].Value.ToString();
                if (lovType == "LOV_TYPE") nameVal = dgMainGrid.Rows[i].Cells["clmnLic"].Value.ToString();
                else nameVal = lovType;
                dr = tblParents.Select("Name = '" + nameVal + "' and Type = 'LOV_TYPE'");
                if (dr.Length == 0)
                {
                    DataRow newRow;
                    newRow = tblParents.NewRow();
                    newRow["Type"] = "LOV_TYPE";
                    newRow["Name"] = nameVal;
                    newRow["Value"] = nameVal;
                    //newRow["Translate"] = "Y";
                    if ("Y" == (string)dgMainGrid.Rows[i].Cells["clmnTranslate"].Value) newRow["Translate"] = "Y";
                    newRow["Active"] = "Y";
                    newRow["Replication_spcLevel"] = "All";
                    newRow["Modifiable"] = "N";
                    //newRow["Multilingual"] = "Y";
                    if ("Y" == (string)dgMainGrid.Rows[i].Cells["clmnMultilingual"].Value) newRow["Multilingual"] = "Y"; else newRow["Multilingual"] = "N";
                    tblParents.Rows.Add(newRow);
                }
                else
                {
                    if ("Y" == (string)dgMainGrid.Rows[i].Cells["clmnTranslate"].Value) dr[0]["Translate"] = "Y";
                    if ("Y" == (string)dgMainGrid.Rows[i].Cells["clmnMultilingual"].Value) dr[0]["Multilingual"] = "Y";
                }


                if (lovType == "LOV_TYPE")
                {
                    dr = tblParents.Select("Name = '" + nameVal + "' and Type = 'LOV_TYPE'");

                    dr[0]["Order_spcBy"] = dgMainGrid.Rows[i].Cells["clmnOrder"].Value;
                    if (!string.IsNullOrWhiteSpace(dgMainGrid.Rows[i].Cells["clmnValue"].Value.ToString()))
                        dr[0]["Value"] = dgMainGrid.Rows[i].Cells["clmnValue"].Value;
                    dr[0]["Translate"] = dgMainGrid.Rows[i].Cells["clmnTranslate"].Value;
                    dr[0]["High"] = dgMainGrid.Rows[i].Cells["clmnHigh"].Value;
                    dr[0]["Multilingual"] = dgMainGrid.Rows[i].Cells["clmnMultilingual"].Value;

                    dr[0]["Class_spcCode"] = "";
                    dr[0]["Low"] = dgMainGrid.Rows[i].Cells["clmnLow"].Value;
                }
            }
            return tblParents;
        }

        private XmlDocument mainXmlCreateXml(DataTable TableOfParents, DataTable TblRecords)
        {
            XmlDocument doc = new XmlDocument();
            //doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
            doc.AppendChild(doc.CreateProcessingInstruction("Siebel-Property-Set", "EscapeNames='true'"));
            XmlNode siebelMessage = doc.CreateElement("SiebelMessage");
            XmlNode __PROPERTIES__ = AddChild(siebelMessage, "_sblesc_und_undPROPERTIES_und_und", "");

            /*<TargetServerPath></TargetServerPath>
            <SourceServiceMethod></SourceServiceMethod>
            <SchemaVersion>50.13.13.436</SchemaVersion>
            <SRFVersion>43|1567295623|0</SRFVersion>
            <SessionId>1-49CGAD</SessionId>
            <AcknowledgementWorkflow>UDA Acknowledgement</AcknowledgementWorkflow>
            <PostProcessWorkflow>Testing</PostProcessWorkflow>
            <Asynchronous>Y</Asynchronous>
            <TransactionLogFileName>1-49CGAD</TransactionLogFileName>
            <TransactionName>LOV</TransactionName>
            <AsyncExportFile>N</AsyncExportFile>
            <UserName></UserName>
            <Password></Password>
            <TargetServiceName></TargetServiceName>
            <AsyncDataPrep>Y</AsyncDataPrep>
            <TargetWorkflow>UDA Target Workflow</TargetWorkflow>
            <EAIQueueType>On Error</EAIQueueType>
            <TargetServiceMethod></TargetServiceMethod>
            <SourceServiceName></SourceServiceName>
            <TargetSubsystem>UDADeploy</TargetSubsystem>
            <Description></Description>
            <SessionProjectName>MNR LOV</SessionProjectName>
            <ExportFilePath>c:\temp\</ExportFilePath>
            <TransactionLogFilePath>D:\Siebel\15.0.0.0.0\ses\siebsrvr\temp\1-49CGAD.log</TransactionLogFilePath>
            <TransactionId>1-49CGAE</TransactionId>*/
            AddChild(__PROPERTIES__, "SchemaVersion", "50.13.13.436");
            AddChild(__PROPERTIES__, "Asynchronous", "Y");
            AddChild(__PROPERTIES__, "TransactionName", "LOV");
            AddChild(__PROPERTIES__, "AsyncExportFile", "Y");
            AddChild(__PROPERTIES__, "AsyncDataPrep", "Y");
            AddChild(__PROPERTIES__, "EAIQueueType", "On Error");
            AddChild(__PROPERTIES__, "TargetSubsystem", "UDADeploy");
            AddChild(__PROPERTIES__, "ExportFilePath", @"c:\temp\");

            AddChild(__PROPERTIES__, "AcknowledgementWorkflow", "UDA Acknowledgement");
            AddChild(__PROPERTIES__, "TargetWorkflow", "UDA Target Workflow");


            XmlNode EAIMessage = AddChild(siebelMessage, "EAIMessage", "");


            __PROPERTIES__ = AddChild(EAIMessage, "_sblesc_und_undPROPERTIES_und_und", "");
            AddChild(__PROPERTIES__, "SessionItemName", "LOV");
            AddChild(__PROPERTIES__, "DataTypeName", "LOV");
            AddChild(__PROPERTIES__, "GroupName", "LOV");
            AddChild(__PROPERTIES__, "MessageType", "Integration Object");
            AddChild(__PROPERTIES__, "IntObjectName", "UDA List Of Values");
            AddChild(__PROPERTIES__, "IntObjectFormat", "Siebel Hierarchical");
            AddChild(__PROPERTIES__, "EAIMethod", "Upsert");

            XmlNode ListOfUDAListOfValues = AddChild(EAIMessage, "ListOfUDA_spcList_spcOf_spcValues", "");
            //XmlNode ListOfValuesParentUda = AddChild(ListOfUDAListOfValues, "List_spcOf_spcValues_spcParent_spc_lprUDA_rpr", "");
            //__PROPERTIES__ = AddChild(ListOfValuesParentUda, "_sblesc_und_undPROPERTIES_und_und", "");
            for (int pr = 0; pr < TableOfParents.Rows.Count; pr++)
            {
                XmlNode ListOfValuesParentUda = AddChild(ListOfUDAListOfValues, "List_spcOf_spcValues_spcParent_spc_lprUDA_rpr", "");
                __PROPERTIES__ = AddChild(ListOfValuesParentUda, "_sblesc_und_undPROPERTIES_und_und", "");
                foreach (DataColumn pc in TableOfParents.Columns)
                    AddChild(__PROPERTIES__, pc.ColumnName, TableOfParents.Rows[pr][pc].ToString());

                //<ListOfList_spcOf_spcValues_spcParent_spc_lprUDA_rpr_undOrganization></ListOfList_spcOf_spcValues_spcParent_spc_lprUDA_rpr_undOrganization>
                XmlNode ListOfListOfValuesChildUda = AddChild(ListOfValuesParentUda, "ListOfList_spcOf_spcValues_spcChild_spc_lprUDA_rpr", "");
                //XmlNode ListOfValuesChildUda = AddChild(ListOfListOfValuesChildUda, "List_spcOf_spcValues_spcChild_spc_lprUDA_rpr", "");
                DataRow[] selectedChildRows = TblRecords.Select("Type='" + TableOfParents.Rows[pr]["Name"] + "'");
                for (int cr = 0; cr < selectedChildRows.Length; cr++)
                {
                    XmlNode ListOfValuesChildUda = AddChild(ListOfListOfValuesChildUda, "List_spcOf_spcValues_spcChild_spc_lprUDA_rpr", "");
                    __PROPERTIES__ = AddChild(ListOfValuesChildUda, "_sblesc_und_undPROPERTIES_und_und", "");
                    foreach (DataColumn cc in TblRecords.Columns)
                    {
                        //AddChild(__PROPERTIES__, cc.ColumnName, TblRecords.Rows[cr][cc].ToString());
                        AddChild(__PROPERTIES__, cc.ColumnName, selectedChildRows[cr][cc].ToString());

                    }
                }
            }
            doc.AppendChild(siebelMessage);
            //throw new NotImplementedException();
            return doc;
        }

        XmlNode AddChild(XmlNode prnt, string name, string val)
        {
            XmlNode n = prnt.OwnerDocument.CreateElement(name);
            n.InnerText = val;

            prnt.AppendChild(n);
            return n;
        }

        private void dgMainGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            SetDefaultsForString(e.Row);
           
        }
        private void SetDefaultsForString(DataGridViewRow Row)
        {
            DataGridViewRow prevRow;
            DataGridViewRow prevPrevRow;
            Row.Cells["clmnLanguageCode"].Value = "HEB";
            Row.Cells["clmnActive"].Value = "Y";
            Row.Cells["clmnTranslate"].Value = "N";
            Row.Cells["clmnMultilingual"].Value = "N";
            Row.Cells["clmnMultilingual"].Value = "N";
            Row.Cells["clmnComment"].Value =
                Environment.UserName.ToUpperInvariant() + ". " + DateTime.Today.ToString("dd.MM.yy") + " by " + this.Text;

            //Copy values from prev row
            if (Row.Index == 0) return;

            prevRow = Row.DataGridView.Rows[Row.Index - 1];
            Row.Cells["clmnType"].Value = prevRow.Cells["clmnType"].Value;
            Row.Cells["clmnParent"].Value = prevRow.Cells["clmnParent"].Value;
            Row.Cells["clmnParentType"].Value = prevRow.Cells["clmnParentType"].Value;
            Row.Cells["clmnLanguageCode"].Value = prevRow.Cells["clmnLanguageCode"].Value;

            // Order calculation
            int orderPrev = 0;
            
            if (!int.TryParse(CellValueToString(prevRow.Cells["clmnOrder"]), out orderPrev))
                return;

            if (Row.Index < 2)
            {
                Row.Cells["clmnOrder"].Value = orderPrev + orderPrev;
                return;
            }

            prevPrevRow = Row.DataGridView.Rows[Row.Index - 2];
            if (CellValueToString(prevRow.Cells["clmnType"]) != CellValueToString(prevPrevRow.Cells["clmnType"]))
            {
                Row.Cells["clmnOrder"].Value = orderPrev + orderPrev;
                return;
            }
            
            int orderPrevPrev = 0;
            if (int.TryParse(CellValueToString(prevPrevRow.Cells["clmnOrder"]), out orderPrevPrev))
                Row.Cells["clmnOrder"].Value = orderPrev + orderPrev - orderPrevPrev;
            else
                Row.Cells["clmnOrder"].Value = orderPrev + orderPrev;
        }
        private void dgMainGrid_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            e.Value = e.Value.ToString().Trim();
            e.ParsingApplied = true;
            //dgMainGrid[e.ColumnIndex, e.RowIndex].Value = e.Value.ToString().Trim();
        }

        private void dgMainGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex];
            if (string.IsNullOrEmpty(cell.ErrorText)) return;
//            cell.ErrorText = ""; //return;
            IsCellValid(cell);
            //    e.Cancel = false;
        }
        private void dgMainGrid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsSingleRowValid(e.RowIndex);
        }
        private bool IsSingleRowValid(int RowIndex)
        {
            //DataGridView dg = (DataGridView)sender;
            DataGridView dg = dgMainGrid;
            if (dg.Rows[RowIndex].IsNewRow) return true; 
            return
            IsCellValid(dg.Rows[RowIndex].Cells["clmnType"]) &
            IsCellValid(dg.Rows[RowIndex].Cells["clmnValue"]) &
            IsCellValid(dg.Rows[RowIndex].Cells["clmnLic"]) &
            IsCellValid(dg.Rows[RowIndex].Cells["clmnLanguageCode"]) &
            IsCellValid(dg.Rows[RowIndex].Cells["clmnParentType"]) &
            IsCellValid(dg.Rows[RowIndex].Cells["clmnParent"]) &
            IsCellValid(dg.Rows[RowIndex].Cells["clmnOrder"]) &
            IsCellValid(dg.Rows[RowIndex].Cells["clmnHigh"]) &
            IsCellValid(dg.Rows[RowIndex].Cells["clmnLow"]) &
            IsCellValid(dg.Rows[RowIndex].Cells["clmnComment"]);
        }
        private bool IsCellValid(DataGridViewCell cell)
        {
            string cellValue = CellValueToString(cell);
            string cellValue2;
            int maxLen;
            int tmpInt;
            switch (cell.OwningColumn.Name)
            {
                
                case "clmnLic":
                    maxLen = 50;
                    cell.ErrorText = !string.IsNullOrEmpty(cellValue) && cellValue.Length <= maxLen ?
                        string.Empty :
                        string.IsNullOrEmpty(cellValue) ?
                        cell.OwningColumn.HeaderText + " is required" :
                        "Maximum length of " + cell.OwningColumn.HeaderText + " is " + maxLen + " chars. Please remove " + (cellValue.Length - maxLen) + " chars";
                    break;
                case "clmnType":
                case "clmnValue":
                    maxLen = 30;
                    cell.ErrorText = !string.IsNullOrEmpty(cellValue) && cellValue.Length <= maxLen ?
                        string.Empty:
                        string.IsNullOrEmpty(cellValue) ?
                        cell.OwningColumn.HeaderText + " is required" :
                        "Maximum length of " + cell.OwningColumn.HeaderText + " is " + maxLen + " chars. Please remove " + (cellValue.Length - maxLen) + " chars";
                    break;

                case "clmnLanguageCode":
                    maxLen = 3;
                    cell.ErrorText = cellValue.Length == maxLen ?
                        string.Empty :
                        string.IsNullOrEmpty(cellValue) ?
                        cell.OwningColumn.HeaderText + " is required" :
                        "Length of " + cell.OwningColumn.HeaderText + " is " + maxLen + " chars.";
                     break;

                case "clmnParentType":
                    maxLen = 50;
                    cellValue2 = CellValueToString(cell.DataGridView.Rows[cell.RowIndex].Cells["clmnParent"]);
                    if (cellValue == "" && cellValue2 != "")
                    {
                        cell.ErrorText = cell.OwningColumn.HeaderText + " is required if " + cell.DataGridView.Columns["clmnParentType"].HeaderText + " not empty";
                        break;
                    }
                    if (cellValue.Length > maxLen)
                    {
                        cell.ErrorText = "Maximum length of " + cell.OwningColumn.HeaderText + " is " + maxLen + " chars. Please remove " + (cellValue.Length - maxLen) + " chars";
                        break;
                    }
                    cell.ErrorText = string.Empty;
                    break;

                case "clmnParent":
                    maxLen = 50;
                    cellValue2 = CellValueToString(cell.DataGridView.Rows[cell.RowIndex].Cells["clmnParentType"]);
                    if (cellValue == "" && cellValue2 != "")
                    {
                        cell.ErrorText = cell.OwningColumn.HeaderText + " is required if " + cell.DataGridView.Columns["clmnParentType"].HeaderText + " not empty";
                        break;
                    }
                    if(cellValue.Length > maxLen)
                    {
                        cell.ErrorText = "Maximum length of " + cell.OwningColumn.HeaderText + " is " + maxLen + " chars. Please remove " + (cellValue.Length - maxLen) + " chars";
                        break;
                    }
                    cell.ErrorText = string.Empty;
                    break;

                case "clmnOrder":
                    if (string.IsNullOrEmpty(cellValue))
                        cell.ErrorText = string.Empty;
                    else
                        if (!int.TryParse(cellValue, out tmpInt) || tmpInt < 0)
                        cell.ErrorText = "Value of " + cell.OwningColumn.HeaderText + " must be positive integer ";
                    else
                        cell.ErrorText = string.Empty;
                    break;

                case "clmnHigh":
                case "clmnLow":
                    maxLen = 100;
                    cell.ErrorText = cellValue.Length < maxLen ?
                        string.Empty :
                        "Maximum length of " + cell.OwningColumn.HeaderText + " is " + maxLen + " chars. Please remove " + (cellValue.Length - maxLen) + " chars";
                    break;

                case "clmnComment":
                    maxLen = 255;
                    cell.ErrorText = cellValue.Length < maxLen ?
                        string.Empty :
                        "Maximum length of " + cell.OwningColumn.HeaderText + " is " + maxLen + " chars. Please remove " +(cellValue.Length - maxLen) + " chars";
                    break;

                default:
                    throw new Exception("ValidateCellInRow. Unknown validation for column" + cell.OwningColumn.Name);
            }
            return string.IsNullOrEmpty(cell.ErrorText);

        }
        
        private string CellValueToString(DataGridViewCell cell)
        {
            if (cell.Value == null) return string.Empty;
            return cell.Value.ToString();
        }

        private void dgMainGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgMainGrid.Columns[e.ColumnIndex].Name)
            {
                case "clmnValue":
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("he-IL"));
                    break;
                default:
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
                    break;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        /*private void SaveColumnOrder(DataGridView name)
        {
            if (name.AllowUserToOrderColumns)
            {
                List<ColumnOrderItem> columnOrder = new List<ColumnOrderItem>();
                DataGridViewColumnCollection columns = name.Columns;
                
                for (int i = 0; i< columns[i].DisplayIndex) ;
                foreach (var item in sorted)
                {
                    name.Columns[item.ColumnIndex].DisplayIndex = item.DisplayIndex;
                    name.Columns[item.ColumnIndex].Visible = item.Visible;
                    name.Columns[item.ColumnIndex].Width = item.Width;
                }
            }
        }*/
    }
}


