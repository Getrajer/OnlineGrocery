am4core.ready(function () {

    // Themes begin
    am4core.useTheme(am4themes_animated);
    // Themes end

    // Create chart instance
    var chart = am4core.create("chartdivYear", am4charts.XYChart3D);

    // Add data
    chart.data = [{
        "Month": "January",
        "MoneyIn": 40250
    }, {
        "Month": "Febuary",
        "MoneyIn": 56205
    }, {
        "Month": "March",
        "MoneyIn": 14025
    }, {
        "Month": "April",
        "MoneyIn": 100025
    }, {
        "Month": "May",
        "MoneyIn": 113025
    }, {
        "Month": "June",
        "MoneyIn": 123450
    }, {
        "Month": "July",
        "MoneyIn": 154210
    }, {
        "Month": "August",
        "MoneyIn": 158210
    }, {
        "Month": "September",
        "MoneyIn": 164210
    }, {
        "Month": "October",
        "MoneyIn": 174210
    }, {
        "Month": "November",
        "MoneyIn": 144210
    }, {
        "Month": "December",
        "MoneyIn": 184210
    }];

    // Create axes
    let categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
    categoryAxis.dataFields.category = "Month";
    categoryAxis.renderer.labels.template.rotation = 270;
    categoryAxis.renderer.labels.template.hideOversized = false;
    categoryAxis.renderer.minGridDistance = 20;
    categoryAxis.renderer.labels.template.horizontalCenter = "right";
    categoryAxis.renderer.labels.template.verticalCenter = "middle";
    categoryAxis.tooltip.label.rotation = 270;
    categoryAxis.tooltip.label.horizontalCenter = "right";
    categoryAxis.tooltip.label.verticalCenter = "middle";

    let valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    valueAxis.title.text = "Month";
    valueAxis.title.fontWeight = "bold";

    // Create series
    var series = chart.series.push(new am4charts.ColumnSeries3D());
    series.dataFields.valueY = "MoneyIn";
    series.dataFields.categoryX = "Month";
    series.name = "MoneyIn";
    series.tooltipText = "{categoryX}: [bold]{valueY}[/]";
    series.columns.template.fillOpacity = .8;

    var columnTemplate = series.columns.template;
    columnTemplate.strokeWidth = 2;
    columnTemplate.strokeOpacity = 1;
    columnTemplate.stroke = am4core.color("#FFFFFF");

    columnTemplate.adapter.add("fill", function (fill, target) {
        return chart.colors.getIndex(target.dataItem.index);
    })

    columnTemplate.adapter.add("stroke", function (stroke, target) {
        return chart.colors.getIndex(target.dataItem.index);
    })

    chart.cursor = new am4charts.XYCursor();
    chart.cursor.lineX.strokeOpacity = 0;
    chart.cursor.lineY.strokeOpacity = 0;

}); // end am4core.ready()