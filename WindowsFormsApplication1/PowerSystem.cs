using System;
using System.IO;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using NPOI.SS.Util;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        DataTable data = new DataTable();
        string filePath = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
             filePath = openFileDialog1.FileName;
            string extension = Path.GetExtension(filePath);
            dataGridView1.DataSource = ExcelInput(filePath, extension);

        }
       





        private void exportData_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            saveFileDialog1.Filter = "xlsx|*.xlsx|xls files(*.xls)|*.xls|All files(*.*)|*.*";
            saveFileDialog1.DefaultExt = "xlsx";
            String fileSavePath = saveFileDialog1.FileName;
            DataTableToExcel(data,fileSavePath);
        }

        private void printBtn_click(object sender, EventArgs e)
        {

        }



        private void manageBtn_Click(object sender, EventArgs e)
        {

        }

        private void manage_click(object sender, EventArgs e)
        {

        }
        //从excel读入数据到DataTable
        public DataTable ExcelInput(string FilePath, string extension)
        {
            DataTable dataNew = new DataTable();
            try
            {               
                FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite); ;
                IWorkbook workbook = null;
                ISheet sheet = null;
                //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档
                if (extension.Equals(".xlsx")) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (extension.Equals(".xls")) // 2003版本
                    workbook = new HSSFWorkbook(fs);
                try
                {
                    if (workbook != null)
                    {
                        sheet = workbook.GetSheetAt(0);
                        sheet.ForceFormulaRecalculation = true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);

                }

                if (sheet != null)
                {
                    //获取Excel的最大行数和列数
                    int rowsCount = sheet.PhysicalNumberOfRows;
                    int colsCount = sheet.GetRow(0).PhysicalNumberOfCells;
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
                    dataNew.TableName = firstRow.GetCell(0).ToString();
                    // sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, cellCount));
                    //CellRangeAddress（）该方法的参数次序是：开始行号，结束行号，开始列号，结束列号。
                    List<String> addr = getMergedRegionValue(sheet, 3, 0);
                    //add colums
                    for (int i = firstRow.FirstCellNum; i < cellCount; i++)
                    {
                        ICell iCell = firstRow.GetCell(i);
                        if (iCell != null)
                        {
                            DataColumn column = new DataColumn("" + iCell.ToString());
                            //
                            dataNew.Columns.Add(column);
                        }

                    }
                    //read data
                    for (int i = sheet.FirstRowNum; i <= rowsCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = dataNew.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            ICell cell = row.GetCell(j);
                            if (cell != null) //同理，没有数据的单元格都默认是null
                            {
                                if (cell.CellType == CellType.Formula) { dataRow[j] = cell.NumericCellValue.ToString("#0.000"); }//将公式计算结果显示出来
                                else {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }
                            }

                        }
                        dataNew.Rows.Add(dataRow);
                    }
                }
                sheet = null;
                workbook = null;
                data = dataNew;
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                System.Windows.Forms.MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
           
           
        }
        ///从DataTable读入数据到execel，NPOI 是开源的 POI 项目的.NET版，可以用来读写Excel，Word，PPT文件。在处理Excel文件上，NPOI 可以同时兼容 xls 和 xlsx。
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public void DataTableToExcel(DataTable data, string fileName)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;
            IWorkbook workbook = null;
            if (fileName != "")//中途取消
            {
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook();
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook();

                try
                {
                    if (workbook != null)
                    {
                        sheet = workbook.CreateSheet("new");
                        
                    }

                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }


                    for (i = 0; i < data.Rows.Count; ++i)
                    {
                        IRow row1 = sheet.CreateRow(count);
                        for (j = 0; j < data.Columns.Count; ++j)
                        {
                            row1.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                        }
                        ++count;
                    }
                    workbook.Write(fs); //写入到excel               
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    System.Windows.Forms.MessageBox.Show("Exception: " + ex.Message);
                }
            }
        }
        /**
      * 获取合并单元格的值
      * @param sheet 
      * @param row 查找合并单元的起始行
      * @param column 查找合并单元的起始列
      * @return
      */
        public List<String> getMergedRegionValue(ISheet sheet, int row, int column)
        {
            int sheetMergeCount = sheet.NumMergedRegions;
            List<String> address = new List<string>();

            for (int i = 0; i < sheetMergeCount; i++)
            {

               CellRangeAddress ca = sheet.GetMergedRegion(i);
                int firstColumn = ca.FirstColumn;
                int lastColumn = ca.LastColumn;
                int firstRow = ca.FirstRow;
                int lastRow = ca.LastRow;

                if (row >= firstRow && row <= lastRow)
                {

                    if (column >= firstColumn && column <= lastColumn)
                    {
                        IRow fRow = sheet.GetRow(firstRow);
                        ICell fCell = fRow.GetCell(firstColumn);
                        address.Add(fCell.StringCellValue);
                        
                    }
                }
            }

            return address;
        }


        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            dataGridView1.CurrentRow.Selected = true;
          
        }
    }

    }
