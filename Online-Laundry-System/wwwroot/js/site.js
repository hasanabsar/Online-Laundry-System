// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    
    const sidebarItems = document.querySelectorAll('.sidebar-item');
    const sections = document.querySelectorAll('.view-section');

    sidebarItems.forEach(item => {
            item.addEventListener('click', () => {
                const target = item.getAttribute('data-target');

                // Remove active class from all sidebar items
                sidebarItems.forEach(i => i.classList.remove('active'));
                item.classList.add('active');

                // Show target section and hide others
                sections.forEach(section => {
                    if (section.id === target) {
                        section.classList.add('active');
                    } else {
                        section.classList.remove('active');
                    }
                });
            });
    });
    
