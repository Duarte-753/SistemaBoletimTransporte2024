document.addEventListener("DOMContentLoaded", function () {
    var menuToggle = document.getElementById("menu-toggle");
    var loginContainer = document.getElementById("login-container");

    menuToggle.addEventListener("click", function () {
        loginContainer.classList.toggle("show-login");
        this.classList.toggle("clicked");

        setTimeout(function () {
            if (loginContainer.classList.contains("show-login")) {
                loginContainer.style.display = "block";
            } else {
                loginContainer.style.display = "none";
            }
        }, 10);
    });
});

//service card

document.addEventListener("DOMContentLoaded", function () {
    let icons = document.querySelectorAll(".service-card .icon");

    icons.forEach(icon => {
        icon.addEventListener("mouseenter", function () {
            icon.style.transform = "scale(0.8)";
        });

        icon.addEventListener("mouseleave", function () {
            icon.style.transform = "scale(1)";
        });
    });
});