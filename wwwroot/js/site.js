// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


      
 const swiper = new Swiper('.category-carousel', {
    slidesPerView: 5,
    spaceBetween: 10,
    navigation: {
        nextEl: '.category-carousel-next',
        prevEl: '.category-carousel-prev',
    },
    loop: true,
    breakpoints: {
        640: { slidesPerView: 3, spaceBetween: 10 },
        768: { slidesPerView: 4, spaceBetween: 10 },
        1024: { slidesPerView: 5, spaceBetween: 10 },
    },
});

        document.getElementById('quantity').addEventListener('input', function() {
            const quantity = parseInt(this.value) || 1;
            const maxQuantity = parseInt(this.max);
            const price = parseFloat(document.getElementById('productPrice').value);

            if (quantity > maxQuantity) {
                this.value = maxQuantity;
                alert('Selected quantity exceeds available stock.');
            }

            const total = (price * this.value).toFixed(2);
            document.getElementById('totalPrice').textContent = total;
        });
   




        function toggleAllProducts() {
            const selectAllCheckbox = document.getElementById('selectAll');
            const productCheckboxes = document.getElementsByClassName('product-checkbox');

            Array.from(productCheckboxes).forEach(checkbox => {
                if (!checkbox.disabled) {
                    checkbox.checked = selectAllCheckbox.checked;
                }
            });

            updateBulkOrderButton();
        }

        function updateBulkOrderButton() {
            const productCheckboxes = document.getElementsByClassName('product-checkbox');
            const bulkOrderBtn = document.getElementById('bulkOrderBtn');
            const hasCheckedProducts = Array.from(productCheckboxes).some(checkbox => checkbox.checked);

            bulkOrderBtn.disabled = !hasCheckedProducts;
        }

        function validateStock() {
            const productCheckboxes = document.getElementsByClassName('product-checkbox');
            for (const checkbox of productCheckboxes) {
                if (checkbox.checked && parseInt(checkbox.getAttribute('data-quantity')) === 0) {
                    alert("One or more selected products are out of stock.");
                    return false;
                }
            }
            return true; 
        }

        document.addEventListener('DOMContentLoaded', function() {
            updateBulkOrderButton();
        });

//function toggledown() {
//    const dropdownmenu = document.getElementById('dropdownmenu');
//    const isvisible = dropdownmenu.style.display === 'block';
//    dropdownmenu.style.display = isvisble ? 'none' : 'block';
//}
//window.addEventListener('click', function (event)){
//    const dropdownmenu = document.getElementById('dropdownmenu');
//    const button = document.querySelector('dropdown-btn');
//    if (!button.contains(event.target) && !dropdownmenu.contains(event.target))
//    {
//        dropdownmenu.style.display = 'none';
//    }
//}


