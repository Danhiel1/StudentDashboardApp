using DevExpress.XtraCharts;
using DevExpress.Utils;
using System.Drawing;

public static class ChartService
{
    public static void LoadChart(
        ChartControl chart,
        object dataSource,
        string argumentMember,
        string valueMember,
        ViewType viewType,
        string chartTitle = null
    )
    {
        chart.Series.Clear();

        // 🟦 1. Tạo series
        var series = new Series("Series", viewType)
        {
            ArgumentDataMember = argumentMember
        };
        series.ValueDataMembers.AddRange(new string[] { valueMember });

        // 🟩 2. Thiết lập cơ bản theo loại biểu đồ
        switch (viewType)
        {
            case ViewType.Bar:
                var barView = (BarSeriesView)series.View;
                barView.ColorEach = true;
                barView.BarWidth = 0.6;

                // Label trên thanh
                var barLabel = (BarSeriesLabel)series.Label;
                barLabel.TextPattern = "{V:F2}";
                barLabel.Position = BarSeriesLabelPosition.Top;
                barLabel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                barLabel.TextColor = Color.White;
                series.LabelsVisibility = DefaultBoolean.True;
                break;

            case ViewType.Pie:
                var pieLabel = (PieSeriesLabel)series.Label;
                pieLabel.TextPattern = "{A}: {V}";
                pieLabel.Font = new Font("Segoe UI", 9);
                pieLabel.TextColor = Color.White;
                ((PieSeriesView)series.View).ExplodeMode = PieExplodeMode.All;
                break;
        }

        // 🟨 3. Gán dữ liệu
        chart.Series.Add(series);
        chart.DataSource = dataSource;

        // 🟧 4. Làm đẹp nền & trục (dark theme friendly)
        chart.Legend.Visibility = DefaultBoolean.False;
        chart.BorderOptions.Visibility = DefaultBoolean.False;
        chart.BackColor = Color.FromArgb(30, 30, 30);

        if (chart.Diagram is XYDiagram diagram)
        {
            diagram.DefaultPane.BackColor = Color.FromArgb(35, 35, 35);

            diagram.AxisX.Label.Font = new Font("Segoe UI", 9);
            diagram.AxisX.Label.TextColor = Color.White;
            diagram.AxisX.GridLines.Visible = false;
            diagram.AxisX.Color = Color.White;

            diagram.AxisY.Label.Font = new Font("Segoe UI", 9);
            diagram.AxisY.Label.TextColor = Color.White;
            diagram.AxisY.GridLines.Visible = false;
            diagram.AxisY.Color = Color.White;
        }

        // 🟥 5. Tiêu đề (nếu có)
        chart.Titles.Clear();
        if (!string.IsNullOrEmpty(chartTitle))
        {
            chart.Titles.Add(new ChartTitle()
            {
                Text = chartTitle,
                Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                TextColor = Color.White,
                Alignment = StringAlignment.Center
            });
        }
    }
}
