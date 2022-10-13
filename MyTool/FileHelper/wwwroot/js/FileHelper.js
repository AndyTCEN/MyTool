// Get a reference to the file input
const fileInput = document.querySelector('input');
const fileInputTo = document.getElementById('filename');


// Listen for the change event so we can capture the file
fileInput.addEventListener('change', (e) => {
    // Get a reference to the file
    const file = e.target.files[0];

    // Encode the file using the FileReader API
    const reader = new FileReader();
    reader.onloadend = () => {
        // Use a regex to remove data url part
        const base64String = reader.result
            .replace('data:', '')
            .replace(/^.+,/, '');
        fileInputTo.value = base64String;
        console.log(base64String);
        // Logs wL2dvYWwgbW9yZ...

    };
    reader.readAsDataURL(file);
});