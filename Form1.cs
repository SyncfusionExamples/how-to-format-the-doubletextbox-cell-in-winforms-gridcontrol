using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using System.Diagnostics;
using System.Threading;
using Syncfusion.GridHelperClasses;

namespace CellGrid_2008
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gridControl1.RowCount = 1000;
            gridControl1.ColCount = 10;
            for (int i = 1; i < gridControl1.RowCount; i++)
            {
                for (int j = 1; j <= gridControl1.ColCount; j++)
                    if (j != 7)
                    {
                        {
                            gridControl1[i, j].CellValue = 100 * i + j;
                        }
                    }
            }
            RegisterCellModel.GridCellType(gridControl1, CustomCellTypes.DoubleTextBox);
            for (int i = 1; i <= gridControl1.RowCount; i++)
            {
                gridControl1[i, 7].CellType = CustomCellTypes.DoubleTextBox.ToString();
                gridControl1[i, 7].CellValue = 0;
            }
            //Event Subscription
            gridControl1.DrawCellDisplayText += GridControl1_DrawCellDisplayText;

        }
        //Event Customization
        private void GridControl1_DrawCellDisplayText(object sender, GridDrawCellDisplayTextEventArgs e)
        {
            if(e.Style.CellType== CustomCellTypes.DoubleTextBox.ToString() && e.DisplayText== "0.00")
            {
                e.DisplayText = "0";
            }
        }
    }
}
    

