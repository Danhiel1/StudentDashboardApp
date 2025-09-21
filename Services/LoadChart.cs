using DevExpress.XtraCharts;

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

        var series = new Series("Series", viewType)
        {
            ArgumentDataMember = argumentMember
        };

        // 👇 Thay vì gán thẳng, dùng AddRange
        series.ValueDataMembers.AddRange(new string[] { valueMember });

        // Nếu là Bar → mỗi cột một màu
        if (viewType == ViewType.Bar)
        {
            ((BarSeriesView)series.View).ColorEach = true;
        }

        // Nếu là Pie → hiển thị label + nhiều màu
        if (viewType == ViewType.Pie)
        {
            PieSeriesLabel label = (PieSeriesLabel)series.Label;
            label.TextPattern = "{A}: {V}";
            ((PieSeriesView)series.View).ExplodeMode = PieExplodeMode.All;
        }

        chart.Series.Add(series);
        chart.DataSource = dataSource;

        // Thêm tiêu đề nếu có
        if (!string.IsNullOrEmpty(chartTitle))
        {
            chart.Titles.Clear();
            chart.Titles.Add(new ChartTitle() { Text = chartTitle });
        }

        chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
    }
}
