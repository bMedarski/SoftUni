window.onload = () => {

    let inputBox = document.getElementById('inputDistance');
    let outputBox = document.getElementById('outputDistance');
    let button = document.getElementById('convert');

    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');

    button.addEventListener('click', convert);

    let units = {
        'km': 1000,
        'm': 1,
        'cm': 0.01,
        'mm': 0.001,
        'mi': 1609.34,
        'yrd': 0.9144,
        'ft': 0.3048,
        'in': 0.0254
    }

    function convert() {
        let value = inputBox.value;
        let inputRate = units[inputUnits.value];
        let outputRate = units[outputUnits.value];

        let output = value * inputRate / outputRate;
        outputBox.value = output;
    }
}