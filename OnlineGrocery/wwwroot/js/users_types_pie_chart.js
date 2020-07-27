am4core.ready(function () {

    // Themes begin
    am4core.useTheme(am4themes_animated);
// Themes end

// Create chart instance
var chart = am4core.create("chartdiv_users_types", am4charts.PieChart);

// Add data
chart.data = [{
    "Type": "User",
    "Users": 700
}, {
    "Type": "GoldenUser",
    "Users": 200
}, {
    "Type": "PlatinumUser",
    "Users": 100
}];

// Add and configure Series
var pieSeries = chart.series.push(new am4charts.PieSeries());
    pieSeries.dataFields.value = "Users";
pieSeries.dataFields.category = "Type";
pieSeries.slices.template.stroke = am4core.color("#fff");
pieSeries.slices.template.strokeOpacity = 1;

// This creates initial animation
pieSeries.hiddenState.properties.opacity = 1;
pieSeries.hiddenState.properties.endAngle = -90;
pieSeries.hiddenState.properties.startAngle = -90;

chart.hiddenState.properties.radius = am4core.percent(0);


}); // end am4core.ready()