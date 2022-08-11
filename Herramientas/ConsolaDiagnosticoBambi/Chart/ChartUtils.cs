using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ConsolaBambiBot
{
    public static class ChartUtils
    {
        const Single UMBRAL_MAXIMOS_LOG = 50;
        const Single UMBRAL_MAXIMOS_LIN = 0.1F;
        const Single AXIS_X_INTERVAL = 250;//100;//200;

        public static void InicializarChart(Chart chart)
        {
            //Acondiciono el grafico principal
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Interval = AXIS_X_INTERVAL;//chart.ChartAreas[0].AxisX.Maximum/20; //AXIS_X_INTERVAL;
            chart.ChartAreas[0].AxisX.Title = "Frecuencia [Hz]";
            chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{#,#}";  //Solo 1 decimal para los interval de los ejes
            

            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 4096; //250;
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "{#,#}";

            //chart.DataManipulator.FilterTopN(5, "Muestras");
            //chart.Series["Muestras"].Points.AddXY(50, 50);
        }


        public static void ActivarZoom(Chart chart, bool enable)
        {
            chart.ChartAreas[0].CursorX.IsUserEnabled = enable;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = enable;
            chart.ChartAreas[0].CursorX.Interval = 0;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = enable;
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 0;

            chart.ChartAreas[0].CursorY.IsUserEnabled = enable;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = enable;
            chart.ChartAreas[0].CursorY.Interval = 0;
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = enable;
            chart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            chart.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chart.ChartAreas[0].AxisY.ScaleView.SmallScrollMinSize = 0;
            if (enable == false)
            {
                //Quita la linea de los cursores
                chart.ChartAreas[0].CursorX.SetCursorPosition(double.NaN);
                chart.ChartAreas[0].CursorY.SetCursorPosition(double.NaN);
            }
        }
    }
}
