
const ul = document.getElementById("nav_products");
const button = document.getElementById("toggle_nav_products_btn");

const ToggleUl = () => {
    if (ul.className === "display_none") {
        ul.classList.remove("display_none");
    }
    else {
        ul.classList.add("display_none");
    }
}

button.addEventListener("click", ToggleUl);