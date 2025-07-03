let hamburgerMenuActive = false
let darkMode = false

function hamburgerMenuToggle() {
    var sidebar = document.getElementById("sidebar")

    if(!hamburgerMenuActive) {
        sidebar.style.display = "inherit";
    } else {
        sidebar.removeAttribute("style")
    }

    hamburgerMenuActive = !hamburgerMenuActive
}

// Zaktualizuj wygląd strony
function updateTheme() {
    // Na tym etapie DOM powinien być już gotowy
    var body = document.getElementsByTagName("body")[0]

    if(darkMode === true) {
        body.classList.add("dark-mode")
    } else {
        body.classList.remove("dark-mode")
    }
}

function toggleDarkMode() {
    darkMode = !darkMode
    localStorage.setItem("darkMode", darkMode)

    console.log(darkMode)
    console.log(localStorage.getItem("darkMode"))

    updateTheme()
}

function loadDarkModeSettings() {
    // Z localStorage
    darkMode = localStorage.getItem("darkMode") === "true";

    console.log("Initial darkMode value: " + darkMode)

    updateTheme()
}

function onPageLoad() {
    console.log("Page loaded!")
    loadDarkModeSettings()
}

document.addEventListener('DOMContentLoaded', onPageLoad);