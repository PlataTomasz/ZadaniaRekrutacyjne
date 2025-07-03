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
    var darkModeIcon = document.getElementById("dark-mode-icon")

    if(darkMode === true) {
        body.classList.add("dark-mode")
        darkModeIcon.classList.remove("fa-moon")
        darkModeIcon.classList.add("fa-sun")
    } else {
        body.classList.remove("dark-mode")
        darkModeIcon.classList.remove("fa-sun")
        darkModeIcon.classList.add("fa-moon")
    }
}

function toggleDarkMode() {
    darkMode = !darkMode
    localStorage.setItem("darkMode", darkMode)
    updateTheme()
}

function loadDarkModeSettings() {
    // Z localStorage
    darkMode = localStorage.getItem("darkMode") === "true";

    updateTheme()
}

function onPageLoad() {
    console.log("Page loaded!")
    loadDarkModeSettings()
}

document.addEventListener('DOMContentLoaded', onPageLoad);