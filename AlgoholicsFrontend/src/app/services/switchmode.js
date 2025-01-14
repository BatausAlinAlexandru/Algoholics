document.addEventListener('DOMContentLoaded', () => {
    const themeToggle = document.getElementById('theme-toggle');
    const rootElement = document.documentElement;
  
    // Load the saved theme from localStorage
    const savedTheme = localStorage.getItem('theme');
    if (savedTheme) {
      rootElement.classList.toggle('dark-mode', savedTheme === 'dark');
      themeToggle.textContent = savedTheme === 'dark' ? 'Light Mode' : 'Dark Mode';
    }
  
    // Toggle the theme on button click
    themeToggle.addEventListener('click', () => {
      const isDarkMode = rootElement.classList.toggle('dark-mode');
      localStorage.setItem('theme', isDarkMode ? 'dark' : 'light');
      themeToggle.textContent = isDarkMode ? 'Light Mode' : 'Dark Mode';
    });
  });