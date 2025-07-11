function validateInput() {
    const zipInput = document.getElementById("zipCode");
    const zip = zipInput.value.trim();
    const errorMessage = document.getElementById("errorMessage");

    // Reset previous state
    zipInput.classList.remove("input-error");
    errorMessage.style.display = "none";

    // Validation: ZIP must be exactly 5 digits
    if (zip.length !== 5 || isNaN(zip) || zip == null) {
        zipInput.classList.add("input-error");
        errorMessage.style.display = "block"; 
        return false; // Block form submission
    }

    return true; // Allow form submission
}
