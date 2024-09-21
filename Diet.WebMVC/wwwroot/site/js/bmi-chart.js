const ctx = document.getElementById('bmiChart').getContext('2d');

// Height and weight boundaries for different BMI categories
const bmiBoundaries = [
    {label: 'لاغر', backgroundColor: 'rgba(173, 216, 230, 0.5)', borderColor: 'rgba(173, 216, 230, 1)', points: [{x: 146, y: 45}, {x: 198, y: 68}]},
    {label: 'نرمال', backgroundColor: 'rgba(144, 238, 144, 0.5)', borderColor: 'rgba(144, 238, 144, 1)', points: [{x: 146, y: 52}, {x: 198, y: 85}]},
    {label: 'اضافه وزن', backgroundColor: 'rgba(255, 255, 0, 0.5)', borderColor: 'rgba(255, 255, 0, 1)', points: [{x: 146, y: 65}, {x: 198, y: 103}]},
    {label: 'چاق', backgroundColor: 'rgba(255, 99, 132, 0.5)', borderColor: 'rgba(255, 99, 132, 1)', points: [{x: 146, y: 77}, {x: 198, y: 130}]},
    {label: 'چاقی شدید', backgroundColor: 'rgba(128, 0, 128, 0.5)', borderColor: 'rgba(128, 0, 128, 1)', points: [{x: 146, y: 103}, {x: 198, y: 172}]},
];

// Generate data for each region based on the defined points
const datasets = bmiBoundaries.map(boundary => {
    return {
        label: boundary.label,
        data: [
            {x: boundary.points[0].x, y: boundary.points[0].y}, 
            {x: boundary.points[1].x, y: boundary.points[1].y}
        ],
        backgroundColor: boundary.backgroundColor,
        borderColor: boundary.borderColor,
        fill: 'start',
        borderWidth: 2,
        pointRadius: 0,
        showLine: true,
    };
});

const bmiChart = new Chart(ctx, {
    type: 'scatter',
    data: {
        datasets: datasets
    },
    options: {
        responsive: true,
        scales: {
            x: {
                type: 'linear',
                position: 'bottom',
                title: {
                    display: true,
                    text: 'قد (cm)',
                },
                min: 140,
                max: 200,
                ticks: {
                    stepSize: 10
                }
            },
            y: {
                title: {
                    display: true,
                    text: 'وزن (kg)',
                },
                min: 30,
                max: 180,
                ticks: {
                    stepSize: 10
                }
            }
        }
    }
});

Chart.defaults.font.family = "Vazirmatn"